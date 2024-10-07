using HairSalon.Core;
using HairSalon.ModelViews.ShopModelViews;

namespace HairSalon.Contract.Services.Interface
{
    public interface IShopService
    {
        Task<BasePaginatedList<ShopModelView>> GetAllShopAsync(int pageNumber, int pageSize, string searchName, string searchId);
        Task<string> AddShopAsync(CreateShopModelView model);
        Task<string> UpdateShopAsync(string id, UpdatedShopModelView model);
        Task<string> DeleteShopAsync(string id);
        Task<ShopModelView> GetShopAsync(string id);

    }
}
