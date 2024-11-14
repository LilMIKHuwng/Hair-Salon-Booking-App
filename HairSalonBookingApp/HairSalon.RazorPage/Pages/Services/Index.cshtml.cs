using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ServiceModelViews;
using HairSalon.Core;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Service
{
    public class ServiceModel : PageModel
    {
        private readonly IServiceService _serviceService;

        public ServiceModel(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public BasePaginatedList<ServiceModelView> Services { get; set; }


        public async Task<IActionResult> OnGetAsync(int pageNumber = 1, int pageSize = 5, string? id = null, string? name = null, string? type = null)
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
                return RedirectToPage("/Error");
            }

            // If authorized, retrieve roles data
            Services = await _serviceService.GetAllServiceAsync(pageNumber, pageSize, id, name, type);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id, string action)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["ErrorMessage"] = "Service ID is required.";
                return RedirectToPage();
            }

            //Save roleId to tempdata
            TempData["ServiceId"] = id;

            switch (action?.ToLower())
            {
                case "update":
                    return RedirectToPage("/Services/Update");
                case "detail":
                    return RedirectToPage("/Services/Detail");
                case "delete":
                    return RedirectToPage("/Services/Delete");
                default:
                    TempData["ErrorMessage"] = "Invalid action.";
                    return RedirectToPage();
            }
        }
    }
}
