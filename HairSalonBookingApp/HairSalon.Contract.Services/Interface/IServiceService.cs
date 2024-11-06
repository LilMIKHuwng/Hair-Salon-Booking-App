using HairSalon.Core;
using HairSalon.ModelViews.ServiceModelViews;

namespace HairSalon.Contract.Services.Interface
{
    public interface IServiceService
    {
        Task<BasePaginatedList<ServiceModelView>> GetAllServiceAsync(int pageNumber, int pageSize, string? id, string? name, string? type);

		Task<string> AddServiceAsync(CreateServiceModelView model);

        Task<string> UpdateServiceAsync(string id, UpdatedServiceModelView model);

        Task<string> DeleteServiceAsync(string id);

        Task<IEnumerable<ServiceModelView>> GetByIdsAsync(string[] ids);

		Task<List<ServiceModelView>> GetAllServiceAsync();

        Task<List<ServiceModelView>> GetAllServicesAsync();

	}
}
