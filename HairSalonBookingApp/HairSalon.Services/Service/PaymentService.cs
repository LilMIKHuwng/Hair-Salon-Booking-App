using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.PaymentModelViews;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Services.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PaymentModelView> AddPaymentAsync(CreatePaymentModelView model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "The payment model cannot be null.");
            }

            var appointment = await _unitOfWork.GetRepository<Appointment>()
                .Entities.Include(a => a.ServiceAppointments)
                         .ThenInclude(sa => sa.Service)
                .FirstOrDefaultAsync(a => a.Id == model.AppointmentId && !a.DeletedTime.HasValue)
                ?? throw new Exception("The Appointment cannot be found or has been deleted!");

            if (appointment.ServiceAppointments == null || !appointment.ServiceAppointments.Any())
            {
                throw new Exception("No services found for this appointment.");
            }

            decimal totalAmount = appointment.ServiceAppointments.Sum(sa => sa.Service.Price);

            var existingPayment = await _unitOfWork.GetRepository<Payment>().Entities
                .FirstOrDefaultAsync(p => p.AppointmentId == model.AppointmentId && !p.DeletedTime.HasValue);


            if (existingPayment != null)
            {
                throw new Exception("A payment has already been made for this appointment.");
            }

            var payment = new Payment
            {
                AppointmentId = model.AppointmentId,
                TotalAmount = totalAmount,
                PaymentMethod = model.PaymentMethod,
                PaymentTime = DateTime.UtcNow,
                CreatedBy = "claim account",
                CreatedTime = DateTime.UtcNow,
                LastUpdatedBy = "claim account",
                LastUpdatedTime = DateTime.UtcNow
            };

            await _unitOfWork.GetRepository<Payment>().InsertAsync(payment);
            await _unitOfWork.SaveAsync();

            var paymentModelView = _mapper.Map<PaymentModelView>(payment);

            return paymentModelView;
        }

        public async Task<string> DeletePaymentpAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Please provide a valid Payment ID.");
            }

            Payment existingPayment = await _unitOfWork.GetRepository<Payment>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
                ?? throw new Exception("The Shop cannot be found or has been deleted!");

            existingPayment.DeletedTime = DateTimeOffset.UtcNow;
            existingPayment.DeletedBy = "claim account";  

            _unitOfWork.GetRepository<Payment>().Update(existingPayment);
            await _unitOfWork.SaveAsync();
            return "Deleted Successfully";
        }

        public async Task<BasePaginatedList<PaymentModelView>> GetAllPaymentAsync(int pageNumber, int pageSize)
        {
            IQueryable<Payment> paymentQuery = _unitOfWork.GetRepository<Payment>().Entities
                  .Where(p => !p.DeletedTime.HasValue)
                  .OrderByDescending(s => s.CreatedTime);

            int totalCount = await paymentQuery.CountAsync();

            List<Payment> paginatedPayment = await paymentQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            List<PaymentModelView> paymentModelViews = _mapper.Map<List<PaymentModelView>>(paginatedPayment);

            return new BasePaginatedList<PaymentModelView>(paymentModelViews, totalCount, pageNumber, pageSize);
        }

        public async Task<PaymentModelView> GetPaymentAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Please provide a valid Payment ID.");
            }

            Payment existingPayment = await _unitOfWork.GetRepository<Payment>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
                ?? throw new Exception("The Payment cannot be found or has been deleted!");


            return _mapper.Map<PaymentModelView>(existingPayment);
        }

        public async Task<PaymentModelView> UpdatePaymentAsync(string id, UpdatedPaymentModelView model)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Please provide a valid Payment ID.");
            }

            Payment existingPayment = await _unitOfWork.GetRepository<Payment>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
                ?? throw new Exception("The Payment cannot be found or has been deleted!");

            _mapper.Map(model, existingPayment);

            existingPayment.LastUpdatedBy = "claim account";  
            existingPayment.LastUpdatedTime = DateTimeOffset.UtcNow;

            _unitOfWork.GetRepository<Payment>().Update(existingPayment);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<PaymentModelView>(existingPayment);
        }
    }
}
