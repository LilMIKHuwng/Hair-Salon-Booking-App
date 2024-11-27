using DocumentFormat.OpenXml.Office2010.Excel;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.AppointmentModelViews;
using HairSalon.Services.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Payment
{
    public class PaymentSelectionModel : PageModel
    {

        private readonly IAppointmentService _appointmentService;
        private readonly IServiceService _serviceService;

        public PaymentSelectionModel(IAppointmentService appointmentService, IServiceService serviceService)
        {
            _appointmentService = appointmentService;
            _serviceService = serviceService;
        }
        public AppointmentModelView Appointment { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public async Task<IActionResult> OnGet()
        {
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

            return Page();
        }
    }
}
