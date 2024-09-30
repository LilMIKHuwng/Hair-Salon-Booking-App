using HairSalon.Core;
using HairSalon.ModelViews.RoleModelViews;

namespace HairSalon.Contract.Services.Interface
{
    public interface IRoleService
    {
        Task<BasePaginatedList<RoleModelView>> GetAllRoleAsync(int pageNumber, int pageSize);
        Task<RoleModelView> AddRoleAsync(CreateRoleModelView model, string createdBy, string lastUpdatedBy);
        Task<RoleModelView> UpdateRoleAsync(string id, UpdatedRoleModelView model, string lastUpdatedBy);
        Task<string> DeleteRoleAsync(string id, string deletedBy);
    }
}
