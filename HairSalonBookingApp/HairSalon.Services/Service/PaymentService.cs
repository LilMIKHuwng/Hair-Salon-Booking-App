using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.PaymentModelViews;
using HairSalon.Repositories.Entity;
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

		// Add a new payment
		public async Task<string> AddPaymentAsync(CreatePaymentModelView model)
		{
			// Validate the payment model and method
			if (model == null)
			{
				return "The payment model cannot be null.";
			}
			if (string.IsNullOrEmpty(model.PaymentMethod))
			{
				return "Payment method must be provided.";
			}

			// Check if a payment already exists for the appointment
			var existingPayment = await _unitOfWork.GetRepository<Payment>().Entities
				.FirstOrDefaultAsync(p => p.AppointmentId == model.AppointmentId && !p.DeletedTime.HasValue);
			if (existingPayment != null)
			{
				return "An active payment has already been made for this appointment.";
			}

			// Fetch appointment details with services
			var appointment = await _unitOfWork.GetRepository<Appointment>().Entities
				.Include(a => a.ServiceAppointments).ThenInclude(sa => sa.Service)
				.FirstOrDefaultAsync(a => a.Id == model.AppointmentId && !a.DeletedTime.HasValue);
			if (appointment == null)
			{
				return "The appointment cannot be found or has been deleted.";
			}

			// Ensure appointment has services
			if (appointment.ServiceAppointments == null || !appointment.ServiceAppointments.Any())
			{
				return "No services found for this appointment.";
			}

			// Calculate the total amount for services
			decimal originalTotalAmount = appointment.ServiceAppointments.Sum(sa => sa.Service.Price);

			// Fetch user ID from the context
			var userIdString = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
			if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
			{
				return "User ID is not valid or not provided.";
			}

			// Fetch user and user info
			var applicationUser = await _unitOfWork.GetRepository<ApplicationUsers>().Entities
				.FirstOrDefaultAsync(u => u.Id == userId);
			if (applicationUser == null)
			{
				return "User not found in ApplicationUsers.";
			}

			var userInfo = await _unitOfWork.GetRepository<UserInfo>().Entities
				.FirstOrDefaultAsync(ui => ui.Id == applicationUser.UserInfo.Id);
			if (userInfo == null)
			{
				return "User info not found.";
			}

			// Deduct points used in appointment if available
			if (appointment.PointsEarned > 0 && userInfo.Point < appointment.PointsEarned)
			{
				return "User does not have enough points to apply this discount.";
			}
			userInfo.Point -= appointment.PointsEarned;

			// Calculate the final total amount after applying discount
			decimal totalAmount = Math.Max(0, originalTotalAmount - appointment.PointsEarned);

			// Add points earned from the original total amount
			int pointsToAdd = (int)(originalTotalAmount / 1000) * 100;
			userInfo.Point += pointsToAdd;
			_unitOfWork.GetRepository<UserInfo>().Update(userInfo);

			// Create a new payment record
			var payment = new Payment
			{
				AppointmentId = model.AppointmentId,
				TotalAmount = totalAmount,
				PaymentMethod = model.PaymentMethod,
				PaymentTime = DateTime.UtcNow,
				CreatedBy = userIdString
			};

			// Save the payment to the database
			await _unitOfWork.GetRepository<Payment>().InsertAsync(payment);
			await _unitOfWork.SaveAsync();

			return "Payment added successfully.";
		}

		// Update an existing payment
		public async Task<string> UpdatePaymentAsync(string id, UpdatedPaymentModelView model)
		{
			// Validate Payment ID and model
			if (string.IsNullOrWhiteSpace(id))
			{
				return "Please provide a valid Payment ID.";
			}

			// Find the existing payment
			Payment existingPayment = await _unitOfWork.GetRepository<Payment>().Entities
				.FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue);

			if (existingPayment == null)
			{
				return "The Payment cannot be found or has been deleted.";
			}

			existingPayment.PaymentMethod = model.PaymentMethod ?? existingPayment.PaymentMethod;

			existingPayment.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
			existingPayment.LastUpdatedTime = DateTimeOffset.UtcNow;

			// Save the updated payment
			_unitOfWork.GetRepository<Payment>().Update(existingPayment);
			await _unitOfWork.SaveAsync();

			return "Payment updated successfully.";
		}

		// Soft delete a payment
		public async Task<string> DeletePaymentpAsync(string id)
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
			existingPayment.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;

			// Mark the payment as deleted
			_unitOfWork.GetRepository<Payment>().Update(existingPayment);
			await _unitOfWork.SaveAsync();

			return "Payment deleted successfully.";
		}
	}
}
