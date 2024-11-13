using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.AppointmentModelViews;
using HairSalon.ModelViews.FeedbackModeViews;
using HairSalon.ModelViews.FeedBackModeViews;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Services.Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public FeedbackService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        // Get all feedbacks with optional filters for id, ... and support pagination
        public async Task<BasePaginatedList<FeedBackModelView>> GetAllFeedbackAsync(int pageNumber, int pageSize, string id, string appointmentId)
        {
            // Query feedbacks not marked as deleted 
            IQueryable<Feedback> feedbackQuery = _unitOfWork.GetRepository<Feedback>().Entities
                .Where(f => !f.DeletedTime.HasValue) 
                .OrderByDescending(f => f.CreatedTime);

            // Apply optional filters
            if (!string.IsNullOrEmpty(id))
            {
                feedbackQuery = feedbackQuery.Where(f => f.Id == id);
            }

            if (!string.IsNullOrEmpty(appointmentId))
            {
                feedbackQuery = feedbackQuery.Where(f => f.AppointmentId == appointmentId);
            }

            // Get total count before pagination
            int totalCount = await feedbackQuery.CountAsync();

            // Paginate results
            List<Feedback> paginatedFeedbacks = await feedbackQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Map to FeedBackModelView
            List<FeedBackModelView> feedbackModelViews = _mapper.Map<List<FeedBackModelView>>(paginatedFeedbacks);

            // Return paginated list with total count
            return new BasePaginatedList<FeedBackModelView>(feedbackModelViews, totalCount, pageNumber, pageSize);
        }

        // Add a new feedback
        public async Task<string> AddFeedbackAsync(CreateFeedbackModelView model, string? userId)
        {
            // Check if payment exists for the given AppointmentId
            var paymentExists = await _unitOfWork.GetRepository<Payment>().Entities
                .AnyAsync(p => p.AppointmentId == model.AppointmentId);

            if (!paymentExists)
            {
                return "Feedback can only be created if a payment has been made for this appointment.";
            }

            // Check if feedback for the given AppointmentId exists and is soft-deleted
            Feedback softDeletedFeedback = await _unitOfWork.GetRepository<Feedback>().Entities
                .FirstOrDefaultAsync(f => f.AppointmentId == model.AppointmentId && f.DeletedTime != null);

            if (softDeletedFeedback != null)
            {
                // Restore the soft-deleted feedback and update the details
                softDeletedFeedback.DeletedTime = null; // Restore the feedback by nulling out the deleted time
                softDeletedFeedback.DeletedBy = null; // Restore the feedback by nulling out the deleted by
                softDeletedFeedback.Rate = model.Rate; // Update the rate if needed
                softDeletedFeedback.Comment = model.Comment; // Update the comment if needed

                // Save changes for restored feedback
                await _unitOfWork.GetRepository<Feedback>().UpdateAsync(softDeletedFeedback);
                await _unitOfWork.SaveAsync();

                return "Feedback added successfully.";
            }

            // Check if feedback for the given AppointmentId exists (including soft-deleted)
            Feedback existingFeedback = await _unitOfWork.GetRepository<Feedback>().Entities
                .FirstOrDefaultAsync(f => f.AppointmentId == model.AppointmentId);

            if (existingFeedback != null)
            {
                // If feedback exists, do not create a new one
                return "Feedback has already been created for this appointment.";
            }

            // Proceed to create a new feedback since no feedback exists for the given AppointmentId
            Feedback newFeedback = _mapper.Map<Feedback>(model);
            newFeedback.Id = Guid.NewGuid().ToString("N");
            if (userId != null)
            {
                newFeedback.CreatedBy = userId;
            }
            else
            {
                newFeedback.CreatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            }
            newFeedback.CreatedTime = DateTimeOffset.UtcNow;

            await _unitOfWork.GetRepository<Feedback>().InsertAsync(newFeedback);
            await _unitOfWork.SaveAsync();

            return "Feedback added successfully.";
        }

        // Update an existing feedback
        public async Task<string> UpdateFeedbackAsync(string id, UpdatedFeedbackModelView model)
        {
            // Validate Feedback ID and model
            if (string.IsNullOrWhiteSpace(id))
            {
                return "Please provide a valid Feedback ID.";
            }

            // Find the existing feedback
            Feedback existingFeedback = await _unitOfWork.GetRepository<Feedback>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue);

            if (existingFeedback == null)
            {
                return "The Feedback cannot be found or has been deleted.";
            }

            existingFeedback.Rate = model.Rate ?? existingFeedback.Rate;
            existingFeedback.Comment = model.Comment ?? existingFeedback.Comment;

            existingFeedback.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            existingFeedback.LastUpdatedTime = DateTimeOffset.UtcNow;

            // Save the updated feedback
            await _unitOfWork.GetRepository<Feedback>().UpdateAsync(existingFeedback);
            await _unitOfWork.SaveAsync();

            return "Feedback updated successfully.";
        }

        // Soft delete a feedback
        public async Task<string> DeleteFeedbackpAsync(string id, string? userId)
        {
            // Validate Feedback ID
            if (string.IsNullOrWhiteSpace(id))
            {
                return "Please provide a valid Feedback ID.";
            }

            // Find the existing feedback
            Feedback existingFeedback = await _unitOfWork.GetRepository<Feedback>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue);
            if (existingFeedback == null)
            {
                return "The Feedback cannot be found or has already been deleted.";
            }

            existingFeedback.DeletedTime = DateTimeOffset.UtcNow;
            
            if (userId != null)
            {
                existingFeedback.DeletedBy = userId;
            }
            else
            {
                existingFeedback.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            }

            // Mark the feedback as deleted
            await _unitOfWork.GetRepository<Feedback>().UpdateAsync(existingFeedback);
            await _unitOfWork.SaveAsync();

            return "Feedback deleted successfully.";
        }

		public async Task<BasePaginatedList<ServiceFeedbackModelView>> GetFeedbackOfServiceAsync(int pageNumber, int pageSize, string serviceId, string comboId)
		{
			// Query feedbacks not marked as deleted
			IQueryable<Feedback> feedbackQuery = _unitOfWork.GetRepository<Feedback>().Entities
				.Where(f => !f.DeletedTime.HasValue)
				.OrderByDescending(f => f.CreatedTime);

			// Apply filter based on serviceId if provided
			if (!string.IsNullOrEmpty(serviceId))
			{
				// Get all service appointments related to the given serviceId
				List<string> relatedAppointmentIds = await _unitOfWork.GetRepository<ServiceAppointment>().Entities
					.Where(s => s.ServiceId == serviceId && !s.DeletedTime.HasValue)
					.Select(s => s.AppointmentId)
					.ToListAsync();

				feedbackQuery = feedbackQuery.Where(f => relatedAppointmentIds.Contains(f.AppointmentId));
			}

			// Apply filter based on comboId if provided
			if (!string.IsNullOrEmpty(comboId))
			{
				// Get all service appointments related to the given comboId
				List<string> relatedComboAppointmentIds = await _unitOfWork.GetRepository<ComboAppointment>().Entities
					.Where(s => s.ComboId == comboId && !s.DeletedTime.HasValue)
					.Select(s => s.AppointmentId)
					.ToListAsync();

				feedbackQuery = feedbackQuery.Where(f => relatedComboAppointmentIds.Contains(f.AppointmentId));
			}

			// Get total count before pagination
			int totalCount = await feedbackQuery.CountAsync();

			// Paginate results
			List<Feedback> paginatedFeedbacks = await feedbackQuery
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

			// Map to FeedBackModelView
			List<ServiceFeedbackModelView> feedbackModelViews = _mapper.Map<List<ServiceFeedbackModelView>>(paginatedFeedbacks);

			// Return paginated list with total count
			return new BasePaginatedList<ServiceFeedbackModelView>(feedbackModelViews, totalCount, pageNumber, pageSize);
		}

        // Retrieve a Feedback by its ID
        public async Task<FeedBackModelView?> GetFeedBackByIdAsync(string id)
        {
            // Check if the provided Feedback ID is valid (non-empty and non-whitespace)
            if (string.IsNullOrWhiteSpace(id))
            {
                return null; // Or you could throw an exception or return an error message
            }

            // Try to find the Feedback by its ID, ensuring it hasn’t been marked as deleted
            var FeedbackEntity = await _unitOfWork.GetRepository<Feedback>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue);

            // If the Feedback is not found, return null
            if (FeedbackEntity == null)
            {
                return null;
            }

            // Map the Feedback entity to a RoleModelView and return it
            FeedBackModelView FeedbackModelView = _mapper.Map<FeedBackModelView>(FeedbackEntity);
            return FeedbackModelView;
        }

        public async Task<List<AppointmentModelView>> GetAppointmentsForDropdownAsync()
        {
            // Lấy danh sách Appointment đã được sử dụng để tạo feedback
            var appointments = await _unitOfWork.GetRepository<Appointment>()
                .Entities
                .Where(a => a.Id.Any()) // Giả sử Feedbacks là danh sách feedback liên kết với Appointment
                .ToListAsync();

            // Ánh xạ sang AppointmentModelView nếu cần
            return _mapper.Map<List<AppointmentModelView>>(appointments);
        }


    }
}
