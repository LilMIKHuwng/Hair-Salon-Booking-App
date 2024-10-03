using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.RoleModelViews;
using Microsoft.EntityFrameworkCore;
namespace HairSalon.Services.Service
{
    public class RoleService: IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BasePaginatedList<RoleModelView>> GetAllRoleAsync(int pageNumber, int pageSize)
        {
            IQueryable<ApplicationRoles> roleQuery = _unitOfWork.GetRepository<ApplicationRoles>().Entities
                .Where(p => !p.DeletedTime.HasValue)
                .OrderByDescending(s => s.CreatedTime);

            int totalCount = await roleQuery.CountAsync();

            List<ApplicationRoles> paginatedShops = await roleQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            List<RoleModelView> shopModelViews = _mapper.Map<List<RoleModelView>>(paginatedShops);

            return new BasePaginatedList<RoleModelView>(shopModelViews, totalCount, pageNumber, pageSize);
        }

		public async Task<RoleModelView> AddRoleAsync(CreateRoleModelView model)
		{
			if (string.IsNullOrWhiteSpace(model.Name))
			{
				throw new Exception("Role name cannot be empty.");
			}

			ApplicationRoles newRole = _mapper.Map<ApplicationRoles>(model);

			newRole.CreatedBy = "claim account";  
			newRole.CreatedTime = DateTimeOffset.UtcNow;
			newRole.LastUpdatedTime = DateTimeOffset.UtcNow;

			await _unitOfWork.GetRepository<ApplicationRoles>().InsertAsync(newRole);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<RoleModelView>(newRole);
		}

		public async Task<RoleModelView> UpdateRoleAsync(string id, UpdatedRoleModelView model)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				throw new Exception("Please provide a valid Role ID.");
			}

			ApplicationRoles existingRole = await _unitOfWork.GetRepository<ApplicationRoles>().Entities
				.FirstOrDefaultAsync(s => s.Id == Guid.Parse(id) && !s.DeletedTime.HasValue)
				?? throw new Exception("The Role cannot be found or has been deleted!");

			_mapper.Map(model, existingRole);

			existingRole.LastUpdatedBy = "claim account";  
			existingRole.LastUpdatedTime = DateTimeOffset.UtcNow;

			_unitOfWork.GetRepository<ApplicationRoles>().Update(existingRole);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<RoleModelView>(existingRole);
		}

		public async Task<string> DeleteRoleAsync(string id)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				throw new Exception("Please provide a valid Role ID.");
			}

			ApplicationRoles existingRole = await _unitOfWork.GetRepository<ApplicationRoles>().Entities
				.FirstOrDefaultAsync(s => s.Id == Guid.Parse(id) && !s.DeletedTime.HasValue)
				?? throw new Exception("The Role cannot be found or has been deleted!");

			existingRole.DeletedTime = DateTimeOffset.UtcNow;
			existingRole.DeletedBy = "claim account"; 

			_unitOfWork.GetRepository<ApplicationRoles>().Update(existingRole);
			await _unitOfWork.SaveAsync();
			return "Deleted";
		}

		public async Task<RoleModelView> GetRoleAsync(string id)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				throw new Exception("Please provide a valid Role ID.");
			}

			ApplicationRoles existingRole = await _unitOfWork.GetRepository<ApplicationRoles>().Entities
				.FirstOrDefaultAsync(s => s.Id == Guid.Parse(id) && !s.DeletedTime.HasValue)
				?? throw new Exception("The Role cannot be found or has been deleted!");

			return _mapper.Map<RoleModelView>(existingRole);
		}
	}
}
