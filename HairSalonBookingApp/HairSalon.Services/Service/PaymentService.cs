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

        // Get all payments with optional filters for ID and support pagination
        public async Task<BasePaginatedList<PaymentModelView>> GetAllPaymentAsync(int pageNumber, int pageSize, string id, string appointmentId, string paymentMethod)
        {
            IQueryable<Payment> paymentQuery = _unitOfWork.GetRepository<Payment>().Entities
                .Where(p => !p.DeletedTime.HasValue) // Ensure not deleted
                .OrderByDescending(s => s.CreatedTime);

            // Apply filter for 'id'
            if (!string.IsNullOrEmpty(id))
            {
                paymentQuery = paymentQuery.Where(p => p.Id == id);
            }

            // Apply filter for 'appointmentId'
            if (!string.IsNullOrEmpty(appointmentId))
            {
                paymentQuery = paymentQuery.Where(p => p.AppointmentId == appointmentId);
            }

            // Apply filter for 'paymentMethod'
            if (!string.IsNullOrEmpty(paymentMethod))
            {
                paymentQuery = paymentQuery.Where(p => p.PaymentMethod == paymentMethod);
            }

            // Get total count before pagination
            int totalCount = await paymentQuery.CountAsync();

            // Apply pagination
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
            // Validate the payment model
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "The payment model cannot be null.");
            }

            // Validate the payment method
            if (string.IsNullOrEmpty(model.PaymentMethod))
            {
                throw new ArgumentException("Payment method must be provided.", nameof(model.PaymentMethod));
            }

            // Fetch the appointment with services
            var appointment = await _unitOfWork.GetRepository<Appointment>()
                .Entities.Include(a => a.ServiceAppointments)
                         .ThenInclude(sa => sa.Service)
                .FirstOrDefaultAsync(a => a.Id == model.AppointmentId && !a.DeletedTime.HasValue)
                ?? throw new Exception("The appointment cannot be found or has been deleted!");

            // Check if there are any services for the appointment
            if (appointment.ServiceAppointments == null || !appointment.ServiceAppointments.Any())
            {
                throw new Exception("No services found for this appointment.");
            }

            // Calculate the total amount from the services and ensure prices are valid
            decimal totalAmount = appointment.ServiceAppointments.Sum(sa =>
            {
                if (sa.Service.Price <= 0)
                {
                    throw new Exception("Service price must be greater than zero.");
                }
                return sa.Service.Price;
            });

            // Check for existing payments
            var existingPayment = await _unitOfWork.GetRepository<Payment>().Entities
                .FirstOrDefaultAsync(p => p.AppointmentId == model.AppointmentId && !p.DeletedTime.HasValue);

            if (existingPayment != null)
            {
                throw new Exception("A payment has already been made for this appointment.");
            }

            // Fetch user ID from the HttpContext
            var userIdString = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;

            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
            {
                throw new Exception("User ID is not valid or not provided.");
            }

            // Fetch user from ApplicationUsers using the parsed Guid
            var applicationUser = await _unitOfWork.GetRepository<ApplicationUsers>().Entities
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (applicationUser == null)
            {
                throw new Exception("User not found in ApplicationUsers.");
            }

            // Fetch user info to get available points
            var userInfo = await _unitOfWork.GetRepository<UserInfo>().Entities
                .FirstOrDefaultAsync(ui => ui.Id == applicationUser.UserInfo.Id);

            if (userInfo == null)
            {
                throw new Exception("User info not found.");
            }

            // Validate points to use
            if (model.PointsToUse < 0)
            {
                throw new ArgumentException("Points to use cannot be negative.", nameof(model.PointsToUse));
            }

            // Check if the user has enough points to use
            if (model.PointsToUse > userInfo.Point)
            {
                throw new Exception("Insufficient points. You cannot use more points than you have.");
            }

            // Calculate discount based on available points
            int pointsToUse = Math.Min(model.PointsToUse, userInfo.Point); // Ensure not exceeding available points

            // Calculate the discount
            decimal discount = pointsToUse; // Each point = 1,000 VND

            // Ensure that discount does not exceed total amount
            if (discount > totalAmount)
            {
                throw new Exception("The discount cannot exceed the total amount.");
            }

            // Apply discount to total amount
            totalAmount = Math.Max(0, totalAmount - discount); // Ensure total does not go below 0

            // Update user's points
            userInfo.Point -= pointsToUse;
            _unitOfWork.GetRepository<UserInfo>().Update(userInfo);

            // Create the payment record
            var payment = new Payment
            {
                AppointmentId = model.AppointmentId,
                TotalAmount = totalAmount,
                PaymentMethod = model.PaymentMethod,
                PaymentTime = DateTime.UtcNow,
                CreatedBy = userIdString // or userId.ToString() if you want to store Guid as string
            };

            // Insert payment and save changes
            await _unitOfWork.GetRepository<Payment>().InsertAsync(payment);
            await _unitOfWork.SaveAsync();

            return "Payment added successfully";
        }

        // Update an existing payment
        public async Task<string> UpdatePaymentAsync(string id, UpdatedPaymentModelView model)
        {
            // Validate Payment ID
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Please provide a valid Payment ID.", nameof(id));
            }

            // Validate the updated payment model
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "The updated payment model cannot be null.");
            }

            // Check for existing payment
            Payment existingPayment = await _unitOfWork.GetRepository<Payment>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
                ?? throw new Exception("The Payment cannot be found or has been deleted!");

            // Validate payment method, if applicable
            if (string.IsNullOrEmpty(model.PaymentMethod))
            {
                throw new ArgumentException("Payment method must be provided.", nameof(model.PaymentMethod));
            }

            // Map the updated model to the existing payment
            _mapper.Map(model, existingPayment);

            // Track who updated the payment
            var userId = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                throw new Exception("User ID is not valid or not provided.");
            }

            existingPayment.LastUpdatedBy = userId;
            existingPayment.LastUpdatedTime = DateTimeOffset.UtcNow;

            // Update the payment record
            _unitOfWork.GetRepository<Payment>().Update(existingPayment);
            await _unitOfWork.SaveAsync();

            return "Payment updated successfully";
        }

        // Soft delete a payment
        public async Task<string> DeletePaymentpAsync(string id)
        {
            // Validate Payment ID
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Please provide a valid Payment ID.", nameof(id));
            }

            // Check for existing payment
            Payment existingPayment = await _unitOfWork.GetRepository<Payment>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
                ?? throw new Exception("The Payment cannot be found or has already been deleted!");

            // Validate user ID
            var userId = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                throw new Exception("User ID is not valid or not provided.");
            }

            existingPayment.DeletedTime = DateTimeOffset.UtcNow;
            existingPayment.DeletedBy = userId;

            _unitOfWork.GetRepository<Payment>().Update(existingPayment);
            await _unitOfWork.SaveAsync();
            return "Payment deleted successfully";
        }
    }
}
