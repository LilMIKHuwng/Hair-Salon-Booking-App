using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ShopModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Shop
{
    public class ShopManagementModel : PageModel
    {
        private readonly IShopService _shopService;

        public ShopManagementModel(IShopService shopService)
        {
            _shopService = shopService;
        }

        public BasePaginatedList<ShopModelView> Shops { get; set; }

        public async Task OnGetAsync(int pageNumber = 1, int pageSize = 5, string? id = null, string? name = null)
        {
            Shops = await _shopService.GetAllShopAsync(pageNumber, pageSize, id, name);
        }
    }
}
