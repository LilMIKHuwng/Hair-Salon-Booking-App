using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
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


			UserInfo newUser = _mapper.Map<UserInfo>(model);

			newUser.Id = Guid.NewGuid().ToString("N");
			newUser.CreatedBy = "claim account";  
			newUser.CreatedTime = DateTimeOffset.UtcNow;
			newUser.LastUpdatedTime = DateTimeOffset.UtcNow;

			await _unitOfWork.GetRepository<UserInfo>().InsertAsync(newUser);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<UserModelView>(newUser);
		}

		public async Task<string> DeleteUserAsync(string id)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				throw new Exception("Please provide a valid User ID.");
			}

			UserInfo existingShop = await _unitOfWork.GetRepository<UserInfo>().Entities
				.FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
				?? throw new Exception("The User cannot be found or has been deleted!");

			existingShop.DeletedTime = DateTimeOffset.UtcNow;
			existingShop.DeletedBy = "claim account"; 

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

			int totalCount = await userQuery.CountAsync();

			List<UserInfo> paginatedShops = await userQuery
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

			List<UserModelView> userModelViews = _mapper.Map<List<UserModelView>>(paginatedShops);

			return new BasePaginatedList<UserModelView>(userModelViews, totalCount, pageNumber, pageSize);
		}

		public async Task<UserModelView> GetUserAsync(string id)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				throw new Exception("Please provide a valid User ID.");
			}

			UserInfo existingUser = await _unitOfWork.GetRepository<UserInfo>().Entities
				.FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
				?? throw new Exception("The User cannot be found or has been deleted!");

			return _mapper.Map<UserModelView>(existingUser);
		}

		public async Task<UserModelView> UpdateUserAsync(string id, UpdateUserModelView model)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				throw new Exception("Please provide a valid Shop ID.");
			}

			UserInfo existingUser = await _unitOfWork.GetRepository<UserInfo>().Entities
				.FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
				?? throw new Exception("The User cannot be found or has been deleted!");

			_mapper.Map(model, existingUser);

			existingUser.LastUpdatedBy = "claim account";  
			existingUser.LastUpdatedTime = DateTimeOffset.UtcNow;

			_unitOfWork.GetRepository<UserInfo>().Update(existingUser);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<UserModelView>(existingUser);
		}
	}
}
