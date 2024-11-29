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
			// Truy vấn các thanh toán chưa bị xóa
			IQueryable<Payment> paymentQuery = _unitOfWork.GetRepository<Payment>().Entities
				.Where(p => !p.DeletedTime.HasValue)
				.OrderByDescending(s => s.CreatedTime);

			// Áp dụng các bộ lọc tùy chọn
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

			// Tạo truy vấn bao gồm Username thông qua Appointment
			var paymentWithUserQuery = paymentQuery.Select(p => new PaymentModelView
			{
				Id = p.Id,
				AppointmentId = p.AppointmentId,
				Username = p.Appointment.User.UserName, // Lấy Username từ User thông qua Appointment
				TotalAmount = p.TotalAmount,
				PaymentTime = p.CreatedTime.UtcDateTime, // Chuyển từ DateTimeOffset sang DateTime
				PaymentMethod = p.PaymentMethod,
				BankCode = p.BankCode,
				BankTranNo = p.BankTranNo,
				CardType = p.CardType,
				ResponseCode = p.ResponseCode,
				TransactionNo = p.TransactionNo,
				TransactionStatus = p.TransactionStatus
			});

			// Tổng số bản ghi trước khi phân trang
			int totalCount = await paymentWithUserQuery.CountAsync();

			// Phân trang
			var paginatedPayments = await paymentWithUserQuery
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

			// Trả về danh sách phân trang
			return new BasePaginatedList<PaymentModelView>(paginatedPayments, totalCount, pageNumber, pageSize);
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
			// Kiểm tra nếu ID hợp lệ
			if (string.IsNullOrWhiteSpace(id))
			{
				return null; // Hoặc có thể ném exception tùy ý
			}

			// Truy vấn để tìm Payment, bao gồm thông tin từ Appointment và User
			var paymentEntity = await _unitOfWork.GetRepository<Payment>().Entities
				.Where(payment => payment.Id == id && !payment.DeletedTime.HasValue)
				.Select(payment => new PaymentModelView
				{
					Id = payment.Id,
					AppointmentId = payment.AppointmentId,
					Username = payment.Appointment.User.UserName, // Lấy Username từ bảng User thông qua Appointment
					TotalAmount = payment.TotalAmount,
					PaymentTime = payment.CreatedTime.UtcDateTime, // Chuyển đổi DateTimeOffset sang DateTime
					PaymentMethod = payment.PaymentMethod,
					BankCode = payment.BankCode,
					BankTranNo = payment.BankTranNo,
					CardType = payment.CardType,
					ResponseCode = payment.ResponseCode,
					TransactionNo = payment.TransactionNo,
					TransactionStatus = payment.TransactionStatus
				})
				.FirstOrDefaultAsync();

			// Nếu không tìm thấy, trả về null
			if (paymentEntity == null)
			{
				return null;
			}

			// Trả về PaymentModelView đã ánh xạ
			return paymentEntity;
		}

		public async Task<BasePaginatedList<PaymentModelView>> GetAllPaymentByUserIdAsync(string userId, int pageNumber = 1, int pageSize = 5)
		{
			// Nếu userId không được cung cấp, lấy từ HttpContext
			userId ??= _contextAccessor.HttpContext?.User?.FindFirst("UserId")?.Value;

			if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out Guid userGuid))
			{
				throw new ArgumentException("A valid UserId must be provided.");
			}

			// Truy vấn thanh toán, bao gồm thông tin Appointment và Username từ User
			var paymentQuery = _unitOfWork.GetRepository<Payment>().Entities
				.Where(p => p.Appointment != null &&
							p.Appointment.UserId == userGuid && 
							!p.DeletedTime.HasValue)
				.OrderByDescending(p => p.CreatedTime)
				.Select(p => new PaymentModelView
				{
					Id = p.Id,
					AppointmentId = p.AppointmentId,
					Username = p.Appointment.User.UserName, // Lấy Username từ bảng ApplicationUsers
					TotalAmount = p.TotalAmount,
					PaymentTime = p.CreatedTime.UtcDateTime,
					PaymentMethod = p.PaymentMethod,
					BankCode = p.BankCode,
					BankTranNo = p.BankTranNo,
					CardType = p.CardType,
					ResponseCode = p.ResponseCode,
					TransactionNo = p.TransactionNo,
					TransactionStatus = p.TransactionStatus
				});

			// Tổng số lượng trước khi phân trang
			int totalCount = await paymentQuery.CountAsync();

			// Phân trang kết quả
			var paginatedPayments = await paymentQuery
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

			// Trả về danh sách phân trang
			return new BasePaginatedList<PaymentModelView>(paginatedPayments, totalCount, pageNumber, pageSize);
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
