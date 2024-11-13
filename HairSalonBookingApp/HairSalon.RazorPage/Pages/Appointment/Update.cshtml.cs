using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ApplicationUserModelViews;
using HairSalon.ModelViews.AppointmentModelViews;
using HairSalon.ModelViews.ComboModelViews;
using HairSalon.ModelViews.ServiceModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Appointment
{
    public class UpdateModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IServiceService _serviceService;
        private readonly IComboService _comboService;
        private readonly IAppUserService _appUserService;

        public UpdateModel(IAppointmentService appointmentService, IServiceService serviceService, IComboService comboService, IAppUserService appUserService)
        {
            _appointmentService = appointmentService;
            _serviceService = serviceService;
            _comboService = comboService;
            _appUserService = appUserService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public AppointmentModelView Appointment { get; set; }

        [BindProperty]
        public UpdateAppointmentModelView UpdateAppointment { get; set; }
        public List<ServiceModelView> Services { get; set; }
        public List<ComboModelView> Combos { get; set; }
        public List<AppUserModelView> Stylists { get; set; }
        public List<ComboAppointment> ComboAppointment { get; set; }
        public List<ServiceAppointment> ServiceAppointment { get; set; }

        [TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
			// Get Id from TempData
			if (TempData.ContainsKey("AppointmentId"))
			{
				Id = TempData["AppointmentId"].ToString();
			}

			if (string.IsNullOrEmpty(Id))
            {
                TempData["ErrorMessage"] = "Invalid Appointment ID.";
                return RedirectToPage("/Error"); 
            }

            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null || !JsonConvert.DeserializeObject<List<string>>(userRolesJson)
                .Any(role => role == "Admin" || role == "Manager" || role == "User"))
            {
				TempData["DeniedMessage"] = "You do not have permission to update a appointment.";
				return Page(); // Redirect to a different page with a denied message
			}

            Appointment = await _appointmentService.GetAppointmentByIdAsync(Id);
            if (Appointment == null)
            {
                TempData["ErrorMessage"] = "Appointment not found.";
                return RedirectToPage("/Appointment/Index");
            }

            Services = await _serviceService.GetAllServicesAsync();
            Combos = await _comboService.GetAllComboAsync();
            Stylists = await _appUserService.GetAllStylistAsync();
            ComboAppointment = await _appointmentService.GetAllComboAppointment(Id);
            ServiceAppointment = await _appointmentService.GetAllServiceAppointment(Id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = HttpContext.Session.GetString("UserId");

            if (userId == null)
            {
                TempData["ErrorMessage"] = "User is not logged in.";
                return RedirectToPage("/Appointment/Index");
            }
            
            string response = await _appointmentService.UpdateAppointmentAsync(Id, UpdateAppointment, userId);
            if (response == "Appointment updated successfully.")
            {
                ResponseMessage = response;
                return RedirectToPage("/Appointment/Index");
            }
            else 
            {
                TempData["ErrorMessage"] = response;

                Services = await _serviceService.GetAllServicesAsync();
                Combos = await _comboService.GetAllComboAsync();
                Stylists = await _appUserService.GetAllStylistAsync();
                ComboAppointment = await _appointmentService.GetAllComboAppointment(Id);
                ServiceAppointment = await _appointmentService.GetAllServiceAppointment(Id);
            }

            return Page();
        }
    }
}
