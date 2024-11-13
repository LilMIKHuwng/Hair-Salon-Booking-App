using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.PaymentModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Services.Service
{
	public class PaymentService : IPaymentService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _contextAccessor;

		public PaymentService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_contextAccessor = contextAccessor;
		}

		// Get all payments with optional filters and pagination
		public async Task<BasePaginatedList<PaymentModelView>> GetAllPaymentAsync(int pageNumber, int pageSize, string id, string appointmentId, string paymentMethod)
		{
            // Query payments not marked as deleted
            IQueryable<Payment> paymentQuery = _unitOfWork.GetRepository<Payment>().Entities
				.Where(p => !p.DeletedTime.HasValue)
				.OrderByDescending(s => s.CreatedTime);

			// Apply optional filters
			if (!string.IsNullOrEmpty(id))
			{
				paymentQuery = paymentQuery.Where(p => p.Id == id);
			}

			if (!string.IsNullOrEmpty(appointmentId))
			{
				paymentQuery = paymentQuery.Where(p => p.AppointmentId == appointmentId);
			}

			if (!string.IsNullOrEmpty(paymentMethod))
			{
				paymentQuery = paymentQuery.Where(p => p.PaymentMethod == paymentMethod);
			}

			// Get total count before pagination
			int totalCount = await paymentQuery.CountAsync();

			// Paginate results
			List<Payment> paginatedPayments = await paymentQuery
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

			// Map to PaymentModelView
			List<PaymentModelView> paymentModelViews = _mapper.Map<List<PaymentModelView>>(paginatedPayments);

			// Return paginated list with total count
			return new BasePaginatedList<PaymentModelView>(paymentModelViews, totalCount, pageNumber, pageSize);
		}

		// Soft delete a payment
		public async Task<string> DeletePaymentAsync(string id, string? userId)
		{
			// Validate Payment ID
			if (string.IsNullOrWhiteSpace(id))
			{
				return "Please provide a valid Payment ID.";
			}

			// Find the existing payment
			Payment existingPayment = await _unitOfWork.GetRepository<Payment>().Entities
				.FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue);
			if (existingPayment == null)
			{
				return "The Payment cannot be found or has already been deleted.";
			}

			existingPayment.DeletedTime = DateTimeOffset.UtcNow;
            if (userId != null)
            {
                existingPayment.DeletedBy = userId;
            }
            else
            {
                existingPayment.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            }

            // Mark the payment as deleted
            await _unitOfWork.GetRepository<Payment>().UpdateAsync(existingPayment);
			await _unitOfWork.SaveAsync();

			return "Payment deleted successfully.";
		}

        // Retrieve a payment by its ID
        public async Task<PaymentModelView?> GetPaymentByIdAsync(string id)
        {
            // Check if the provided Role ID is valid (non-empty and non-whitespace)
            if (string.IsNullOrWhiteSpace(id))
            {
                return null; // Or you could throw an exception or return an error message
            }

            // Try to find the payment by its ID, ensuring it hasn�t been marked as deleted
            var paymentEntity = await _unitOfWork.GetRepository<Payment>().Entities
                .FirstOrDefaultAsync(payment => payment.Id == id && !payment.DeletedTime.HasValue);

            // If the payment is not found, return null
            if (paymentEntity == null)
            {
                return null;
            }

            // Map the ApplicationRoles entity to a RoleModelView and return it
            PaymentModelView paymentModelView = _mapper.Map<PaymentModelView>(paymentEntity);
            return paymentModelView;
        }

        public async Task<BasePaginatedList<PaymentModelView>> GetAllPaymentByUserIdAsync(string userId, int pageNumber = 1, int pageSize = 5)
        {
            // If userId is not provided, get it from HttpContext
            userId ??= _contextAccessor.HttpContext?.User?.FindFirst("UserId")?.Value;

            if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out Guid userGuid))
            {
                throw new ArgumentException("A valid UserId must be provided.");
            }

            // Query payments by joining with appointments to filter by userId
            IQueryable<Payment> paymentQuery = _unitOfWork.GetRepository<Payment>().Entities
                .Where(p => p.Appointment != null &&
                            p.Appointment.UserId == userGuid &&  // Compare Guid here
                            !p.DeletedTime.HasValue)
                .OrderByDescending(s => s.CreatedTime);

            // Get total count before pagination
            int totalCount = await paymentQuery.CountAsync();

            // Paginate results
            List<Payment> paginatedPayments = await paymentQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Map to PaymentModelView
            List<PaymentModelView> paymentModelViews = _mapper.Map<List<PaymentModelView>>(paginatedPayments);

            // Return paginated list with total count
            return new BasePaginatedList<PaymentModelView>(paymentModelViews, totalCount, pageNumber, pageSize);
        }
        public async Task<bool> IsAppointmentPaidAsync(string appointmentId)
        {
            if (string.IsNullOrWhiteSpace(appointmentId))
            {
                return false; // Trả về false nếu `appointmentId` không hợp lệ.
            }

            // Kiểm tra trong bảng thanh toán xem có tồn tại một payment đã thanh toán với `appointmentId` này không.
            var paymentExists = await _unitOfWork.GetRepository<Payment>().Entities
                .AnyAsync(p => p.AppointmentId == appointmentId /*&& !p.DeletedTime.HasValue*/);

            // Nếu tồn tại payment có `appointmentId`, trả về true, ngược lại trả về false.
            return paymentExists;
        }
    }
}
