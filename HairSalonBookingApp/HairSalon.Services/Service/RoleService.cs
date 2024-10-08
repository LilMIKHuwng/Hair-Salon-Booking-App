using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.Core.Base;
using HairSalon.Core.Constants;
using HairSalon.ModelViews.RoleModelViews;
using HairSalon.Repositories.UOW;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
namespace HairSalon.Services.Service
{
	public class RoleService : IRoleService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _contextAccessor;

		public RoleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_contextAccessor = contextAccessor;
		}

		// Get all roles with pagination and optional filters for name and ID
		public async Task<BasePaginatedList<RoleModelView>> GetAllRoleAsync(int pageNumber, int pageSize, string? id, string? name)
		{
			try
			{
				IQueryable<ApplicationRoles> roleQuery = _unitOfWork.GetRepository<ApplicationRoles>().Entities
					.Where(p => !p.DeletedTime.HasValue);

				// Apply filters if provided
				if (!string.IsNullOrWhiteSpace(id))
					roleQuery = roleQuery.Where(p => p.Id.ToString() == id);

				if (!string.IsNullOrWhiteSpace(name))
					roleQuery = roleQuery.Where(p => p.Name.Contains(name));

				roleQuery = roleQuery.OrderByDescending(r => r.CreatedTime);

				int totalCount = await roleQuery.CountAsync();

				List<ApplicationRoles> paginatedRoles = await roleQuery
					.Skip((pageNumber - 1) * pageSize)
					.Take(pageSize)
					.ToListAsync();

				List<RoleModelView> roleModelViews = _mapper.Map<List<RoleModelView>>(paginatedRoles);

				return new BasePaginatedList<RoleModelView>(roleModelViews, totalCount, pageNumber, pageSize);
			}
			catch (Exception ex)
			{
				throw new BaseException.CoreException("GET_ALL_ROLES_ERROR", "An error occurred while retrieving roles.", (int)StatusCodeHelper.ServerError);
			}
		}

		// Add a new role
		public async Task<string> AddRoleAsync(CreateRoleModelView model)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(model.Name))
				{
					throw new BaseException.BadRequestException("EMPTY_ROLE_NAME", "Role name cannot be empty.");
				}

				ApplicationRoles newRole = _mapper.Map<ApplicationRoles>(model);

				newRole.CreatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
				newRole.CreatedTime = DateTimeOffset.UtcNow;

				await _unitOfWork.GetRepository<ApplicationRoles>().InsertAsync(newRole);
				await _unitOfWork.SaveAsync();

				return "Add new role successfully!";
			}
			catch (BaseException.BadRequestException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new BaseException.CoreException("ADD_ROLE_ERROR", "An error occurred while adding the role.", (int)StatusCodeHelper.ServerError);
			}
		}

        // Update an existing role
        public async Task<string> UpdateRoleAsync(string id, UpdatedRoleModelView model)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(id))
				{
					throw new BaseException.BadRequestException("INVALID_ROLE_ID", "Please provide a valid Role ID.");
				}

				ApplicationRoles existingRole = await _unitOfWork.GetRepository<ApplicationRoles>().Entities
					.FirstOrDefaultAsync(r => r.Id == Guid.Parse(id) && !r.DeletedTime.HasValue)
					?? throw new BaseException.BadRequestException("ROLE_NOT_FOUND", "The role cannot be found or has been deleted!");

				bool isUpdated = false;

				if (!string.IsNullOrWhiteSpace(model.Name) && model.Name != existingRole.Name)
				{
					existingRole.Name = model.Name;
					isUpdated = true;
				}

				if (isUpdated)
				{
					existingRole.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
					existingRole.LastUpdatedTime = DateTimeOffset.UtcNow;

					_unitOfWork.GetRepository<ApplicationRoles>().Update(existingRole);
					await _unitOfWork.SaveAsync();
				}

				return "Updated role successfully!";
			}
			catch (BaseException.BadRequestException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new BaseException.CoreException("UPDATE_ROLE_ERROR", "An error occurred while updating the role.", (int)StatusCodeHelper.ServerError);
			}
		}

		// Delete an existing role (soft delete)
		public async Task<string> DeleteRoleAsync(string id)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(id))
				{
					throw new BaseException.BadRequestException("INVALID_ROLE_ID", "Please provide a valid Role ID.");
				}

				ApplicationRoles existingRole = await _unitOfWork.GetRepository<ApplicationRoles>().Entities
					.FirstOrDefaultAsync(r => r.Id == Guid.Parse(id) && !r.DeletedTime.HasValue)
					?? throw new BaseException.BadRequestException("ROLE_NOT_FOUND", "The role cannot be found or has been deleted!");

				existingRole.DeletedTime = DateTimeOffset.UtcNow;
				existingRole.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;

				_unitOfWork.GetRepository<ApplicationRoles>().Update(existingRole);
				await _unitOfWork.SaveAsync();

				return "Deleted role successfully!";
			}
			catch (BaseException.BadRequestException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new BaseException.CoreException("DELETE_ROLE_ERROR", "An error occurred while deleting the role.", (int)StatusCodeHelper.ServerError);
			}
		}
	}

}
