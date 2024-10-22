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
        Task<BasePaginatedList<StatisticalServiceModelView>> MonthlyServiceStatistics(int pageNumber, int pageSize, int? year, int? month);
    }
}
