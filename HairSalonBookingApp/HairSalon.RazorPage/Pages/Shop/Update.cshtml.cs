using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.RoleModelViews;
using HairSalon.ModelViews.ShopModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Shop
{
    public class UpdateModel : PageModel
    {
        private readonly IShopService _shopService;

        public UpdateModel(IShopService shopService)
        {
            _shopService = shopService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        [BindProperty]
        public ShopModelView Shop { get; set; }

        [BindProperty] // Bind UpdatedRole to be populated from the form
        public UpdatedShopModelView UpdatedShop { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

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
                ErrorMessage = "Shop not found.";
                return RedirectToPage("/Shop/Index");
            }

            // Initialize UpdatedRole with existing role name for display in the form
            UpdatedShop = new UpdatedShopModelView
            {
                Name = Shop.Name,
                Address = Shop.Address,
                ShopEmail = Shop.ShopEmail,
                ShopPhone = Shop.ShopPhone,
                OpenTime = Shop.OpenTime,
                CloseTime = Shop.CloseTime,
                Title = Shop.Title
                // ShopImage can be set later if needed, as it is a file input in the form.
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = HttpContext.Session.GetString("UserId");
            var response = await _shopService.UpdateShopAsync(Id, UpdatedShop, userId);
            if (response == "Updated shop successfully")
            {
                ResponseMessage = response;
                return RedirectToPage("/Shop/Index");
            }

            ErrorMessage = response;
            return Page();
        }
    }
}
