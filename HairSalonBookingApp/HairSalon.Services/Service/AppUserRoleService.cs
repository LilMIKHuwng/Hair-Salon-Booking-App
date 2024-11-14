using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.AppUserRoleViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Services.Service
{
    public class AppUserRoleService : IAppUserRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public AppUserRoleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = httpContextAccessor;
        }

        public async Task<string> AddAppUserRoleAsync(CreateAppUserRoleModelView model)
        {
            try
            {
                // check valid UserId
                if (string.IsNullOrWhiteSpace(model.UserId))
                {
                    throw new Exception("User ID cannot be empty.");
                }

                // Map data model to entity
                ApplicationUserRoles newUserRole = _mapper.Map<ApplicationUserRoles>(model);
                newUserRole.CreatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
                newUserRole.CreatedTime = DateTimeOffset.UtcNow;
                newUserRole.LastUpdatedTime = DateTimeOffset.UtcNow;

                // save changes
                await _unitOfWork.GetRepository<ApplicationUserRoles>().InsertAsync(newUserRole);
                await _unitOfWork.SaveAsync();

                return "add new UserRole successfully";
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while adding user role: {ex.Message}", ex);
            }
        }

        public async Task<string> DeleteAppUserRoleAsync(string UserId, string RoleId)
        {
            try
            {
                // check valid UserId and RoleId
                if (string.IsNullOrWhiteSpace(UserId) && string.IsNullOrWhiteSpace(RoleId))
                {
                    throw new Exception("Please provide a valid Application User Role ID.");
                }

                // get UserRole by id and not deleted
                ApplicationUserRoles existingUserRole = await _unitOfWork.GetRepository<ApplicationUserRoles>().Entities
                    .FirstOrDefaultAsync(s => s.UserId == Guid.Parse(UserId) && s.RoleId == Guid.Parse(RoleId) && !s.DeletedTime.HasValue)
                    ?? throw new Exception("The Application User Role cannot be found or has been deleted!");

                // set DeletedTime, DeletedBy
                existingUserRole.DeletedTime = DateTimeOffset.UtcNow;
                existingUserRole.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;

                // save changes
                await _unitOfWork.GetRepository<ApplicationUserRoles>().UpdateAsync(existingUserRole);
                await _unitOfWork.SaveAsync();

                return "Deleted";
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while deleting user role: {ex.Message}", ex);
            }
        }

        public async Task<BasePaginatedList<AppUserRoleModelView>> GetAllAppUserRoleAsync(int pageNumber, int pageSize, string? userId, string? roleId)
        {
            try
            {
                // get user role from database
                IQueryable<ApplicationUserRoles> roleQuery = _unitOfWork.GetRepository<ApplicationUserRoles>().Entities
                    .Where(p => !p.DeletedTime.HasValue)
                    .OrderByDescending(s => s.CreatedTime);

                // filter by userId
                if (!string.IsNullOrEmpty(userId))
                {
                    roleQuery = roleQuery.Where(r => r.UserId.ToString().Equals(userId));
                }

                // filter by roleId
                if (!string.IsNullOrEmpty(roleId))
                {
                    roleQuery = roleQuery.Where(r => r.RoleId.ToString().Equals(roleId));
                }

                // Apply pagination
                int totalCount = await roleQuery.CountAsync();

                List<ApplicationUserRoles> paginatedShops = await roleQuery
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                // map data to model
                List<AppUserRoleModelView> appUserModelViews = _mapper.Map<List<AppUserRoleModelView>>(paginatedShops);

                return new BasePaginatedList<AppUserRoleModelView>(appUserModelViews, totalCount, pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while retrieving user roles: {ex.Message}", ex);
            }
        }

        public async Task<string> UpdateAppUserRoleAsync(string UserId, string RoleId, UpdateAppUserRoleModelView model)
        {
            try
            {
                // Validate UserId and RoleId
                if (string.IsNullOrWhiteSpace(UserId) && string.IsNullOrWhiteSpace(RoleId))
                {
                    throw new Exception("Please provide a valid Application User Role ID.");
                }

                // get userRoles by id and not deleted
                ApplicationUserRoles existingUserRole = await _unitOfWork.GetRepository<ApplicationUserRoles>().Entities
                    .FirstOrDefaultAsync(s => s.UserId == Guid.Parse(UserId) && s.RoleId == Guid.Parse(RoleId) && !s.DeletedTime.HasValue)
                    ?? throw new Exception("The Application User Role cannot be found or has been deleted!");

                // update userId if valid 
                if (!string.IsNullOrWhiteSpace(model.UserId))
                {
                    existingUserRole.UserId = Guid.Parse(model.UserId);
                }

                // update roleId if valid
                if (!string.IsNullOrWhiteSpace(model.RoleId))
                {
                    existingUserRole.RoleId = Guid.Parse(model.RoleId);
                }

                // update LastUpdatedBy, LastUpdatedTime
                existingUserRole.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
                existingUserRole.LastUpdatedTime = DateTimeOffset.UtcNow;

                // save changes
                await _unitOfWork.GetRepository<ApplicationUserRoles>().UpdateAsync(existingUserRole);
                await _unitOfWork.SaveAsync();

                return "update UserRole successfully";
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while updating user role: {ex.Message}", ex);
            }
        }
    }

}
