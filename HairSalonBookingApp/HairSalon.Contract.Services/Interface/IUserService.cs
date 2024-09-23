using HairSalon.ModelViews.UserModelViews;

namespace HairSalon.Contract.Services.Interface
{
    public interface IUserService
    {
        Task<IList<UserResponseModel>> GetAll();
    }
}
