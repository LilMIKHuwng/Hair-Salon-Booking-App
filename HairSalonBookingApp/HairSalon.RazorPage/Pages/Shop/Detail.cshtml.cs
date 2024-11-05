using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.RoleModelViews;
using HairSalon.ModelViews.ShopModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Shop
{
    public class DetailModel : PageModel
    {
        private readonly IShopService _shopService;

        public DetailModel(IShopService shopService)
        {
            _shopService = shopService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public ShopModelView ShopDetail { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ShopDetail = await _shopService.GetShopByIdAsync(Id);
            if (ShopDetail == null)
            {
                TempData["ErrorMessage"] = "Shop not found.";
                return RedirectToPage("/Shop/Index");
            }
            return Page();
        }
    }
}
