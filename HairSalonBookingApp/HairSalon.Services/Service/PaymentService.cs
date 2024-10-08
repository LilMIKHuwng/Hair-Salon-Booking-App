﻿using AutoMapper;
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

        // Get all payments with optional filters for id, ... and support pagination
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

            int totalCount = await paymentQuery.CountAsync();

            List<Payment> paginatedPayments = await paymentQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            List<PaymentModelView> paymentModelViews = _mapper.Map<List<PaymentModelView>>(paginatedPayments);

            return new BasePaginatedList<PaymentModelView>(paymentModelViews, totalCount, pageNumber, pageSize);
        }

        // Add a new payment
        public async Task<string> AddPaymentAsync(CreatePaymentModelView model)
        {
            // Validate the payment model
            if (model == null)
            {
                return "The payment model cannot be null.";
            }

            // Validate the payment method
            if (string.IsNullOrEmpty(model.PaymentMethod))
            {
                return "Payment method must be provided.";
            }

            // Check if an active (non-deleted) payment already exists for the given appointment
            var existingPayment = await _unitOfWork.GetRepository<Payment>().Entities
                .FirstOrDefaultAsync(p => p.AppointmentId == model.AppointmentId && !p.DeletedTime.HasValue);

            if (existingPayment != null)
            {
                return "An payment has already been made for this appointment.";
            }

            // Fetch the appointment with services and PointsEarned
            var appointment = await _unitOfWork.GetRepository<Appointment>()
                                .Entities.Include(a => a.ServiceAppointments)
                                .ThenInclude(sa => sa.Service)
            .FirstOrDefaultAsync(a => a.Id == model.AppointmentId && !a.DeletedTime.HasValue);

            if (appointment == null)
            {
                return "The appointment cannot be found or has been deleted!";
            }

            // Check if there are any services for the appointment
            if (appointment.ServiceAppointments == null || !appointment.ServiceAppointments.Any())
            {
               return "No services found for this appointment.";
            }

            // Calculate the total amount from the services and ensure prices are valid
            decimal originalTotalAmount = appointment.ServiceAppointments.Sum(sa => sa.Service.Price);

            // Fetch user ID from the HttpContext
            var userIdString = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;

            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
            {
                return "User ID is not valid or not provided.";
            }

            // Fetch user from ApplicationUsers
            var applicationUser = await _unitOfWork.GetRepository<ApplicationUsers>()
                .Entities.FirstOrDefaultAsync(u => u.Id == userId);

            if (applicationUser == null)
            {
                return "User not found in ApplicationUsers.";
            }

            // Fetch user info to get available points
            var userInfo = await _unitOfWork.GetRepository<UserInfo>()
                .Entities.FirstOrDefaultAsync(ui => ui.Id == applicationUser.UserInfo.Id);

            if (userInfo == null)
            {
                return "User info not found.";
            }

            // Deduct points used in the appointment from UserInfo.Point if they have enough
            if (appointment.PointsEarned > 0)
            {
                userInfo.Point -= appointment.PointsEarned;
            }

            // Apply discount using points from Appointment.PointsEarned
            decimal totalAmount = Math.Max(0, originalTotalAmount - appointment.PointsEarned);

            // Add points based on the **original total amount** of the services (e.g., 1000 VND equals 100 points)
            int pointsToAdd = (int)(originalTotalAmount / 1000) * 100;
            userInfo.Point += pointsToAdd;
            _unitOfWork.GetRepository<UserInfo>().Update(userInfo);

            var payment = new Payment
            {
                AppointmentId = model.AppointmentId,
                TotalAmount = totalAmount,
                PaymentMethod = model.PaymentMethod,
                PaymentTime = DateTime.UtcNow,
                CreatedBy = userIdString
            };

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
               return "Please provide a valid Payment ID.";
            }

            // Validate the updated payment model
            if (model == null)
            {
                return "The updated payment model cannot be null.";
            }

            // Check for existing payment
            Payment existingPayment = await _unitOfWork.GetRepository<Payment>()
         .Entities.FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue);

            if (existingPayment == null)
            {
                return "The Payment cannot be found or has been deleted!";
            }

            // Validate payment method, if applicable
            if (string.IsNullOrEmpty(model.PaymentMethod))
            {
                return "Payment method must be provided.";
            }

            // Map the updated model to the existing payment
            _mapper.Map(model, existingPayment);

            // Track who updated the payment
            var userId = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return "User ID is not valid or not provided.";
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
                return "Please provide a valid Payment ID.";
            }

            // Check for existing payment
            var existingPayment = await _unitOfWork.GetRepository<Payment>()
                .Entities.FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue);

            if (existingPayment == null)
            {
                return "The Payment cannot be found or has already been deleted!";
            }

            // Validate user ID
            var userId = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            if (string.IsNullOrEmpty(userId))
            {
               return "User ID is not valid or not provided.";
            }

            existingPayment.DeletedTime = DateTimeOffset.UtcNow;
            existingPayment.DeletedBy = userId;

            _unitOfWork.GetRepository<Payment>().Update(existingPayment);
            await _unitOfWork.SaveAsync();
            return "Payment deleted successfully";
        }
    }
}
