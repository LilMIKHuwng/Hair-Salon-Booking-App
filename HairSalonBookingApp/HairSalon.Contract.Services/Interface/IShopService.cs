using HairSalon.Contract.Repositories.Entity;
using HairSalon.Core;
using HairSalon.ModelViews.ShopModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Contract.Services.Interface
{
    public interface IShopService
    {
        Task<BasePaginatedList<ShopModelView>> GetAllShopAsync(int pageNumber, int pageSize);

        Task<ShopModelView> AddShopAsync(CreateShopModelView model);
        Task<ShopModelView> UpdateShopAsync(string id, UpdatedShopModelView model);
        Task<string> DeleteShopAsync(string id);
        Task<ShopModelView> GetShopAsync(string id);

    }
}
