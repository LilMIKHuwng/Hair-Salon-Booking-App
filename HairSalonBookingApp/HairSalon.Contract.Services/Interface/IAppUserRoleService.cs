using HairSalon.Core;
using HairSalon.ModelViews.AppUserRoleViewModels;

namespace HairSalon.Contract.Services.Interface
{
    public interface IAppUserRoleService
    {
        Task<BasePaginatedList<AppUserRoleModelView>> GetAllAppUserRoleAsync(int pageNumber, int pageSize, string? userId, string? roleId);
        Task<string> AddAppUserRoleAsync(CreateAppUserRoleModelView model);
        Task<string> UpdateAppUserRoleAsync(string UserId, string RoleId, UpdateAppUserRoleModelView model);
        Task<string> DeleteAppUserRoleAsync(string UserId, string RoleId);
    }
}
