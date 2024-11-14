using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.AppointmentModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Appointment
{
    public class DeleteModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;

        public DeleteModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public AppointmentModelView Appointment { get; set; }

        // Property to store response or success messages
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

			// Retrieve user roles from session
			var userRolesJson = HttpContext.Session.GetString("UserRoles");
			if (userRolesJson == null)
			{
				TempData["ErrorMessage"] = "You do not have permission to delete a appointment.";
				return RedirectToPage("/Error");
			}

			var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" or "Manager" or "User" roles
            if (!userRoles.Any(role => role == "Admin" || role == "Manager" || role == "User"))
            {
                TempData["DeniedMessage"] = "You do not have permission to delete a appointment.";
                return Page(); // Redirect to a different page with a denied message
            }

            Appointment = await _appointmentService.GetAppointmentByIdAsync(Id);
            if (Appointment == null)
            {
                TempData["ErrorMessage"] = "Appointment Not Found";
                return RedirectToPage("/Appointment/Index"); // Redirect if appointment is not found
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = HttpContext.Session.GetString("UserId");

            string response = await _appointmentService.DeleteAppointmentAsync(Id, userId);
            if (response == "Appointment deleted successfully.")
            {
                ResponseMessage = response;
                return RedirectToPage("/Appointment/Index");
            }
            // Set ErrorMessage if deletion fails
            TempData["ErrorMessage"] = response;
            return Page();
        }
    }
}
