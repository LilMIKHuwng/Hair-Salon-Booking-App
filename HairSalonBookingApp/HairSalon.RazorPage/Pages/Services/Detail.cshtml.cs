using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ServiceModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Service
{
    public class DetailModel : PageModel
    {
        private readonly IServiceService _serviceService;

        public DetailModel(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public ServiceModelView ServiceDetail { get; set; }

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
                TempData["DeniedMessage"] = "You do not have permission to view this service.";
                return Page(); // Show denied message if user roles are missing
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" or "Manager" roles
            if (!userRoles.Any(role => role == "Admin"))
            {
                TempData["DeniedMessage"] = "You do not have permission to view this service.";
                return Page(); // Show denied message if user lacks permissions
            }

            ServiceDetail = await _serviceService.GetServiceByIdAsync(Id);
            if (ServiceDetail == null)
            {
                TempData["ErrorMessage"] = "Service not found.";
                return RedirectToPage("/Services/Index");
            }
            return Page();
        }
    }
}
