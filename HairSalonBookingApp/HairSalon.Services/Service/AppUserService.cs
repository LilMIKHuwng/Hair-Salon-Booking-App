using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.Core.Utils;
using HairSalon.ModelViews.ApplicationUserModelViews;
using HairSalon.ModelViews.RoleModelViews;
using HairSalon.Repositories.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Services.Service
{
	public class AppUserService : IAppUserService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public AppUserService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<AppUserModelView> AddAppUserAsync(CreateAppUserModelView model)
		{
			if (string.IsNullOrWhiteSpace(model.UserInfoId))
			{
				throw new Exception("User ID cannot be empty.");
			}

			UserInfo existingUser = await _unitOfWork.GetRepository<UserInfo>().Entities
				.FirstOrDefaultAsync(s => s.Id == model.UserInfoId && !s.DeletedTime.HasValue)
				?? throw new Exception("The User cannot be found or has been deleted!");

			ApplicationUser newUser = _mapper.Map<ApplicationUser>(model);

			newUser.UserName = existingUser.FullName;
			newUser.CreatedBy = "claim account";
			newUser.CreatedTime = DateTimeOffset.UtcNow;
			newUser.LastUpdatedTime = DateTimeOffset.UtcNow;

			await _unitOfWork.GetRepository<ApplicationUser>().InsertAsync(newUser);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<AppUserModelView>(newUser);
		}

		public async Task<string> DeleteAppUserAsync(string id)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				throw new Exception("Please provide a valid Application User ID.");
			}

			ApplicationUser existingUser = await _unitOfWork.GetRepository<ApplicationUser>().Entities
				.FirstOrDefaultAsync(s => s.Id == Guid.Parse(id) && !s.DeletedTime.HasValue)
				?? throw new Exception("The Application User cannot be found or has been deleted!");

			existingUser.DeletedTime = DateTimeOffset.UtcNow;
			existingUser.DeletedBy = "claim account";

			_unitOfWork.GetRepository<ApplicationUser>().Update(existingUser);
			await _unitOfWork.SaveAsync();
			return "Deleted";
		}

		public async Task<BasePaginatedList<AppUserModelView>> GetAllAppUserAsync(int pageNumber, int pageSize)
		{
			IQueryable<ApplicationUser> roleQuery = _unitOfWork.GetRepository<ApplicationUser>().Entities
				.Where(p => !p.DeletedTime.HasValue)
				.OrderByDescending(s => s.CreatedTime);

			// Count the total number of matching records
			int totalCount = await roleQuery.CountAsync();

			// Apply pagination
			List<ApplicationUser> paginatedShops = await roleQuery
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

			// Map to RoleModelView
			List<AppUserModelView> appUserModelViews = _mapper.Map<List<AppUserModelView>>(paginatedShops);

			return new BasePaginatedList<AppUserModelView>(appUserModelViews, totalCount, pageNumber, pageSize);
		}

		public async Task<AppUserModelView> GetAppUserAsync(string id)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				throw new Exception("Please provide a valid Application User ID.");
			}

			ApplicationUser existingUser = await _unitOfWork.GetRepository<ApplicationUser>().Entities
				.FirstOrDefaultAsync(s => s.Id == Guid.Parse(id) && !s.DeletedTime.HasValue)
				?? throw new Exception("The Application User cannot be found or has been deleted!");

			return _mapper.Map<AppUserModelView>(existingUser);
		}

		public async Task<AppUserModelView> UpdateAppUserAsync(string id, UpdateAppUserModelView model)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				throw new Exception("Please provide a valid Application User ID.");
			}

			ApplicationUser existingUser = await _unitOfWork.GetRepository<ApplicationUser>().Entities
				.FirstOrDefaultAsync(s => s.Id == Guid.Parse(id) && !s.DeletedTime.HasValue)
				?? throw new Exception("The Application User cannot be found or has been deleted!");

			UserInfo existingUserInfo = await _unitOfWork.GetRepository<UserInfo>().Entities
				.FirstOrDefaultAsync(s => s.Id == model.UserInfoId && !s.DeletedTime.HasValue)
				?? throw new Exception("The User cannot be found or has been deleted!");

			_mapper.Map(model, existingUser);

			// Set additional properties
			existingUser.UserName = existingUserInfo.FullName;
			existingUser.LastUpdatedBy = "claim account";
			existingUser.LastUpdatedTime = DateTimeOffset.UtcNow;

			_unitOfWork.GetRepository<ApplicationUser>().Update(existingUser);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<AppUserModelView>(existingUser);
		}
	}
}
