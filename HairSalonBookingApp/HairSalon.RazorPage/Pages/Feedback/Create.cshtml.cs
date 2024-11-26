using DocumentFormat.OpenXml.Office2010.Excel;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.AppointmentModelViews;
using HairSalon.ModelViews.FeedBackModeViews;
using HairSalon.ModelViews.ServiceModelViews;
using HairSalon.ModelViews.ComboModelViews; // Import ComboModelViews if necessary
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Feedback
{
    public class CreateModel : PageModel
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IAppointmentService _appointmentService;
        private readonly IServiceService _serviceService;  // New service injection
        private readonly IComboService _comboService;      // New combo injection

        public CreateModel(
            IFeedbackService feedbackService,
            IAppointmentService appointmentService,
            IServiceService serviceService,  // Inject IServiceService
            IComboService comboService)      // Inject IComboService
        {
            _feedbackService = feedbackService;
            _appointmentService = appointmentService;
            _serviceService = serviceService;
            _comboService = comboService;
        }

		[BindProperty]
		public CreateFeedbackModelView NewFeedback { get; set; }

		[TempData]
		public string ResponseMessage { get; set; }
		[BindProperty(SupportsGet = true)]
		public string AppointmentId { get; set; }

		public List<FeedBackModelView> Feedbacks { get; set; }
        public List<AppointmentModelView> Appointments { get; set; }
        public List<ServiceModelView> Services { get; set; } // For Service dropdown
        public List<ComboModelView> Combos { get; set; }     // For Combo dropdown

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

            // Check if the user has the necessary role
            if (!userRoles.Any(role => role == "Admin" || role == "Manager" || role == "User" || role == "Stylist"))
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return Page();
            }

			// Get Id from TempData
			if (TempData.ContainsKey("AppointmentId"))
			{
				AppointmentId = TempData["AppointmentId"].ToString();
			}

			// Retrieve all feedbacks and appointments
			var feedbacks = await _feedbackService.GetAllFeedbackAsync(1, int.MaxValue, null, null); // Use appropriate parameters here
			var allAppointments = await _appointmentService.GetAppointmentsForDropdownAsync() 
											?? new List<AppointmentModelView>();

			// Filter appointments to include only those without feedback
			var feedbackAppointmentIds = feedbacks.Items.Select(f => f.AppointmentId).ToList();
			Appointments = allAppointments.Where(a => !feedbackAppointmentIds.Contains(a.Id)).ToList();

            // Set Services and Combos
            Services = allServices;
            Combos = allCombos;

            return Page();
        }

		public async Task<IActionResult> OnPostAsync()
		{
			var userId = HttpContext.Session.GetString("UserId");

			string response = await _feedbackService.AddFeedbackAsync(NewFeedback, userId);
			if (response == "Feedback added successfully.")
			{
				TempData["ResponseMessage"] = response; // Success message
				return RedirectToPage("/Appointment/Index"); // Redirect back to the feedback list page
			}
			TempData["ErrorMessage"] = response; // Error message for issues

			return Page();
		}


	}
}
