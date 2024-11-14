using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.FeedbackModeViews;
using HairSalon.ModelViews.FeedBackModeViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Feedback
{
    public class UpdateModel : PageModel
    {
        private readonly IFeedbackService _feedbackService;

        public UpdateModel(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        [BindProperty]
        public FeedBackModelView Feedback { get; set; }

        [BindProperty] // Bind UpdatedFeedback to be populated from the form
        public UpdatedFeedbackModelView UpdatedFeedback { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        [TempData]
        public string ResponseMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
			// Get Id from TempData
			if (TempData.ContainsKey("FeedbackId"))
			{
				Id = TempData["FeedbackId"].ToString();
			}

			Feedback = await _feedbackService.GetFeedBackByIdAsync(Id);
            if (Feedback == null)
            {
                ErrorMessage = "Feedback not found.";
                return RedirectToPage("/Feedback/Index");
            }

            // Initialize UpdatedFeedback with existing feedback data for display in the form
            UpdatedFeedback = new UpdatedFeedbackModelView
            {
                Comment = Feedback.Comment,
                Rate = Feedback.Rate // Gán giá tr? Rate t? Feedback
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _feedbackService.UpdateFeedbackAsync(Id, UpdatedFeedback);
            if (response == "Feedback updated successfully.")
            {
                ResponseMessage = response;
                return RedirectToPage("/Feedback/Index");
            }

            ErrorMessage = response;
            return Page();
        }
    }
}
