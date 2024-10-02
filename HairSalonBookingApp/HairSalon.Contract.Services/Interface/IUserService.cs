using HairSalon.Core;
using HairSalon.ModelViews.UserModelViews;

namespace HairSalon.Contract.Services.Interface
{
    public interface IUserService
    {
        Task<IList<UserResponseModel>> GetAll();
        
		Task<BasePaginatedList<UserModelView>> GetAllUserAsync(int pageNumber, int pageSize);

		Task<UserModelView> AddUserAsync(CreateUserModelView model);
		Task<UserModelView> UpdateUserAsync(string id, UpdateUserModelView model);
		Task<string> DeleteUserAsync(string id);
		Task<UserModelView> GetUserAsync(string id);
	}
}
