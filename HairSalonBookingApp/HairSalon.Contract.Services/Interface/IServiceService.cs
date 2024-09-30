using HairSalon.Core;
using HairSalon.ModelViews.ServiceModelViews;
using HairSalon.ModelViews.ShopModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
