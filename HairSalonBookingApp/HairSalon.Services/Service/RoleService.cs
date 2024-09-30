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

        public async Task<RoleModelView> AddRoleAsync(CreateRoleModelView model, string createdBy, string lastUpdatedBy)
        {
            IGenericRepository<Role> roleRepository = _unitOfWork.GetRepository<Role>();

            Role newRole = _mapper.Map<Role>(model);

            //Tracking create
            newRole.CreatedBy = createdBy;
            newRole.LastUpdatedBy = lastUpdatedBy;

            //Insert new role to DB
            await _unitOfWork.GetRepository<Role>().InsertAsync(newRole);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<RoleModelView>(newRole);
        }

        public async Task<string> DeleteRoleAsync(string id, string deletedBy)
        {
            IGenericRepository<Role> roleRepository = _unitOfWork.GetRepository<Role>();

            Role deleteRole = await roleRepository.Entities
                                        .FirstOrDefaultAsync(role => role.Id == id && !role.DeletedTime.HasValue)
                                        ?? throw new Exception("The Role cannot be found or has been deleted!");

            //Tracking delete
            deleteRole.DeletedBy = deletedBy;
            deleteRole.LastUpdatedBy = deletedBy;
            deleteRole.DeletedTime = DateTime.UtcNow;

            //Update role for delete
            roleRepository.Update(deleteRole);
            await _unitOfWork.SaveAsync();

            return "Delete";
        }

        public async Task<RoleModelView> UpdateRoleAsync(string id, UpdatedRoleModelView model, string lastUpdatedBy)
        {
            IGenericRepository<Role> roleRepository = _unitOfWork.GetRepository<Role>();

            Role updateRole = await roleRepository.Entities
                                        .FirstOrDefaultAsync(role => role.Id == id && !role.DeletedTime.HasValue)
                                        ?? throw new Exception("The Role cannot be found or has been deleted!");

            _mapper.Map(model, updateRole);

            //Tracking update
            updateRole.LastUpdatedBy = lastUpdatedBy;
            updateRole.LastUpdatedTime = DateTime.UtcNow;

            //Update role
            await roleRepository.UpdateAsync(updateRole);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<RoleModelView>(updateRole);
        }
    }
}
