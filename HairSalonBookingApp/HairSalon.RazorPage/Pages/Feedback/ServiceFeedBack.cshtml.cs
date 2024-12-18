using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ServiceModelViews;
using HairSalon.ModelViews.FeedbackModeViews;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairSalon.Core;

namespace HairSalon.RazorPage.Pages.Feedback
{
    public class ServiceFeedBackModel : PageModel
    {
        private readonly IFeedbackService _feedbackService;
        public BasePaginatedList<ServiceFeedbackModelView> Feedbacks { get; set; } = new BasePaginatedList<ServiceFeedbackModelView>();

        public List<ServiceModelView> Services { get; set; } = new List<ServiceModelView>(); // Store list of services

        public string ServiceId { get; set; } // Store the selected serviceId

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5; // Example page size, you can adjust as needed

        public ServiceFeedBackModel(IFeedbackService feedbackService, IServiceService serviceService)
        {
            _feedbackService = feedbackService;
            // Fetch the list of available services
            Services = serviceService.GetAllServicesAsync().Result.ToList();
        }

        // OnGet method to fetch feedbacks for the selected service
        public async Task OnGetAsync(string serviceId, int pageNumber = 1)
        {
            ServiceId = serviceId;
            PageNumber = pageNumber;

            if (!string.IsNullOrEmpty(serviceId))
            {
                // Gọi phương thức để lấy danh sách feedback theo serviceId
                Feedbacks = await _feedbackService.GetFeedbackOfServiceAsync(PageNumber, PageSize, serviceId, null);
            }
        }
    }

}
