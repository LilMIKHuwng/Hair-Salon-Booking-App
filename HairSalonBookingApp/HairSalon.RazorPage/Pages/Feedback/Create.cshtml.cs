using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.AppointmentModelViews;
using HairSalon.ModelViews.FeedBackModeViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Feedback
{
    public class CreateModel : PageModel
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IAppointmentService _appointmentService;

        public CreateModel(IFeedbackService feedbackService, IAppointmentService appointmentService)
        {
            _feedbackService = feedbackService;
            _appointmentService = appointmentService;
        }

        [BindProperty]
        public CreateFeedbackModelView NewFeedback { get; set; }

        [TempData]
        public string ResponseMessage { get; set; }

        public List<FeedBackModelView> Feedbacks { get; set; }
        public List<AppointmentModelView> Appointments { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            // Retrieve user roles from session
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return RedirectToPage("/Error");
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has the "Admin" role
            if (!userRoles.Any(role => role == "Admin" || role == "Manager" || role == "User" || role == "Stylist"))
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return Page();
            }

            // Retrieve all feedbacks and appointments
            var feedbacks = await _feedbackService.GetAllFeedbackAsync(1, int.MaxValue, null, null); // Use appropriate parameters here
            var allAppointments = await _appointmentService.GetAppointmentsForDropdownAsync() ?? new List<AppointmentModelView>();

            // Filter appointments to include only those without feedback
            var feedbackAppointmentIds = feedbacks.Items.Select(f => f.AppointmentId).ToList();
            Appointments = allAppointments.Where(a => !feedbackAppointmentIds.Contains(a.Id)).ToList();

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetString("UserId");

                string response = await _feedbackService.AddFeedbackAsync(NewFeedback, userId);
                if (response == "Feedback added successfully.")
                {
                    TempData["ResponseMessage"] = response; // Success message
                    return RedirectToPage("/Feedback/Index"); // Redirect back to the feedback list page
                }
                TempData["ErrorMessage"] = response; // Error message for issues
            }
            return Page();
        }


    }
}
