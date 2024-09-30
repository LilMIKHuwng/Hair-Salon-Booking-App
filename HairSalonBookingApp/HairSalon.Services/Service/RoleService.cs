using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.Core.Utils;
using HairSalon.ModelViews.RoleModelViews;
using HairSalon.ModelViews.ShopModelViews;
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
            IQueryable<Role> roleQuery = _unitOfWork.GetRepository<Role>().Entities
                .Where(p => !p.DeletedTime.HasValue)
                .OrderByDescending(s => s.CreatedTime);

            // Count the total number of matching records
            int totalCount = await roleQuery.CountAsync();

            // Apply pagination
            List<Role> paginatedShops = await roleQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Map to RoleModelView
            List<RoleModelView> shopModelViews = _mapper.Map<List<RoleModelView>>(paginatedShops);

            return new BasePaginatedList<RoleModelView>(shopModelViews, totalCount, pageNumber, pageSize);
        }

		public async Task<RoleModelView> AddRoleAsync(CreateRoleModelView model)
		{
			if (string.IsNullOrWhiteSpace(model.RoleName))
			{
				throw new Exception("Role name cannot be empty.");
			}

			Role newRole = _mapper.Map<Role>(model);

			newRole.Id = Guid.NewGuid().ToString("N");
			newRole.CreatedBy = "claim account";  
			newRole.CreatedTime = DateTimeOffset.UtcNow;
			newRole.LastUpdatedTime = DateTimeOffset.UtcNow;

			await _unitOfWork.GetRepository<Role>().InsertAsync(newRole);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<RoleModelView>(newRole);
		}

		public async Task<RoleModelView> UpdateRoleAsync(string id, UpdatedRoleModelView model)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				throw new Exception("Please provide a valid Role ID.");
			}

			Role existingRole = await _unitOfWork.GetRepository<Role>().Entities
				.FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
				?? throw new Exception("The Role cannot be found or has been deleted!");

			_mapper.Map(model, existingRole);

			// Set additional properties
			existingRole.LastUpdatedBy = "claim account";  
			existingRole.LastUpdatedTime = DateTimeOffset.UtcNow;

			_unitOfWork.GetRepository<Role>().Update(existingRole);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<RoleModelView>(existingRole);
		}

		public async Task<string> DeleteRoleAsync(string id)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				throw new Exception("Please provide a valid Role ID.");
			}

			Role existingRole = await _unitOfWork.GetRepository<Role>().Entities
				.FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
				?? throw new Exception("The Role cannot be found or has been deleted!");

			existingRole.DeletedTime = DateTimeOffset.UtcNow;
			existingRole.DeletedBy = "claim account"; 

			_unitOfWork.GetRepository<Role>().Update(existingRole);
			await _unitOfWork.SaveAsync();
			return "Deleted";
		}

		public async Task<RoleModelView> GetRoleAsync(string id)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				throw new Exception("Please provide a valid Role ID.");
			}

			Role existingRole = await _unitOfWork.GetRepository<Role>().Entities
				.FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
				?? throw new Exception("The Role cannot be found or has been deleted!");

			return _mapper.Map<RoleModelView>(existingRole);
		}
	}
}
