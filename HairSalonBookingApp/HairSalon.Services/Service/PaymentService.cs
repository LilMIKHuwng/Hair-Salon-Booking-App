using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.Core.Utils;
using HairSalon.ModelViews.PaymentModelViews;
using HairSalon.ModelViews.ShopModelViews;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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

            // Set additional properties
            newPayment.Id = Guid.NewGuid().ToString("P");
            newPayment.CreatedBy = "claim account";  // Replace with actual authenticated user
            newPayment.CreatedTime = DateTimeOffset.UtcNow;
            newPayment.LastUpdatedTime = DateTimeOffset.UtcNow;

            await _unitOfWork.GetRepository<Payment>().InsertAsync(newPayment);
            await _unitOfWork.SaveAsync();

            // Map back to ShopModelView and return
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

            // Apply pagination
            List<Payment> paginatedPayment = await paymentQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Map to ShopModelView
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
