using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.AppointmentModelViews;
using HairSalon.ModelViews.RoleModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Appointment
{
    public class DetailModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;

        public DetailModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public AppointmentModelView Appointment { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
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

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" or "Manager" roles
            //if (!userRoles.Any(role => role == "Admin"))
            //{
            //    TempData["DeniedMessage"] = "You do not have permission to add a role.";
            //    return Page(); // Redirect to a different page with a denied message
            //}

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
