using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ComboModelViews;
using HairSalon.ModelViews.FeedbackModeViews;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairSalon.Core;

namespace HairSalon.RazorPage.Pages.Feedback
{
    public class ComboFeedbackModel : PageModel
    {
        private readonly IFeedbackService _feedbackService;
        public BasePaginatedList<ServiceFeedbackModelView> Feedbacks { get; set; } = new BasePaginatedList<ServiceFeedbackModelView>();

        public List<ComboModelView> Combos { get; set; } = new List<ComboModelView>();

        // Define ComboId property
        public string ComboId { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10; // Example page size, you can adjust as needed

        public ComboFeedbackModel(IFeedbackService feedbackService, IComboService comboService)
        {
            _feedbackService = feedbackService;
            Combos = comboService.GetAllComboAsync().Result.ToList();
        }

        // OnGet method to fetch feedbacks for the selected combo
        public async Task OnGetAsync(string ComboId, int pageNumber = 1)
        {
            this.ComboId = ComboId; // Set the ComboId here
            PageNumber = pageNumber;

            if (!string.IsNullOrEmpty(ComboId))
            {
                // Call the method to get feedback for the selected combo
                Feedbacks = await _feedbackService.GetFeedbackOfServiceAsync(PageNumber, PageSize, null, ComboId);
            }
        }
    }
}
