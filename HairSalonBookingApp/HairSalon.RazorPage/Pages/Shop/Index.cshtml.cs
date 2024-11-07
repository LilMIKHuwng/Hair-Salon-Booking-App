using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ShopModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

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

        public async Task<IActionResult> OnGetAsync(int pageNumber = 1, int pageSize = 5, string? id = null, string? name = null)
        {
            var userRolesJson = HttpContext.Session.GetString("UserRoles");

            if (userRolesJson != null)
            {
                var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

                // Check if the user has "Admin" or "Manager" roles
                if (!userRoles.Any(role => role == "Admin"))
                {
                    TempData["ErrorMessage"] = "You do not have permission to view this page.";
                    return Page(); // Show error message on the same page
                }
            }
            else
            {
                TempData["ErrorMessage"] = "You do not have permission to view this page.";
                return Page();
            }
            Shops = await _shopService.GetAllShopAsync(pageNumber, pageSize, id, name);
            return Page();
        }
    }
}