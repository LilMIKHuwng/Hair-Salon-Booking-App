using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ApplicationUserModelViews;
using HairSalon.ModelViews.AppUserRoleViewModels;
using HairSalon.Repositories.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Services.Service
{
	public class AppUserRoleService : IAppUserRoleService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public AppUserRoleService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<AppUserRoleModelView> AddAppUserRoleAsync(CreateAppUserRoleModelView model)
		{
			if (string.IsNullOrWhiteSpace(model.UserId))
			{
				throw new Exception("User ID cannot be empty.");
			}

			ApplicationUserRoles newUserRole = _mapper.Map<ApplicationUserRoles>(model);

			newUserRole.CreatedBy = "claim account";
			newUserRole.CreatedTime = DateTimeOffset.UtcNow;
			newUserRole.LastUpdatedTime = DateTimeOffset.UtcNow;

			await _unitOfWork.GetRepository<ApplicationUserRoles>().InsertAsync(newUserRole);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<AppUserRoleModelView>(newUserRole);
		}

		public async Task<string> DeleteAppUserRoleAsync(string UserId, string RoleId)
		{
			if (string.IsNullOrWhiteSpace(UserId) && string.IsNullOrWhiteSpace(RoleId))
			{
				throw new Exception("Please provide a valid Application User Role ID.");
			}

			ApplicationUserRoles existingUserRole = await _unitOfWork.GetRepository<ApplicationUserRoles>().Entities
				.FirstOrDefaultAsync(s => s.UserId == Guid.Parse(UserId) && s.RoleId == Guid.Parse(RoleId) && !s.DeletedTime.HasValue)
				?? throw new Exception("The Application User Role cannot be found or has been deleted!");

			existingUserRole.DeletedTime = DateTimeOffset.UtcNow;
			existingUserRole.DeletedBy = "claim account";

			_unitOfWork.GetRepository<ApplicationUserRoles>().Update(existingUserRole);
			await _unitOfWork.SaveAsync();
			return "Deleted";
		}

		public async Task<BasePaginatedList<AppUserRoleModelView>> GetAllAppUserRoleAsync(int pageNumber, int pageSize)
		{
			IQueryable<ApplicationUserRoles> roleQuery = _unitOfWork.GetRepository<ApplicationUserRoles>().Entities
				.Where(p => !p.DeletedTime.HasValue)
				.OrderByDescending(s => s.CreatedTime);

			// Count the total number of matching records
			int totalCount = await roleQuery.CountAsync();

			// Apply pagination
			List<ApplicationUserRoles> paginatedShops = await roleQuery
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

			// Map to RoleModelView
			List<AppUserRoleModelView> appUserModelViews = _mapper.Map<List<AppUserRoleModelView>>(paginatedShops);

			return new BasePaginatedList<AppUserRoleModelView>(appUserModelViews, totalCount, pageNumber, pageSize);
		}

		public async Task<AppUserRoleModelView> GetAppUserRoleAsync(string UserId, string RoleId)
		{
			if (string.IsNullOrWhiteSpace(UserId) && string.IsNullOrWhiteSpace(RoleId))
			{
				throw new Exception("Please provide a valid Application User Role ID.");
			}

			ApplicationUserRoles existingUserRole = await _unitOfWork.GetRepository<ApplicationUserRoles>().Entities
				.FirstOrDefaultAsync(s => s.UserId == Guid.Parse(UserId) && s.RoleId == Guid.Parse(RoleId) && !s.DeletedTime.HasValue)
				?? throw new Exception("The Application User Role cannot be found or has been deleted!");

			return _mapper.Map<AppUserRoleModelView>(existingUserRole);
		}

		public async Task<AppUserRoleModelView> UpdateAppUserRoleAsync(string UserId, string RoleId, UpdateAppUserRoleModelView model)
		{
			if (string.IsNullOrWhiteSpace(UserId) && string.IsNullOrWhiteSpace(RoleId))
			{
				throw new Exception("Please provide a valid Application User Role ID.");
			}

			ApplicationUserRoles existingUserRole = await _unitOfWork.GetRepository<ApplicationUserRoles>().Entities
				.FirstOrDefaultAsync(s => s.UserId == Guid.Parse(UserId) && s.RoleId == Guid.Parse(RoleId) && !s.DeletedTime.HasValue)
				?? throw new Exception("The Application User Role cannot be found or has been deleted!");

			_mapper.Map(model, existingUserRole);

			// Set additional properties
			existingUserRole.LastUpdatedBy = "claim account";
			existingUserRole.LastUpdatedTime = DateTimeOffset.UtcNow;

			_unitOfWork.GetRepository<ApplicationUserRoles>().Update(existingUserRole);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<AppUserRoleModelView>(existingUserRole);
		}
	}
}
