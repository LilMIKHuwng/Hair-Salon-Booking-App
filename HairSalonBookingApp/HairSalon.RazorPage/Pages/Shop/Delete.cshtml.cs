using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ShopModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Shop
{
    public class DeleteModel : PageModel
    {
        private readonly IShopService _shopService;

        public DeleteModel(IShopService shopService)
        {
            _shopService = shopService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public ShopModelView Shop { get; set; }

        // Property to store error messages
        [TempData]
        public string ErrorMessage { get; set; }

        // Property to store response or success messages
        [TempData]
        public string ResponseMessage { get; set; }

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
                TempData["ErrorMessage"] = "Invalid Role ID.";
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

            Shop = await _shopService.GetShopByIdAsync(Id);
            if (Shop == null)
            {
                ErrorMessage = "Shop Not Found";
                return RedirectToPage("/Shop/Index"); // Redirect if role is not found
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = HttpContext.Session.GetString("UserId");
            string response = await _shopService.DeleteShopAsync(Id, userId);
            if (response == "Deleted shop successfully")
            {
                ResponseMessage = response;
                return RedirectToPage("/Shop/Index");
            }
            // Set ErrorMessage if deletion fails
            ErrorMessage = response;
            return Page();
        }
    }
}
