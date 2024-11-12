using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.RoleModelViews;
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
			// Initialize the query for roles, filtering out roles that have a DeletedTime 
			IQueryable<ApplicationRoles> roleQuery = _unitOfWork.GetRepository<ApplicationRoles>().Entities
				.AsNoTracking()
				.Where(p => !p.DeletedTime.HasValue);

			// If an ID filter is provided, apply it to the query
			if (!string.IsNullOrWhiteSpace(id))
				roleQuery = roleQuery.Where(p => p.Id.ToString() == id);

			// If a name filter is provided, apply it to the query
			if (!string.IsNullOrWhiteSpace(name))
				roleQuery = roleQuery.Where(p => p.Name.Contains(name));

			// Order the query results by the creation time in descending order
			roleQuery = roleQuery.OrderByDescending(r => r.CreatedTime);

			// Get the total count of roles that match the query (before applying pagination)
			int totalCount = await roleQuery.CountAsync();

			// Apply pagination to the query, skipping records to get to the desired page and taking the page size
			List<ApplicationRoles> paginatedRoles = await roleQuery
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

			// Map the paginated list of roles (ApplicationRoles) to the desired view model (RoleModelView)
			List<RoleModelView> roleModelViews = _mapper.Map<List<RoleModelView>>(paginatedRoles);

			// Return the paginated list of roles, along with total count and pagination details
			return new BasePaginatedList<RoleModelView>(roleModelViews, totalCount, pageNumber, pageSize);
		}

		public async Task<string> AddRoleAsync(CreateRoleModelView model, string? userId)
		{
			// Check if the role already exists by querying the database for a role with the same name
			var existedRole = await _unitOfWork.GetRepository<ApplicationRoles>()
				.Entities
				.FirstOrDefaultAsync(role => role.Name.Equals(model.Name) && !role.DeletedTime.HasValue);

			// If the role already exists, return a message indicating that
			if (existedRole != null)
			{
				return "Role already exists";
			}

			// Map the incoming model to a new ApplicationRoles entity
			ApplicationRoles newRole = _mapper.Map<ApplicationRoles>(model);

			// Assign additional properties: CreatedBy and LastUpdatedBy from the current user's information
			if (userId != null)
			{
				newRole.CreatedBy = userId;
			}
			else
			{
				newRole.CreatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
			}
			newRole.CreatedTime = DateTimeOffset.UtcNow;

			// Insert the new role into the database
			await _unitOfWork.GetRepository<ApplicationRoles>().InsertAsync(newRole);

			// Save the changes to the database
			await _unitOfWork.SaveAsync();

			// Return a success message indicating that the role was successfully added
			return "Role successfully added";
		}

		// Update an existing role
		public async Task<string> UpdateRoleAsync(string id, UpdatedRoleModelView model, string? userId)
		{
			// Check if the provided Role ID is valid (non-empty and non-whitespace)
			if (string.IsNullOrWhiteSpace(id))
			{
				return "Please provide a valid Role ID.";
			}

			// Retrieve the existing role based on the ID, ensuring it hasn't been deleted
			var existingRole = await _unitOfWork.GetRepository<ApplicationRoles>().Entities
				.FirstOrDefaultAsync(s => s.Id == Guid.Parse(id) && !s.DeletedTime.HasValue);

			// If no role is found or the role has been deleted, return an error message
			if (existingRole == null)
			{
				return "The Role cannot be found or has been deleted!";
			}

			bool isUpdated = false;

			// Check if the role name needs to be updated
			if (!string.IsNullOrWhiteSpace(model.Name) && model.Name != existingRole.Name)
			{
				// Check if another role with the same name already exists (to prevent duplicates)
				var roleWithSameName = await _unitOfWork.GetRepository<ApplicationRoles>().Entities
					.AnyAsync(s => s.Name == model.Name && !s.DeletedTime.HasValue);

				// If a role with the same name exists, return an error message
				if (roleWithSameName)
				{
					return "A role with the same name already exists.";
				}

				// Update the role name
				existingRole.Name = model.Name;
				isUpdated = true;
			}

			// If there were any updates, update the LastUpdatedBy and LastUpdatedTime fields
			if (isUpdated)
			{
				if (userId != null)
				{
					existingRole.LastUpdatedBy = userId;
				}
				else
				{
					existingRole.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
				}
				existingRole.LastUpdatedTime = DateTimeOffset.UtcNow;

				// Save the updated role to the repository
				await _unitOfWork.GetRepository<ApplicationRoles>().UpdateAsync(existingRole);
				await _unitOfWork.SaveAsync();
			}

			// Return a success message
			return "Role successfully updated";
		}

		// Soft delete a role
		public async Task<string> DeleteRoleAsync(string id, string? userId)
		{
			// Check if the provided Role ID is valid (non-empty and non-whitespace)
			if (string.IsNullOrWhiteSpace(id))
			{
				return "Please provide a valid Role ID.";
			}

			// Retrieve the existing role based on the ID, ensuring it hasn't been deleted
			var existingRole = await _unitOfWork.GetRepository<ApplicationRoles>().Entities
				.FirstOrDefaultAsync(s => s.Id == Guid.Parse(id) && !s.DeletedTime.HasValue);

			// If no role is found or the role has already been deleted, return an error message
			if (existingRole == null)
			{
				return "The Role cannot be found or has been deleted!";
			}

			// Mark the role as deleted by setting the DeletedTime to the current UTC time
			existingRole.DeletedTime = DateTimeOffset.UtcNow;

			// Record the ID of the user performing the deletion action
			if (userId != null)
			{
				existingRole.DeletedBy = userId;
			}
			else
			{
				existingRole.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
			}

			// Update the repository with the modified role
			await _unitOfWork.GetRepository<ApplicationRoles>().UpdateAsync(existingRole);
			await _unitOfWork.SaveAsync();

			// Return a success message
			return "Role successfully deleted";
		}

		// Retrieve a role by its ID
		public async Task<RoleModelView?> GetRoleByIdAsync(string id)
		{
			// Check if the provided Role ID is valid (non-empty and non-whitespace)
			if (string.IsNullOrWhiteSpace(id))
			{
				return null; // Or you could throw an exception or return an error message
			}

			// Try to find the role by its ID, ensuring it hasn’t been marked as deleted
			var roleEntity = await _unitOfWork.GetRepository<ApplicationRoles>().Entities
				.FirstOrDefaultAsync(role => role.Id == Guid.Parse(id) && !role.DeletedTime.HasValue);

			// If the role is not found, return null
			if (roleEntity == null)
			{
				return null;
			}

			// Map the ApplicationRoles entity to a RoleModelView and return it
			RoleModelView roleModelView = _mapper.Map<RoleModelView>(roleEntity);
			return roleModelView;
		}
	}
}