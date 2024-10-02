using HairSalon.Core;
using HairSalon.ModelViews.ServiceModelViews;

namespace HairSalon.Contract.Services.Interface
{
    public interface IServiceService
    {
        Task<BasePaginatedList<ServiceModelView>> GetAllServiceAsync(int pageNumber, int pageSize);
        Task<ServiceModelView> AddServiceAsync(CreateServiceModelView model);
        Task<ServiceModelView> UpdateServiceAsync(string id, UpdatedServiceModelView model);
        Task<string> DeleteServiceAsync(string id);
        Task<ServiceModelView> GetServiceAsync(string id);
    }
}
