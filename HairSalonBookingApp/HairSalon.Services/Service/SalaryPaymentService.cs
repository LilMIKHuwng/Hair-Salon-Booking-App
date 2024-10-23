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

		// Constructor to inject dependencies
		public SalaryPaymentService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_contextAccessor = contextAccessor;
		}

		// Get all SalaryPayments with optional filtering by ID and payment date
		public async Task<BasePaginatedList<SalaryPaymentModelView>> GetAllSalaryPaymentAsync(string? id, Guid? stylistId, DateTime? paymentDate, int pageNumber, int pageSize)
		{
			// Get all SalaryPayments that are not deleted
			IQueryable<SalaryPayment> salaryPaymentQuery = _unitOfWork.GetRepository<SalaryPayment>().Entities
				.Where(p => !p.DeletedTime.HasValue);

			// Apply filters if provided
			if (!string.IsNullOrEmpty(id))
			{
				salaryPaymentQuery = salaryPaymentQuery.Where(p => p.Id == id);
			}

            if (stylistId.HasValue)
            {
                salaryPaymentQuery = salaryPaymentQuery.Where(p => p.UserId == stylistId.Value);
            }
            if (paymentDate.HasValue)
			{
				salaryPaymentQuery = salaryPaymentQuery.Where(p => p.PaymentDate.Date == paymentDate.Value.Date);
			}

			// Order by creation time and paginate results
			salaryPaymentQuery = salaryPaymentQuery.OrderByDescending(s => s.CreatedTime);

			int totalCount = await salaryPaymentQuery.CountAsync();
			List<SalaryPayment> paginatedSalaryPayment = await salaryPaymentQuery
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

			// Map entities to model views and return paginated list
			List<SalaryPaymentModelView> salaryPaymentModelViews = _mapper.Map<List<SalaryPaymentModelView>>(paginatedSalaryPayment);
			return new BasePaginatedList<SalaryPaymentModelView>(salaryPaymentModelViews, totalCount, pageNumber, pageSize);
		}

        // Create a new SalaryPayment
        public async Task<string> CreateSalaryPaymentAsync(CreateSalaryPaymentModelView model)
        {
            var paymentDate = model.PaymentDate;
            var nextPaymentDate = new DateTime(paymentDate.Year, paymentDate.Month, 5).AddMonths(1); 
            var currentMonthPaymentStartDate = new DateTime(paymentDate.Year, paymentDate.Month, 5); 

            // Kiểm tra xem đã tồn tại bảng lương nào cho userId trong phạm vi hiện tại chưa
            //var existingPayment = await _unitOfWork.GetRepository<SalaryPayment>()
            //    .FindAsync(sp => sp.CreatedBy == _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value &&
            //                     sp.PaymentDate >= currentMonthPaymentStartDate &&
            //                     sp.PaymentDate < nextPaymentDate);

            //if (existingPayment != null)
            //{
            //    return "Salary payment for this period has already been created. You can only create a new payment after " + nextPaymentDate.ToString("yyyy-MM-dd") + ".";
            //}

            SalaryPayment newSalaryPayment = _mapper.Map<SalaryPayment>(model);
            newSalaryPayment.Id = Guid.NewGuid().ToString("N");
            newSalaryPayment.CreatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            newSalaryPayment.CreatedTime = DateTimeOffset.UtcNow;
            newSalaryPayment.LastUpdatedTime = DateTimeOffset.UtcNow;

            var deductionRules = new Dictionary<int, decimal>
			{
				{ 0, 0.10m }, 
				{ 3, 0.25m },  
				{ 4, 0.50m },  
				{ 6, 1.00m }   
			};

            decimal percentage = 0;

            foreach (var rule in deductionRules.OrderBy(r => r.Key))
            {
                if (model.DayOffNoPermitted >= rule.Key)
                {
                    percentage = rule.Value;
                }
            }

            if (model.DayOffNoPermitted == 0 && model.DayOffPermitted == 0)
            {
                newSalaryPayment.BonusSalary = model.BaseSalary * percentage;
                newSalaryPayment.DeductedSalary = 0;
            }
            else
            {
                newSalaryPayment.DeductedSalary = model.BaseSalary * percentage;
                newSalaryPayment.BonusSalary = 0;
            }

 
            await _unitOfWork.GetRepository<SalaryPayment>().InsertAsync(newSalaryPayment);
            await _unitOfWork.SaveAsync();

            return "Add new salary payment successfully!";
        }



        // Update an existing SalaryPayment
        public async Task<string> UpdateSalaryPaymentAsync(string id, UpdatedSalaryPaymentModelView model)
        {
            // Check if id is provided
            if (string.IsNullOrWhiteSpace(id))
            {
                return "Please provide a valid Salary Payment ID.";
            }

            // Find the SalaryPayment by id
            SalaryPayment existingSalary = await _unitOfWork.GetRepository<SalaryPayment>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue);

            // Return error if not found
            if (existingSalary == null)
            {
                return "The Salary Payment cannot be found or has been deleted!";
            }

            // Update fields if new data is provided
            existingSalary.UserId = model.UserId ?? existingSalary.UserId;
            existingSalary.BaseSalary = model.BaseSalary ?? existingSalary.BaseSalary;
            existingSalary.PaymentDate = model.PaymentDate ?? existingSalary.PaymentDate;
            existingSalary.DayOffPermitted = model.DayOffPermitted ?? existingSalary.DayOffPermitted;
            existingSalary.DayOffNoPermitted = model.DayOffNoPermitted ?? existingSalary.DayOffNoPermitted;

            // Set updated information
            existingSalary.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            existingSalary.LastUpdatedTime = DateTimeOffset.UtcNow;

            var deductionRules = new Dictionary<int, decimal>
            {
                { 0, 0.10m },
                { 3, 0.25m },
                { 4, 0.50m },
                { 6, 1.00m }
            };

            decimal percentage = 0;

            foreach (var rule in deductionRules.OrderBy(r => r.Key))
            {
                if (model.DayOffNoPermitted >= rule.Key)
                {
                    percentage = rule.Value;
                }
            }

            // Handle nullable BaseSalary by providing a default value (e.g., 0) if it's null
            decimal baseSalary = model.BaseSalary ?? 0;

            if (model.DayOffNoPermitted == 0 && model.DayOffPermitted == 0)
            {
                existingSalary.BonusSalary = baseSalary * percentage;
                existingSalary.DeductedSalary = 0;
            }
            else
            {
                existingSalary.DeductedSalary = baseSalary * percentage;
                existingSalary.BonusSalary = 0;
            }

            // Save changes
            await _unitOfWork.GetRepository<SalaryPayment>().UpdateAsync(existingSalary);
            await _unitOfWork.SaveAsync();

            return "Updated salary payment successfully!";
        }


        // Delete a SalaryPayment (soft delete)
        public async Task<string> DeleteSalaryPaymentAsync(string id)
		{
			// Check if id is provided
			if (string.IsNullOrWhiteSpace(id))
			{
				return "Please provide a valid Salary Payment ID.";
			}

			// Find the SalaryPayment by id
			SalaryPayment existingSalary = await _unitOfWork.GetRepository<SalaryPayment>().Entities
				.FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue);

			// Return error if not found
			if (existingSalary == null)
			{
				return "The Salary Payment cannot be found or has been deleted!";
			}

			// Soft delete by setting DeletedTime and DeletedBy
			existingSalary.DeletedTime = DateTimeOffset.UtcNow;
			existingSalary.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;

			// Save changes
			await _unitOfWork.GetRepository<SalaryPayment>().UpdateAsync(existingSalary);
			await _unitOfWork.SaveAsync();

			return "Deleted salary payment successfully!";
		}
	}
}
