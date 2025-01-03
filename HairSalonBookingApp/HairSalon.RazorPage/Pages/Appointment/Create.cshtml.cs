using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ApplicationUserModelViews;
using HairSalon.ModelViews.AppointmentModelViews;
using HairSalon.ModelViews.ComboModelViews;
using HairSalon.ModelViews.PromotionModelViews;
using HairSalon.ModelViews.ServiceModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Appointment
{
    public class CreateModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IServiceService _serviceService;
        private readonly IComboService _comboService;
        private readonly IAppUserService _appUserService;
        private readonly IPromotionService _promotionService;

        public CreateModel(IAppointmentService appointmentService, IServiceService serviceService, IComboService comboService, IAppUserService appUserService, IPromotionService promotionService)
        {
            _appointmentService = appointmentService;
            _serviceService = serviceService;
            _comboService = comboService;
            _appUserService = appUserService;
            _promotionService = promotionService;
        }

        [BindProperty]
        public CreateAppointmentModelView NewAppointment { get; set; }
        public List<ServiceModelView> Services { get; set; } 
        public List<ComboModelView> Combos { get; set; } 
        public List<AppUserModelView> Stylists { get; set; } 
        public List<PromotionModelView> Promotions { get; set; }

		// Property to store response or success messages
		[TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int pageNumber = 1, int pageSize = 5)
        {
            // Retrieve user roles from session
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
				TempData["ErrorMessage"] = "You do not have permission to add a appointment.";
				return RedirectToPage("/Error");
			}

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" or "Manager" or "User" roles
            if (!userRoles.Any(role => role == "Admin" || role == "Manager" || role == "User"))
            {
                TempData["DeniedMessage"] = "You do not have permission to add a appointment.";
                return Page(); // Redirect to a different page with a denied message
            }

            //get list services, combos, stylists
            Services = await _serviceService.GetAllServicesAsync();
            Combos = await _comboService.GetAllComboAsync();
            Stylists = await _appUserService.GetAllStylistAsync();
            Promotions = await _promotionService.GetAllPromotionAsync();

            return Page(); // Allow access to the page if the user has the correct role
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetString("UserId");

                string response = await _appointmentService.AddAppointmentAsync(NewAppointment, userId);
                if (response.Contains("Appointment successfully created."))
                {
					// Extract the Id from the response
					var responseParts = response.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
					var appointmentId = responseParts[^1]; 

					ResponseMessage = "Appointment successfully created.";
					TempData["AppointmentId"] = appointmentId; 
					return RedirectToPage("/Appointment/Detail"); 
				}
                else
                {
                    // Set ErrorMessage if there�s an error
                    TempData["ErrorMessage"] = response;

                    // Retrieve services, combos, and stylists to display on the page
                    Services = await _serviceService.GetAllServicesAsync();
                    Combos = await _comboService.GetAllComboAsync();
                    Stylists = await _appUserService.GetAllStylistAsync();
					Promotions = await _promotionService.GetAllPromotionAsync();
				}
            }

            return Page(); // Return the same page in case of validation errors or other issues
        }

    }
}
