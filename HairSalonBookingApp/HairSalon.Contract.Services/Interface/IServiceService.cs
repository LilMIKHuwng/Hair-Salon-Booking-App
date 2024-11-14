using HairSalon.Core;
using HairSalon.ModelViews.ServiceModelViews;

namespace HairSalon.Contract.Services.Interface
{
    public interface IServiceService
    {
        Task<BasePaginatedList<ServiceModelView>> GetAllServiceAsync(int pageNumber, int pageSize, string? id, string? name, string? type);

        Task<IEnumerable<ServiceModelView>> GetByIdsAsync(string[] ids);

		Task<List<ServiceModelView>> GetAllServiceAsync();

        Task<List<ServiceModelView>> GetAllServicesAsync();
        Task<string> AddServiceAsync(CreateServiceModelView model, string? userId);

        Task<string> UpdateServiceAsync(string id, UpdatedServiceModelView model, string userId);

        Task<string> DeleteServiceAsync(string id, string? userId);

        Task<ServiceModelView?> GetServiceByIdAsync(string id);

    }
}
