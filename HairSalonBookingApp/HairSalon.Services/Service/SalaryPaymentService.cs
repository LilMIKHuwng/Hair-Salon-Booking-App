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

			// Map model to entity and set tracking fields
			SalaryPayment newSalaryPayment = _mapper.Map<SalaryPayment>(model);
			newSalaryPayment.Id = Guid.NewGuid().ToString("N");
			newSalaryPayment.CreatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
			newSalaryPayment.CreatedTime = DateTimeOffset.UtcNow;
			newSalaryPayment.LastUpdatedTime = DateTimeOffset.UtcNow;

            decimal PercentagePermitted = 0;
            decimal PercentageNoPermitted = 0;
            decimal deductedSalaryPermitted = 0;
            decimal deductedSalaryNoPermitted = 0;

            if (model.DayOffPermitted == 0 && model.DayOffNoPermitted == 0)
            {
                PercentagePermitted = 0.10m;
                newSalaryPayment.BonusSalary = model.BaseSalary * PercentagePermitted;
                newSalaryPayment.DeductedSalary = 0;
            }
            else
            {
                if (model.DayOffPermitted == 1)
                {
                    PercentagePermitted = 0.05m;
                    newSalaryPayment.BonusSalary = model.BaseSalary * PercentagePermitted;
                }
                else if (model.DayOffPermitted == 2)
                {
                    PercentagePermitted = 0.02m;
                    newSalaryPayment.BonusSalary = model.BaseSalary * PercentagePermitted;
                }
                else if (model.DayOffPermitted == 3)
                {
                    PercentagePermitted = 1m / 28;
                    deductedSalaryPermitted = model.BaseSalary * PercentagePermitted;
                }
                else if (model.DayOffPermitted > 3 && model.DayOffPermitted <= 6)
                {
                    PercentagePermitted = (decimal)model.DayOffPermitted / 28;
                    deductedSalaryPermitted = model.BaseSalary * PercentagePermitted;
                }
                else if (model.DayOffPermitted > 6 && model.DayOffPermitted <= 8)
                {
                    PercentagePermitted = 0.25m;
                    deductedSalaryPermitted = model.BaseSalary * PercentagePermitted;
                }
                else if (model.DayOffPermitted > 8 && model.DayOffPermitted <= 10)
                {
                    PercentagePermitted = 0.50m;
                    deductedSalaryPermitted = model.BaseSalary * PercentagePermitted;
                }
                else if (model.DayOffPermitted > 10 && model.DayOffPermitted <= 12)
                {
                    PercentagePermitted = 0.75m;
                    deductedSalaryPermitted = model.BaseSalary * PercentagePermitted;
                }
                else if (model.DayOffPermitted > 12)
                {
                    PercentagePermitted = 1.00m;
                    deductedSalaryPermitted = model.BaseSalary * PercentagePermitted;
                }

                if (model.DayOffNoPermitted >= 1 && model.DayOffNoPermitted <= 2)
                {
                    PercentageNoPermitted = (decimal)model.DayOffNoPermitted / 28;
                    deductedSalaryNoPermitted = model.BaseSalary * PercentageNoPermitted;
                }
                else if (model.DayOffNoPermitted == 3)
                {
                    PercentageNoPermitted = 0.25m;
                    deductedSalaryNoPermitted = model.BaseSalary * PercentageNoPermitted;
                }
                else if (model.DayOffNoPermitted == 4)
                {
                    PercentageNoPermitted = 0.50m;
                    deductedSalaryNoPermitted = model.BaseSalary * PercentageNoPermitted;
                }
                else if (model.DayOffNoPermitted == 5)
                {
                    PercentageNoPermitted = 0.75m;
                    deductedSalaryNoPermitted = model.BaseSalary * PercentageNoPermitted;
                }
                else if (model.DayOffNoPermitted >= 6)
                {
                    PercentageNoPermitted = 1.00m;
                    deductedSalaryNoPermitted = model.BaseSalary * PercentageNoPermitted;
                }

                newSalaryPayment.DeductedSalary = deductedSalaryPermitted + deductedSalaryNoPermitted;

                if (model.DayOffNoPermitted > 0)
                {
                    newSalaryPayment.BonusSalary = 0;
                }
            }
            // Save to database
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


            decimal PercentagePermitted = 0;
            decimal PercentageNoPermitted = 0;
            decimal deductedSalaryPermitted = 0;
            decimal deductedSalaryNoPermitted = 0;
            decimal bonusSalary = 0;

            if (existingSalary.DayOffPermitted == 0)
            {
                bonusSalary = 0.10m * existingSalary.BaseSalary;
            }
            else if (existingSalary.DayOffPermitted == 1)
            {
                bonusSalary = 0.05m * existingSalary.BaseSalary;
            }
            else if (existingSalary.DayOffPermitted == 2)
            {
                bonusSalary = 0.02m * existingSalary.BaseSalary;
            }
            else if (existingSalary.DayOffPermitted == 3)
            {
                deductedSalaryPermitted = existingSalary.BaseSalary * (1m / 28);
            }
            else if (existingSalary.DayOffPermitted >= 4 && existingSalary.DayOffPermitted <= 6)
            {
                deductedSalaryPermitted = existingSalary.BaseSalary * (decimal)existingSalary.DayOffPermitted / 28;
            }
            else if (existingSalary.DayOffPermitted > 6 && existingSalary.DayOffPermitted <= 8)
            {
                deductedSalaryPermitted = existingSalary.BaseSalary * 0.25m;
            }
            else if (existingSalary.DayOffPermitted > 8 && existingSalary.DayOffPermitted <= 10)
            {
                deductedSalaryPermitted = existingSalary.BaseSalary * 0.50m;
            }
            else if (existingSalary.DayOffPermitted > 10 && existingSalary.DayOffPermitted <= 12)
            {
                deductedSalaryPermitted = existingSalary.BaseSalary * 0.75m;
            }
            else if (existingSalary.DayOffPermitted > 12)
            {
                deductedSalaryPermitted = existingSalary.BaseSalary * 1.00m;
            }

            if (existingSalary.DayOffNoPermitted >= 1 && existingSalary.DayOffNoPermitted <= 2)
            {
                deductedSalaryNoPermitted = existingSalary.BaseSalary * (decimal)existingSalary.DayOffNoPermitted / 28;
            }
            else if (existingSalary.DayOffNoPermitted == 3)
            {
                deductedSalaryNoPermitted = existingSalary.BaseSalary * 0.25m;
            }
            else if (existingSalary.DayOffNoPermitted == 4)
            {
                deductedSalaryNoPermitted = existingSalary.BaseSalary * 0.50m;
            }
            else if (existingSalary.DayOffNoPermitted == 5)
            {
                deductedSalaryNoPermitted = existingSalary.BaseSalary * 0.75m;
            }
            else if (existingSalary.DayOffNoPermitted >= 6)
            {
                deductedSalaryNoPermitted = existingSalary.BaseSalary * 1.00m;
            }

            // Final salary updates
            existingSalary.BonusSalary = bonusSalary;
            existingSalary.DeductedSalary = deductedSalaryPermitted + deductedSalaryNoPermitted;


            // Set updated information
            existingSalary.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
			existingSalary.LastUpdatedTime = DateTimeOffset.UtcNow;

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
