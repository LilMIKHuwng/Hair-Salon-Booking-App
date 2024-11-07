using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.FeedbackModeViews;
using HairSalon.ModelViews.FeedBackModeViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonBE.API.Controllers
{
    [Authorize(Roles = "User,Admin,Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        /// <summary>
        ///     Lấy tất cả feedback
        /// </summary>
        [HttpGet("all")]
        public async Task<ActionResult<BasePaginatedList<FeedBackModelView>>> GetAllFeedbacks(
                                                                                    int pageNumber = 1,
                                                                                    int pageSize = 5,
                                                                                    [FromQuery] string? id = null,
                                                                                    [FromQuery] string? appointmentId = null)
        {
            var result = await _feedbackService.GetAllFeedbackAsync(pageNumber, pageSize, id, appointmentId);
            return Ok(result);
        }

        /// <summary>
		///		Tạo feedback
		/// </summary>
        [HttpPost("create")]
        public async Task<ActionResult<string>> CreateFeedback([FromQuery] CreateFeedbackModelView model)
        {
            string result = await _feedbackService.AddFeedbackAsync(model, null);
            return Ok(new { Message = result });
        }

        /// <summary>
		///		Cập nhật feedback
		/// </summary>
        [HttpPut("update/{id}")]
        public async Task<ActionResult<string>> UpdateFeedback(string id, [FromQuery] UpdatedFeedbackModelView model)
        {
            string result = await _feedbackService.UpdateFeedbackAsync(id, model);
            return Ok(new { Message = result });
        }

        /// <summary>
		///		Xóa feedback
		/// </summary>
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<string>> DeleteFeedback(string id)
        {
            string result = await _feedbackService.DeleteFeedbackpAsync(id, null);
            return Ok(new { Message = result });
        }

        /// <summary>
		///		Lấy tất cả feedback của dịch vụ
		/// </summary>
		[HttpGet("service-feedbacks")]
		public async Task<ActionResult<BasePaginatedList<FeedBackModelView>>> GetAllFeedbackOfService(
		                                                                                int pageNumber = 1,
		                                                                                int pageSize = 5,
		                                                                                [FromQuery] string? serviceId = null,
		                                                                                [FromQuery] string? comboId = null)
		{
			// Gọi đến service để lấy dữ liệu feedback của service theo `serviceId` và `comboId`
			var result = await _feedbackService.GetFeedbackOfServiceAsync(pageNumber, pageSize, serviceId, comboId);
			return Ok(result);
		}
	}
}
