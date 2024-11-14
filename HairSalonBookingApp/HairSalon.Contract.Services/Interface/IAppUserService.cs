using HairSalon.Core;
using HairSalon.ModelViews.ApplicationUserModelViews;
using HairSalon.ModelViews.AuthModelViews;
using HairSalon.ModelViews.SalaryPaymentModelViews;
using HairSalon.ModelViews.ShopModelViews;
using HairSalon.Repositories.Entity;

namespace HairSalon.Contract.Services.Interface
{
	public interface IAppUserService
	{
		Task<BasePaginatedList<AppUserModelView>> GetAllAppUserAsync(string? userId, int pageNumber, int pageSize);
		Task<string> AddAppUserAsync(CreateAppUserModelView model);
        Task<string> AddAppStylistAsync(CreateAppStylistModelView model);
        Task<string> UpdateAppUserAsync(string id, UpdateAppUserModelView model);
		Task<string> DeleteAppUserAsync(string id);
		Task<ApplicationUsers> AuthenticateAsync(LoginModelView model);
        Task<string> ConfirmEmailAsync(ConfirmEmailModelView model);
        Task<string> ForgotPasswordAsync(ForgotPasswordModelView model);
        Task<string> ResetPasswordAsync(ResetPasswordModelView model);
        Task<string> ResetPasswordAdminAsync(ResetPasswordAdminModelView model);
        Task<GetInforAppUserModelView> GetMyInforUsersAsync(string username);
        Task<List<AppUserModelView>> GetAllStylistAsync();
        Task<List<AppUserModelView>> GetUsersByRoleAsync(string roleName);
        Task<AppUserModelView?> GetUserByIdAsync(string id);
    }
}
