using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.FeedBackModeViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HairSalon.RazorPage.Pages.Feedback
{
    public class DeleteModel : PageModel
    {
        private readonly IFeedbackService _feedbackService;

        public DeleteModel(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public FeedBackModelView Feedback { get; set; }

        // Property to store response or success messages
        [TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Check if Id is provided
            if (string.IsNullOrEmpty(Id))
            {
                TempData["ErrorMessage"] = "Invalid Feedback ID.";
                return RedirectToPage("/Error"); // Redirect to error page if Id is missing
            }

            // Retrieve user roles from session
            var userRolesJson = HttpContext.Session.GetString("UserRoles");
            if (userRolesJson == null)
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return Page();// Redirect to a different page with a denied message
            }

            var userRoles = JsonConvert.DeserializeObject<List<string>>(userRolesJson);

            // Check if the user has "Admin" or "Manager" roles
            if (!userRoles.Any(role => role == "Admin"))
            {
                TempData["DeniedMessage"] = "You do not have permission";
                return Page(); // Redirect to a different page with a denied message
            }

            Feedback = await _feedbackService.GetFeedBackByIdAsync(Id);
            if (Feedback == null)
            {
                TempData["ErrorMessage"] = "Feedback Not Found";
                return Redirect("/Feedback/Index"); // Redirect if role is not found
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = HttpContext.Session.GetString("UserId");

            string response = await _feedbackService.DeleteFeedbackpAsync(Id, userId);
            if (response == "Feedback deleted successfully.")
            {
                ResponseMessage = response;
                return Redirect("/Feedback/Index");
            }
            // Set ErrorMessage if deletion fails
            TempData["ErrorMessage"] = response;
            return Page();
        }
    }
}
