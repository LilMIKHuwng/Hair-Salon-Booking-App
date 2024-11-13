using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.AppointmentModelViews;
using HairSalon.ModelViews.ComboModelViews;
using HairSalon.ModelViews.ServiceModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Appointment
{
    public class DetailModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IServiceService _serviceService;
        private readonly IComboService _comboService;

        public DetailModel(IAppointmentService appointmentService, IServiceService serviceService, IComboService comboService)
        {
            _appointmentService = appointmentService;
            _serviceService = serviceService;
            _comboService = comboService;
        }

        public List<ComboAppointment> ComboAppointment { get; set; }
        public List<ServiceAppointment> ServiceAppointment { get; set; }
        public List<ServiceModelView> Services { get; set; }
        public List<ComboModelView> Combos { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public AppointmentModelView Appointment { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
			// Get Id from TempData
			if (TempData.ContainsKey("AppointmentId"))
			{
				Id = TempData["AppointmentId"].ToString();
			}

			// Check if Id is provided
			if (string.IsNullOrEmpty(Id))
            {
                TempData["ErrorMessage"] = "Invalid Appointment ID.";
                return RedirectToPage("/Error"); // Redirect to error page if Id is missing
            }

            // Retrieve user roles from session
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission to add a role.";
                return Page();// Redirect to a different page with a denied message
            }

            Appointment = await _appointmentService.GetAppointmentByIdAsync(Id);
            if (Appointment == null)
            {
                TempData["ErrorMessage"] = "Role not found.";
                return RedirectToPage("/Role/Index");
            }

            ComboAppointment = await _appointmentService.GetAllComboAppointment(Id);
            ServiceAppointment = await _appointmentService.GetAllServiceAppointment(Id);
            Services = await _serviceService.GetAllServicesAsync();
            Combos = await _comboService.GetAllComboAsync();

            return Page();
        }
    }
}
