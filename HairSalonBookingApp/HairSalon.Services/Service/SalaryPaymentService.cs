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
		public async Task<BasePaginatedList<SalaryPaymentModelView>> GetAllSalaryPaymentAsync(string? id, Guid? stylistId, DateTime? paymentDate, decimal? baseSalary, int pageNumber, int pageSize)
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
            if (baseSalary.HasValue)
            {
                salaryPaymentQuery = salaryPaymentQuery.Where(p => p.BaseSalary == baseSalary.Value);
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

            // Get the current user's ID from the context
            var userId = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;

            // Check if a salary payment already exists for the user in the current period
            var existingPayment = await _unitOfWork.GetRepository<SalaryPayment>().Entities
                .FirstOrDefaultAsync(s => s.CreatedBy == userId &&
                                          s.PaymentDate >= currentMonthPaymentStartDate &&
                                          s.PaymentDate < nextPaymentDate &&
                                          !s.DeletedTime.HasValue);

            if (existingPayment != null)
            {
                return "Salary payment for this period has already been created.";
            }

            // Create a new SalaryPayment
            SalaryPayment newSalaryPayment = _mapper.Map<SalaryPayment>(model);
            newSalaryPayment.Id = Guid.NewGuid().ToString("N");
            newSalaryPayment.CreatedBy = userId;
            newSalaryPayment.CreatedTime = DateTimeOffset.UtcNow;
            newSalaryPayment.LastUpdatedTime = DateTimeOffset.UtcNow;

            // Define deduction rules using dictionaries
            var permittedDeductionRules = new Dictionary<int, decimal>
            {
                { 3, 1m / 28 }, // For 3 days, deduct 1 day salary
                { 7, 0.25m },   // For 7 days, deduct 25% of salary
                { 9, 0.50m },   // For 9 days, deduct 50% of salary
                { 11, 0.75m },  // For 11 days, deduct 75% of salary
                { 13, 1.0m }    // For 13 days or more, deduct full salary
            };

                    var nonPermittedDeductionRules = new Dictionary<int, decimal>
            {
                { 1, 1m / 28 }, // 1 day, deduct 1 day salary
                { 2, 2m / 28 }, // 2 days, deduct 2 days salary
                { 3, 0.25m },   // 3 days, deduct 25% of salary
                { 4, 0.50m },   // 4 days, deduct 50% of salary
                { 5, 0.75m },   // 5 days, deduct 75% of salary
                { 6, 1.0m }     // 6 or more days, deduct full salary
            };

                    // Define bonus rules
                    var bonusRules = new Dictionary<int, decimal>
            {
                { 0, 0.10m }, // No days off, bonus 10%
                { 1, 0.05m }, // 1 day off, bonus 5%
                { 2, 0.02m }  // 2 days off, bonus 2%
            };

            // Calculate deductions based on permitted days off
            decimal deductionPercentage = permittedDeductionRules
                .Where(rule => model.DayOffPermitted >= rule.Key)
                .Select(rule => rule.Value)
                .DefaultIfEmpty(0)
                .Last();

            // Calculate deductions based on non-permitted days off
            deductionPercentage += nonPermittedDeductionRules
                .Where(rule => model.DayOffNoPermitted >= rule.Key)
                .Select(rule => rule.Value)
                .DefaultIfEmpty(0)
                .Last();

            // Calculate total days off for bonus eligibility
            int totalDaysOff = model.DayOffPermitted + model.DayOffNoPermitted;

            // Calculate bonus based on permitted days off only if total days off <= 3
            decimal bonusPercentage = 0;
            if (totalDaysOff <= 3)
            {
                bonusPercentage = bonusRules
                    .Where(rule => model.DayOffPermitted == rule.Key)
                    .Select(rule => rule.Value)
                    .DefaultIfEmpty(0)
                    .First();
            }

            // Calculate the final Bonus and Deducted Salary
            newSalaryPayment.DeductedSalary = model.BaseSalary * deductionPercentage;
            newSalaryPayment.BonusSalary = model.BaseSalary * bonusPercentage;

            // Save the new salary payment
            await _unitOfWork.GetRepository<SalaryPayment>().InsertAsync(newSalaryPayment);
            await _unitOfWork.SaveAsync();

            return "Add new salary payment successfully!";
        }


        // Update an existing SalaryPayment
        public async Task<string> UpdateSalaryPaymentAsync(string id, UpdatedSalaryPaymentModelView model)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return "Please provide a valid Salary Payment ID.";
            }

            // Find the SalaryPayment by id
            SalaryPayment existingSalary = await _unitOfWork.GetRepository<SalaryPayment>().Entities
                .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue);

            if (existingSalary == null)
            {
                return "The Salary Payment cannot be found or has been deleted!";
            }

            existingSalary.UserId = model.UserId ?? existingSalary.UserId;
            existingSalary.BaseSalary = model.BaseSalary ?? existingSalary.BaseSalary;
            existingSalary.PaymentDate = model.PaymentDate ?? existingSalary.PaymentDate;
            existingSalary.DayOffPermitted = model.DayOffPermitted ?? existingSalary.DayOffPermitted;
            existingSalary.DayOffNoPermitted = model.DayOffNoPermitted ?? existingSalary.DayOffNoPermitted;

            existingSalary.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            existingSalary.LastUpdatedTime = DateTimeOffset.UtcNow;

            decimal baseSalary = existingSalary.BaseSalary;
            decimal deductedSalary = 0;
            decimal bonusSalary = 0;

            // Rules for permitted days off deduction
            var permittedDeductionRules = new List<(int minDays, int maxDays, decimal deductionPercentage)>
    {
        (3, 6, 1.0m / 28), // From day 3 to 6, deduct 1 day salary per day
        (7, 8, 0.25m),     // From day 7 to 8, deduct 25% of salary
        (9, 10, 0.5m),     // From day 9 to 10, deduct 50% of salary
        (11, 12, 0.75m),   // From day 11 to 12, deduct 75% of salary
        (13, int.MaxValue, 1.0m) // More than 12 days, deduct full salary
    };

            // Rules for non-permitted days off deduction
            var nonPermittedDeductionRules = new List<(int minDays, decimal deductionPercentage)>
    {
        (1, 1.0m / 28),  // 1 day, deduct 1 day salary
        (2, 2.0m / 28),  // 2 days, deduct 2 days salary
        (3, 0.25m),      // From day 3, deduct 25% of salary
        (4, 0.5m),       // 4 days, deduct 50% of salary
        (5, 0.75m),      // 5 days, deduct 75% of salary
        (6, 1.0m)        // 6 or more days, deduct full salary
    };

            // Rules for bonus
            var bonusRules = new Dictionary<int, decimal>
    {
        { 0, 0.10m },  // No days off, bonus 10%
        { 1, 0.05m },  // 1 day off, bonus 5%
        { 2, 0.02m }   // 2 days off, bonus 2%
    };

            // Calculate permitted days off deduction
            int dayOffPermitted = model.DayOffPermitted.GetValueOrDefault();
            int dayOffNoPermitted = model.DayOffNoPermitted.GetValueOrDefault();

            // Calculate permitted days off deduction
            foreach (var (minDays, maxDays, deductionPercentage) in permittedDeductionRules)
            {
                if (dayOffPermitted >= minDays && dayOffPermitted <= maxDays)
                {
                    deductedSalary += deductionPercentage * baseSalary;
                    break;
                }
            }

            // Calculate non-permitted days off deduction
            foreach (var (minDays, deductionPercentage) in nonPermittedDeductionRules)
            {
                if (dayOffNoPermitted >= minDays)
                {
                    deductedSalary += deductionPercentage * baseSalary;
                }
            }

            // Calculate total days off for bonus
            int totalDaysOff = dayOffPermitted + dayOffNoPermitted;

            // Calculate bonus
            if (totalDaysOff <= 3) // No bonus if total days off exceed 3
            {
                if (bonusRules.TryGetValue(dayOffPermitted, out decimal bonusPercentage))
                {
                    bonusSalary = bonusPercentage * baseSalary;
                }
            }

            // Update the salary values
            existingSalary.DeductedSalary = deductedSalary;
            existingSalary.BonusSalary = bonusSalary;

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
