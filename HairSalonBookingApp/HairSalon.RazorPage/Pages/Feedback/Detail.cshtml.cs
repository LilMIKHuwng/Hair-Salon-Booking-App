using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.FeedBackModeViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairSalon.RazorPage.Pages.Feedback
{
    public class DetailModel : PageModel
    {
        private readonly IFeedbackService _feedbackService;

        public DetailModel(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public FeedBackModelView FeedbackDetail { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
			// Get Id from TempData
			if (TempData.ContainsKey("FeedbackId"))
			{
				Id = TempData["FeedbackId"].ToString();
			}

			FeedbackDetail = await _feedbackService.GetFeedBackByIdAsync(Id);
            if (FeedbackDetail == null)
            {
                TempData["ErrorMessage"] = "Feedback not found.";
                return RedirectToPage("/Feedback/Index");
            }
            return Page();
        }
    }
}
