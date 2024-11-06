using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.AppointmentModelViews;
using HairSalon.ModelViews.FeedBackModeViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public string ErrorMessage { get; set; }

        [TempData]
        public string ResponseMessage { get; set; }

        [TempData]
        public string DeniedMessage { get; set; }

        public List<AppointmentModelView> Appointments { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                DeniedMessage = "You do not have permission to add feedback.";
                return Page();
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);
            if (!userRoles.Any(role => role == "Admin" || role == "Manager"))
            {
                DeniedMessage = "You do not have permission to add feedback.";
                return Page();
            }

            // Retrieve appointments using _appointmentService
            Appointments = await _appointmentService.GetAppointmentsForDropdownAsync() ?? new List<AppointmentModelView>();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                string response = await _feedbackService.AddFeedbackAsync(NewFeedback);
                if (response == "Feedback successfully added")
                {
                    ResponseMessage = response;
                    return Redirect("/Feedback/Index");
                }

                ErrorMessage = response;
            }
            return Page();
        }
    }
}
