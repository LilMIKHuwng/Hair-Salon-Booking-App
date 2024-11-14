using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ServiceModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Service
{
    public class UpdateModel : PageModel
    {
        private readonly IServiceService _serviceService;

        public UpdateModel(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        [BindProperty]
        public ServiceModelView Service { get; set; }

        [BindProperty] // Bind UpdatedService to be populated from the form
        public UpdatedServiceModelView UpdatedService { get; set; }

        [TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Get roleId from TempData
            if (TempData.ContainsKey("ServiceId"))
            {
                Id = TempData["ServiceId"].ToString();
            }

            if (string.IsNullOrEmpty(Id))
            {
                TempData["ErrorMessage"] = "Invalid Service ID.";
                return RedirectToPage("/Error"); 
            }

            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission to update a service.";
                return RedirectToPage("/Error");// Redirect to a different page with a denied message
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            if (!userRoles.Any(role => role == "Admin"))
            {
                TempData["DeniedMessage"] = "You do not have permission to update a service.";
                return Page(); // Redirect to a different page with a denied message
            }

            Service = await _serviceService.GetServiceByIdAsync(Id);
            if (Service == null)
            {
                TempData["ErrorMessage"] = "Service not found.";
                return RedirectToPage("/Services/Index");
            }

            // Initialize UpdatedService with existing service name for display in the form
            UpdatedService = new UpdatedServiceModelView
            {
                Name = Service.Name,
                Type = Service.Type,
                Price = Service.Price,
                Description = Service.Description,  
                TimeService = Service.TimeService,  
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = HttpContext.Session.GetString("UserId");

            var response = await _serviceService.UpdateServiceAsync(Id, UpdatedService, userId);
            if (response == "Service updated successfully")
            {
                ResponseMessage = response;
                return RedirectToPage("/Services/Index");
            }

            TempData["ErrorMessage"] = response;
            return Page();
        }
    }
}
