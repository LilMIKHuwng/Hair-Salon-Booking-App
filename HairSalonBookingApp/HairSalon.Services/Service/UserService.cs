using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.Core.Utils;
using HairSalon.ModelViews.ShopModelViews;
using HairSalon.ModelViews.UserModelViews;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Services.Service
{
    public class UserService : IUserService
    {
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public UserService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<UserModelView> AddUserAsync(CreateUserModelView model)
		{
			if (string.IsNullOrWhiteSpace(model.FullName))
			{
				throw new Exception("First Name cannot be empty.");
			}


			// Mapping from CreateShopModelView to Shop entity
			UserInfo newUser = _mapper.Map<UserInfo>(model);

			// Set additional properties
			newUser.Id = Guid.NewGuid().ToString("N");
			newUser.CreatedBy = "claim account";  // Replace with actual authenticated user
			newUser.CreatedTime = DateTimeOffset.UtcNow;
			newUser.LastUpdatedTime = DateTimeOffset.UtcNow;

			await _unitOfWork.GetRepository<UserInfo>().InsertAsync(newUser);
			await _unitOfWork.SaveAsync();

			// Map back to ShopModelView and return
			return _mapper.Map<UserModelView>(newUser);
		}

		public async Task<string> DeleteUserAsync(string id)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				throw new Exception("Please provide a valid User ID.");
			}

			// Find the shop
			UserInfo existingShop = await _unitOfWork.GetRepository<UserInfo>().Entities
				.FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
				?? throw new Exception("The User cannot be found or has been deleted!");

			// Perform soft delete
			existingShop.DeletedTime = DateTimeOffset.UtcNow;
			existingShop.DeletedBy = "claim account";  // Replace with actual authenticated user

			_unitOfWork.GetRepository<UserInfo>().Update(existingShop);
			await _unitOfWork.SaveAsync();
			return "Deleted";
		}

		public Task<IList<UserResponseModel>> GetAll()
        {
            IList<UserResponseModel> users = new List<UserResponseModel>
            {
                new UserResponseModel { Id = "1" },
                new UserResponseModel { Id = "2" },
                new UserResponseModel { Id = "3" }
            };

            return Task.FromResult(users);
        }
		
		public async Task<BasePaginatedList<UserModelView>> GetAllUserAsync(int pageNumber, int pageSize)
		{
			IQueryable<UserInfo> userQuery = _unitOfWork.GetRepository<UserInfo>().Entities
				.Where(p => !p.DeletedTime.HasValue)
				.OrderByDescending(s => s.CreatedTime);

			// Count the total number of matching records
			int totalCount = await userQuery.CountAsync();

			// Apply pagination
			List<UserInfo> paginatedShops = await userQuery
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

			// Map to ShopModelView
			List<UserModelView> userModelViews = _mapper.Map<List<UserModelView>>(paginatedShops);

			return new BasePaginatedList<UserModelView>(userModelViews, totalCount, pageNumber, pageSize);
		}

		public async Task<UserModelView> GetUserAsync(string id)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				throw new Exception("Please provide a valid User ID.");
			}

			// Find the shop
			UserInfo existingUser = await _unitOfWork.GetRepository<UserInfo>().Entities
				.FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
				?? throw new Exception("The User cannot be found or has been deleted!");

			// Map to ShopModelView and return
			return _mapper.Map<UserModelView>(existingUser);
		}

		public async Task<UserModelView> UpdateUserAsync(string id, UpdateUserModelView model)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				throw new Exception("Please provide a valid Shop ID.");
			}

			// Find the existing shop
			UserInfo existingUser = await _unitOfWork.GetRepository<UserInfo>().Entities
				.FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
				?? throw new Exception("The User cannot be found or has been deleted!");

			// Mapping from UpdatedShopModel to existing Shop entity
			_mapper.Map(model, existingUser);

			// Set additional properties
			existingUser.LastUpdatedBy = "claim account";  // Replace with actual authenticated user
			existingUser.LastUpdatedTime = DateTimeOffset.UtcNow;

			_unitOfWork.GetRepository<UserInfo>().Update(existingUser);
			await _unitOfWork.SaveAsync();

			// Map back to ShopModelView and return
			return _mapper.Map<UserModelView>(existingUser);
		}
	}
}
