using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.RoleModelViews;
using HairSalon.ModelViews.ShopModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            Shop = await _shopService.GetShopByIdAsync(Id);
            if (Shop == null)
            {
                ErrorMessage = "Shop Not Found";
                return Redirect("/Shop/Index"); // Redirect if role is not found
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string response = await _shopService.DeleteShopAsync(Id);
            if (response == "Deleted shop successfully")
            {
                ResponseMessage = response;
                return Redirect("/Shop/Index");
            }
            // Set ErrorMessage if deletion fails
            ErrorMessage = response;
            return Page();
        }
    }
}
