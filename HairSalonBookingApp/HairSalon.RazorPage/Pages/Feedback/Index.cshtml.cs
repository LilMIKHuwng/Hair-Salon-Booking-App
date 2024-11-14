using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using Newtonsoft.Json;
using HairSalon.ModelViews.FeedBackModeViews;

namespace HairSalon.RazorPage.Pages.Feedback
{
    public class FeedbackManagementModel : PageModel
    {
        private readonly IFeedbackService _FeedbackService;

        public FeedbackManagementModel(IFeedbackService FeedbackService)
        {
            _FeedbackService = FeedbackService;
        }

        public BasePaginatedList<FeedBackModelView> Feedback { get; set; }

        public async Task<IActionResult> OnGetAsync(int pageNumber = 1, int pageSize = 5, string? id = null, string? AppointmentId = null)
        {
            var userFeedbacksJson = HttpContext.Session.GetString("UserRoles");

            if (userFeedbacksJson != null)
            {
                var userFeedbacks = JsonConvert.DeserializeObject<List<string>>(userFeedbacksJson);

                // Check if the user has "Admin" or "Manager" feedback
                if (!userFeedbacks.Any(feedback => feedback == "Admin" || feedback == "Manager" || feedback == "User" || feedback == "Stylist"))
                {
                    TempData["ErrorMessage"] = "You do not have permission to view this page.";
                    return Page(); // Show error message on the same page
                }
            }
            else
            {
                TempData["ErrorMessage"] = "You do not have permission to view this page.";
                return Page();
            }

            // If authorized, retrieve feedbacks data
            Feedback = await _FeedbackService.GetAllFeedbackAsync(pageNumber, pageSize, id, AppointmentId);
            return Page();
        }

		public async Task<IActionResult> OnPostAsync(string id, string action)
		{
			if (string.IsNullOrEmpty(id))
			{
				TempData["ErrorMessage"] = "Feedback ID is required.";
				return RedirectToPage();
			}

			//Save roleId to tempdata
			TempData["FeedbackId"] = id;

			switch (action?.ToLower())
			{
				case "update":
					return RedirectToPage("/Feedback/Update");
				case "detail":
					return RedirectToPage("/Feedback/Detail");
				case "delete":
					return RedirectToPage("/Feedback/Delete");
				default:
					TempData["ErrorMessage"] = "Invalid action.";
					return RedirectToPage();
			}
		}

	}
}
