using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.SalaryPaymentModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Services.Service
{
    public class SalaryPaymentService : ISalaryPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public SalaryPaymentService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        #region GetAllSalaryPaymentAsync
        public async Task<BasePaginatedList<SalaryPaymentModelView>> GetAllSalaryPaymentAsync
                    (string? id, DateTime? paymentDate, int pageNumber, int pageSize)
        {
            // Get SalaryPayment list with optional filters for id and paymentDate
            IQueryable<SalaryPayment> salaryPaymentQuery = _unitOfWork.GetRepository<SalaryPayment>().Entities
                .Where(p => !p.DeletedTime.HasValue);

            // Apply filtering by id if provided
            if (!string.IsNullOrEmpty(id))
            {
                salaryPaymentQuery = salaryPaymentQuery.Where(p => p.Id == id);
            }

            // Apply filtering by paymentDate if provided
            if (paymentDate.HasValue)
            {
                salaryPaymentQuery = salaryPaymentQuery.Where(p => p.PaymentDate.Date == paymentDate.Value.Date);
            }

            // Order by CreatedTime descending
            salaryPaymentQuery = salaryPaymentQuery.OrderByDescending(s => s.CreatedTime);

            // Count total items for paginating
            int totalCount = await salaryPaymentQuery.CountAsync();

            // If there are no items, throw an exception
            if (totalCount == 0)
            {
                throw new Exception("Salary Payment list not found");
            }

            // Paginate SalaryPayment
            List<SalaryPayment> paginatedSalaryPayment = await salaryPaymentQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Map paginatedSalaryPayment to SalaryPaymentModelView for display
            List<SalaryPaymentModelView> salaryPaymentModelViews = _mapper.Map<List<SalaryPaymentModelView>>(paginatedSalaryPayment);

            // Return paginated list of SalaryPaymentModelView
            return new BasePaginatedList<SalaryPaymentModelView>(salaryPaymentModelViews, totalCount, pageNumber, pageSize);
        }
        #endregion

        #region AddSalaryPaymentAsync
        public async Task<SalaryPaymentModelView> AddSalaryPaymentAsync(CreateSalaryPaymentModelView model)
        {
            //Check userId is not empty
            if (model.UserId == Guid.Empty)
            {
                throw new Exception("User ID cannot be empty.");
            }

            //Map CreateSalaryPaymentModelView to SalaryPayment
            SalaryPayment newSalaryPayment = _mapper.Map<SalaryPayment>(model);

            //Create new data for tracking 
            newSalaryPayment.Id = Guid.NewGuid().ToString("N");
            newSalaryPayment.CreatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            newSalaryPayment.CreatedTime = DateTimeOffset.UtcNow;
            newSalaryPayment.LastUpdatedTime = DateTimeOffset.UtcNow;

            //Insert to DB and Save
            await _unitOfWork.GetRepository<SalaryPayment>().InsertAsync(newSalaryPayment);
            await _unitOfWork.SaveAsync();

            //Map newSalaryPayment to SalaryPaymentModelView
            return _mapper.Map<SalaryPaymentModelView>(newSalaryPayment);
        }
        #endregion

        #region UpdateSalaryPaymentAsync
        public async Task<SalaryPaymentModelView> UpdateSalaryPaymentAsync(string id, UpdatedSalaryPaymentModelView model)
        {
            //Check id is not null
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Please provide a valid Salary Payment ID.");
            }

            //Find existingSalary to update
            SalaryPayment existingSalary = await _unitOfWork.GetRepository<SalaryPayment>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
                ?? throw new Exception("The Salary Payment cannot be found or has been deleted!");

            // If model properties have data then assign to existingSalary properties
            existingSalary.UserId = model.UserId ?? existingSalary.UserId;
            existingSalary.BaseSalary = model.BaseSalary ?? existingSalary.BaseSalary;
            existingSalary.PaymentDate = model.PaymentDate ?? existingSalary.PaymentDate;

            // Set additional properties
            existingSalary.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            existingSalary.LastUpdatedTime = DateTimeOffset.UtcNow;

            //Update to DB and save
            _unitOfWork.GetRepository<SalaryPayment>().Update(existingSalary);
            await _unitOfWork.SaveAsync();

            //Map SalaryPayment to SalaryPaymentModelView and return to show the changes
            return _mapper.Map<SalaryPaymentModelView>(existingSalary);
        }
        #endregion

        #region DeleteSalaryPaymentAsync
        public async Task<string> DeleteSalaryPaymentAsync(string id)
        {
            //Check id is not null
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Please provide a valid Salary Payment ID.");
            }

            //Get existed salary
            SalaryPayment existingSalary = await _unitOfWork.GetRepository<SalaryPayment>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
                ?? throw new Exception("The Salary Payment cannot be found or has been deleted!");

            //Tracking changes
            existingSalary.DeletedTime = DateTimeOffset.UtcNow;
            existingSalary.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;

            //Update delete properties and save
            _unitOfWork.GetRepository<SalaryPayment>().Update(existingSalary);
            await _unitOfWork.SaveAsync();

            return "Salary Payment has been deleted";
        }
        #endregion

    }
}
