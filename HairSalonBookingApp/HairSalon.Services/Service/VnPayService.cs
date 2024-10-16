using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.VnPayModelViews;
using HairSalon.Repositories.Entity;
using HairSalon.Services.VNPay;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Services.Service
{
    public class VnPayService : IVnPayService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public VnPayService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public string CreatePaymentUrl(VnPayRequestModelView model, HttpContext context)
        {
            var vnpay = new VNPayLibrary();
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_Version", "2.1.0");
            vnpay.AddRequestData("vnp_TmnCode", _configuration["VnPay:TmnCode"]);
            vnpay.AddRequestData("vnp_Amount", (model.Amount * 100).ToString());
            vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_ExpireDate", DateTime.Now.AddHours(1).ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", "165.225.230.115");
            vnpay.AddRequestData("vnp_Locale", "vn");
            vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan tien");
            vnpay.AddRequestData("vnp_OrderType", "other");
            vnpay.AddRequestData("vnp_ReturnUrl", _configuration["VnPay:ReturnUrl"]);
            vnpay.AddRequestData("vnp_TxnRef", DateTime.Now.ToString("yyyyMMddHHmmss"));

            string paymentUrl = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html" + vnpay.CreateRequestUrl(_configuration["VnPay:PaymentUrl"], _configuration["VnPay:HashSecret"]);
            return paymentUrl;
        }

        public async Task<string> ExcutePayment(VnPayResponseModelView model)
        {
            // Validate the payment model and method
            if (model == null)
            {
                return "The payment model cannot be null.";
            }
            if (string.IsNullOrEmpty(model.Method))
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
            //if (appointment.ServiceAppointments == null || !appointment.ServiceAppointments.Any())
            //{
            //    return "No services found for this appointment.";
            //}

            //// Calculate the total amount for services
            //decimal originalTotalAmount = appointment.ServiceAppointments.Sum(sa => sa.Service.Price);

            // Fetch user ID from the context
            var userIdString = _httpContextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
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

            //// Deduct points used in appointment if available
            //if (appointment.PointsEarned > 0 && userInfo.Point < appointment.PointsEarned)
            //{
            //    return "User does not have enough points to apply this discount.";
            //}
            //userInfo.Point -= appointment.PointsEarned;

            //// Calculate the final total amount after applying discount
            //decimal totalAmount = Math.Max(0, originalTotalAmount - appointment.PointsEarned);

            //// Add points earned from the original total amount
            //int pointsToAdd = (int)(originalTotalAmount / 1000) * 100;
            //userInfo.Point += pointsToAdd;
            //_unitOfWork.GetRepository<UserInfo>().Update(userInfo);

            // Create a new payment record
            var payment = new Payment
            {
                AppointmentId = model.AppointmentId,
                TotalAmount = (decimal)model.TotalAmount,
                PaymentMethod = model.Method,
                PaymentTime = DateTime.UtcNow,
                CreatedBy = userIdString,
                BankCode = model.BankCode,
                CardType = model.CardType,
                BankTranNo = model.BankTranNo,
                ResponseCode = model.ResponseCode,
                TransactionNo = model.TransactionNo,
                TransactionStatus = model.TransactionStatus
            };

            // Save the payment to the database
            await _unitOfWork.GetRepository<Payment>().InsertAsync(payment);
            await _unitOfWork.SaveAsync();

            return "Payment added successfully.";
        }
    }
}
