using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.AppointmentModelViews;
using HairSalon.ModelViews.VnPayModelViews;
using HairSalon.Repositories.Entity;
using HairSalon.Services.VNPay;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
        public string CreatePaymentUrl(PaymentRequestModelView model, HttpContext context)
        {
            var appoinment = _unitOfWork.GetRepository<Appointment>().Entities.FirstOrDefault(x => x.Id == model.AppoinmentId);
            if (appoinment == null) return "Appointment not found.";
            if (!string.Equals(appoinment.StatusForAppointment, "Completed")) return "Appointment has not been completed.";

            var vnpay = new VNPayLibrary();
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_Version", "2.1.0");
            vnpay.AddRequestData("vnp_TmnCode", _configuration["VnPay:TmnCode"]);
            vnpay.AddRequestData("vnp_Amount", ((int)appoinment.TotalAmount * 100).ToString());
            vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_ExpireDate", DateTime.Now.AddHours(1).ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", "165.225.230.115");
            vnpay.AddRequestData("vnp_Locale", "vn");
            vnpay.AddRequestData("vnp_OrderInfo", appoinment.Id);
            vnpay.AddRequestData("vnp_OrderType", "other");
            vnpay.AddRequestData("vnp_ReturnUrl", _configuration["VnPay:ReturnUrl"]);
            vnpay.AddRequestData("vnp_TxnRef", DateTime.Now.ToString("yyyyMMddHHmmss"));

            string paymentUrl = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html" + vnpay.CreateRequestUrl(_configuration["VnPay:PaymentUrl"], _configuration["VnPay:HashSecret"]);

            return paymentUrl;
        }

        public async Task<string> DepositWallet(VnPayDepositWalletRequestModelView model, HttpContext context, string? userId)
        {
            if(userId == null)
            {
                userId = _httpContextAccessor.HttpContext?.User?.FindFirst("UserId")?.Value;
            }
            var user = _unitOfWork.GetRepository<ApplicationUsers>().Entities.FirstOrDefault(user => user.Id == Guid.Parse(userId));
            if (user == null) return "User not found.";
            var vnpay = new VNPayLibrary();
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_Version", "2.1.0");
            vnpay.AddRequestData("vnp_TmnCode", _configuration["VnPay:TmnCode"]);
            vnpay.AddRequestData("vnp_Amount", ((int)model.Amount * 100).ToString());
            vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_ExpireDate", DateTime.Now.AddHours(1).ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", "165.225.230.115");
            vnpay.AddRequestData("vnp_Locale", "vn");
            vnpay.AddRequestData("vnp_OrderInfo", userId);
            vnpay.AddRequestData("vnp_OrderType", "other");
            vnpay.AddRequestData("vnp_ReturnUrl", _configuration["VnPay:ReturnUrl2"]);
            vnpay.AddRequestData("vnp_TxnRef", DateTime.Now.ToString("yyyyMMddHHmmss"));
            string paymentUrl = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html" + vnpay.CreateRequestUrl(_configuration["VnPay:PaymentUrl"], _configuration["VnPay:HashSecret"]);

            return paymentUrl;
        }

        public async Task<string> ExcutePayment(PaymentResponseModelView model, string? userIdString)
        {
            if (model.AppointmentId != null)
            {
                var appointmentId = await _unitOfWork.GetRepository<Payment>().Entities
                .FirstOrDefaultAsync(ui => ui.AppointmentId == model.AppointmentId);
                if (appointmentId != null) 
                {
                    return "Appointment have paymented";
                }
                var appointment = await _unitOfWork.GetRepository<Appointment>().Entities
               .FirstOrDefaultAsync(ui => ui.Id == model.AppointmentId);

                if (appointment == null)
                {
                    return "Appointment not found.";
                }

                if (appointment.StatusForAppointment != "Completed")
                {
                    return "Appointment don't complete";
                }
            }

            // Validate the payment model and method
            if (model == null)
            {
                return "The payment model cannot be null.";
            }

            if (string.IsNullOrEmpty(model.Method))
            {
                return "Payment method must be provided.";
            }

            // Fetch user ID from the context
            if (string.IsNullOrEmpty(userIdString))
            {
                userIdString = _httpContextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            } 

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

            // Update the user's wallet balance
            if (model.Method == "Wallet")
            {
                if (applicationUser.E_Wallet >= (decimal)model.TotalAmount)
                {
                    applicationUser.E_Wallet -= (decimal)model.TotalAmount;
                    _unitOfWork.GetRepository<ApplicationUsers>().Update(applicationUser);
                }
                else
                {
                    return "Your wallet does not enough to pay this appoinment!";
                }
            }

            // Create a new payment record
            var payment = new Payment
            {
                AppointmentId = model.AppointmentId,
                TotalAmount = (decimal)model.TotalAmount,
                PaymentMethod = model.Method,
                PaymentTime = DateTime.UtcNow,
                CreatedBy = userIdString,
                CreatedTime = DateTime.UtcNow,
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

        public async Task<string> ExcuteDepositToWallet(Guid userId, double amount)
        {
            var user = _unitOfWork.GetRepository<ApplicationUsers>().GetById(userId);
            if (user == null)
            {
                return "User not found!";
            }

            user.E_Wallet += (decimal)amount;
            _unitOfWork.GetRepository<ApplicationUsers>().Update(user);
            await _unitOfWork.SaveAsync();
            return "Success!";
        }

        public async Task<AppointmentModelView?> GetAppointmentByIdAsync(string id)
        {
            // Check if the provided Role ID is valid (non-empty and non-whitespace)
            if (string.IsNullOrWhiteSpace(id))
            {
                return null; // Or you could throw an exception or return an error message
            }

            // Try to find the role by its ID, ensuring it hasn’t been marked as deleted
            var appointmentEntity = await _unitOfWork.GetRepository<Appointment>().Entities
                .FirstOrDefaultAsync(shop => shop.Id == id && !shop.DeletedTime.HasValue);

            // If the role is not found, return null
            if (appointmentEntity == null)
            {
                return null;
            }

            // Map the ApplicationRoles entity to a RoleModelView and return it
            AppointmentModelView appointmentModelView = _mapper.Map<AppointmentModelView>(appointmentEntity);
            return appointmentModelView;
        }
    }
}
