using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.PromotionModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Promotion
{
    public class DeleteModel : PageModel
    {
        private readonly IPromotionService _promotionService;

        public DeleteModel(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public PromotionModelView Promotion { get; set; }

        // Property to store response or success messages
        [TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Get roleId from TempData
            if (TempData.ContainsKey("PromotionId"))
            {
                Id = TempData["PromotionId"].ToString();
            }

            // Check if Id is provided
            if (string.IsNullOrEmpty(Id))
            {
                TempData["ErrorMessage"] = "Invalid Service ID.";
                return RedirectToPage("/Error"); // Redirect to error page if Id is missing
            }

            // Retrieve user roles from session
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission to delete a service.";
                return Page(); // Show denied message if user roles are missing
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" or "Manager" roles
            if (!userRoles.Any(role => role == "Admin" || role == "Manager"))
            {
                TempData["DeniedMessage"] = "You do not have permission to delete a service.";
                return Page(); // Show denied message if user lacks permissions
            }

            Promotion = await _promotionService.GetPromotionByIdAsync(Id);
            if (Promotion == null)
            {
                TempData["ErrorMessage"] = "Service Not Found.";
                return RedirectToPage("/Services/Index"); // Redirect if service is not found
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = HttpContext.Session.GetString("UserId");

            string response = await _promotionService.DeletePromotionAsync(Id, userId);
            if (response == "Promotion successfully deleted")
            {
                ResponseMessage = response;
                return RedirectToPage("/Promotion/Index");
            }

            // Set ErrorMessage if deletion fails
            TempData["ErrorMessage"] = response;
            return Page();
        }
    }
}
