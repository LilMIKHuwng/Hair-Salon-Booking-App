using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ServiceModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Service
{
    public class DeleteModel : PageModel
    {
        private readonly IServiceService _serviceService;

        public DeleteModel(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public ServiceModelView Service { get; set; }

        // Property to store response or success messages
        [TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Get roleId from TempData
            if (TempData.ContainsKey("ServiceId"))
            {
                Id = TempData["ServiceId"].ToString();
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

            Service = await _serviceService.GetServiceByIdAsync(Id);
            if (Service == null)
            {
                TempData["ErrorMessage"] = "Service Not Found.";
                return RedirectToPage("/Services/Index"); // Redirect if service is not found
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = HttpContext.Session.GetString("UserId");

            string response = await _serviceService.DeleteServiceAsync(Id, userId);
            if (response == "Service deleted successfully")
            {
                ResponseMessage = response;
                return RedirectToPage("/Services/Index");
            }

            // Set ErrorMessage if deletion fails
            TempData["ErrorMessage"] = response;
            return Page();
        }
    }
}
