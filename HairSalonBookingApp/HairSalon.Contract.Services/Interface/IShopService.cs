using HairSalon.Core;
using HairSalon.ModelViews.ShopModelViews;

namespace HairSalon.Contract.Services.Interface
{
    public interface IShopService
    {
        Task<BasePaginatedList<ShopModelView>> GetAllShopAsync(int pageNumber, int pageSize, string? searchName, string? searchId);
        Task<string> AddShopAsync(CreateShopModelView model, string? userId);
        Task<string> UpdateShopAsync(string id, UpdatedShopModelView model, string? userId);
        Task<string> DeleteShopAsync(string id, string? userId);
        Task<ShopModelView?> GetShopByIdAsync(string id);
    }
}
