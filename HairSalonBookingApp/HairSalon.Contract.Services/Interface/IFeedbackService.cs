using HairSalon.Core;
using HairSalon.ModelViews.FeedbackModeViews;
using HairSalon.ModelViews.FeedBackModeViews;

namespace HairSalon.Contract.Services.Interface
{
    public interface IFeedbackService
    {
        Task<BasePaginatedList<FeedBackModelView>> GetAllFeedbackAsync(int pageNumber, int pageSize, string id, string AppointmentId);

		Task<BasePaginatedList<ServiceFeedbackModelView>> GetFeedbackOfServiceAsync(int pageNumber, int pageSize, string serviceId, string comboId);

		Task<string> AddFeedbackAsync(CreateFeedbackModelView model);

        Task<string> UpdateFeedbackAsync(string id, UpdatedFeedbackModelView model);

        Task<string> DeleteFeedbackpAsync(string id);
    }
}
