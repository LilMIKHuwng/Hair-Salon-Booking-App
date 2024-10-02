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

            Payment newPayment = _mapper.Map<Payment>(model);

            newPayment.Id = Guid.NewGuid().ToString("N");
            newPayment.CreatedBy = "claim account"; 
            newPayment.CreatedTime = DateTimeOffset.UtcNow;
            newPayment.LastUpdatedTime = DateTimeOffset.UtcNow;

            await _unitOfWork.GetRepository<Payment>().InsertAsync(newPayment);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<PaymentModelView>(newPayment);
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
