using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.FeedBackModeViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        // Property to store error messages
        [TempData]
        public string ErrorMessage { get; set; }

        // Property to store response or success messages
        [TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Feedback = await _feedbackService.GetFeedBackByIdAsync(Id);
            if (Feedback == null)
            {
                ErrorMessage = "Feedback Not Found";
                return Redirect("/Feedback/Index"); // Redirect if feedback is not found
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string response = await _feedbackService.DeleteFeedbackpAsync(Id);
            if (response == "Feedback successfully deleted")
            {
                ResponseMessage = response;
                return Redirect("/Feedback/Index");
            }
            // Set ErrorMessage if deletion fails
            ErrorMessage = response;
            return Page();
        }
    }
}
