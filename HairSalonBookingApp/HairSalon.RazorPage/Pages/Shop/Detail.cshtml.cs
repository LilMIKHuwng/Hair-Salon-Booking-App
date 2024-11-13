using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ShopModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

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
            // Get roleId from TempData
            if (TempData.ContainsKey("ShopId"))
            {
                Id = TempData["ShopId"].ToString();
            }

            // Check if Id is provided
            if (string.IsNullOrEmpty(Id))
            {
                TempData["ErrorMessage"] = "Invalid Shop ID.";
                return RedirectToPage("/Error"); // Redirect to error page if Id is missing
            }

            // Retrieve user roles from session
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return Page();// Redirect to a different page with a denied message
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" or "Manager" roles
            if (!userRoles.Any(role => role == "Admin"))
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return Page(); // Redirect to a different page with a denied message
            }

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
