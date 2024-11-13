using AutoMapper;
using ClosedXML.Excel;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.SalaryPaymentModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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
        public async Task<BasePaginatedList<SalaryPaymentModelView>> GetAllSalaryPaymentAsync(
        string? id, Guid? stylistId, DateTime? paymentDate, decimal? baseSalary, int pageNumber, int pageSize)
        {
            // Get all SalaryPayments that are not deleted
            IQueryable<SalaryPayment> salaryPaymentQuery = _unitOfWork.GetRepository<SalaryPayment>().Entities
                .Where(p => !p.DeletedTime.HasValue);

            // Apply additional filters if provided
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

            // Fetch total count of records before pagination
            int totalCount = await salaryPaymentQuery.CountAsync();

            // Fetch paginated salary payments along with user info for full name
            var paginatedSalaryPayment = await salaryPaymentQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(s => s.User)
                    .ThenInclude(u => u.UserInfo) // Include UserInfo for FullName
                .ToListAsync();

            // Map entities to model views and add FullName mapping
            var salaryPaymentModelViews = paginatedSalaryPayment.Select(s => new SalaryPaymentModelView
            {
                Id = s.Id,
                UserId = s.UserId.HasValue ? s.UserId.Value.ToString() : string.Empty,
                BaseSalary = s.BaseSalary,
                PaymentDate = s.PaymentDate,
                FullName = s.User.UserInfo != null
                            ? $"{s.User.UserInfo.Firstname} {s.User.UserInfo.Lastname}"
                            : "N/A" // Handle case when UserInfo is null
			}).ToList();

            return new BasePaginatedList<SalaryPaymentModelView>(salaryPaymentModelViews, totalCount, pageNumber, pageSize);
        }

        // Create a new SalaryPayment
        public async Task<string> CreateSalaryPaymentAsync(CreateSalaryPaymentModelView model, string? userId)
        {
            if (model.BaseSalary < 0 || model.DayOffPermitted < 0 || model.DayOffNoPermitted < 0)
            {
                return "Invalid input: Base salary and day-off values must be non-negative.";
            }

            var paymentDate = model.PaymentDate;
            var nextPaymentDate = new DateTime(paymentDate.Year, paymentDate.Month, 5).AddMonths(1);
            var currentMonthPaymentStartDate = new DateTime(paymentDate.Year, paymentDate.Month, 5);

			// Check if a salary payment already exists for the user in the current period
			var existingPayment = await _unitOfWork.GetRepository<SalaryPayment>().Entities
				.FirstOrDefaultAsync(s => s.UserId == model.UserId &&
										  s.PaymentDate >= currentMonthPaymentStartDate &&
										  s.PaymentDate < nextPaymentDate &&
										  !s.DeletedTime.HasValue);

			if (existingPayment != null)
			{
				return "The salarypayment has been create in this month!";
			}

            // Create a new SalaryPayment
            SalaryPayment newSalaryPayment = _mapper.Map<SalaryPayment>(model);
            newSalaryPayment.Id = Guid.NewGuid().ToString("N");
            newSalaryPayment.CreatedTime = DateTimeOffset.UtcNow;
            newSalaryPayment.LastUpdatedTime = DateTimeOffset.UtcNow;

            if (userId != null)
            {
                newSalaryPayment.CreatedBy = userId;
            }
            else
            {
                newSalaryPayment.CreatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            }
            newSalaryPayment.CreatedTime = DateTimeOffset.UtcNow;

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
            if (totalDaysOff < 3)
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
		public async Task<string> UpdateSalaryPaymentAsync(string id, string? userId, UpdatedSalaryPaymentModelView model)
		{
            if (model.BaseSalary < 0 || model.DayOffPermitted < 0 || model.DayOffNoPermitted < 0)
            {
                return "Invalid input: Base salary and day-off values must be non-negative.";
            }

            if (string.IsNullOrWhiteSpace(id))
			{
				return "Please provide a valid Salary Payment ID.";
			}

			// Tìm kiếm SalaryPayment theo id
			SalaryPayment existingSalary = await _unitOfWork.GetRepository<SalaryPayment>().Entities
				.FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue);

			if (existingSalary == null)
			{
				return "The Salary Payment cannot be found or has been deleted!";
			}

			// Lấy PaymentDate mới (nếu có, dùng ngày trong model, nếu không dùng ngày cũ)
			var newPaymentDate = model.PaymentDate ?? existingSalary.PaymentDate;

			// Kiểm tra nếu đã tồn tại lương cho UserId này trong cùng tháng và năm
			var isDuplicateSalary = await _unitOfWork.GetRepository<SalaryPayment>().Entities
				.AnyAsync(s => s.UserId == existingSalary.UserId &&
							   s.PaymentDate.Year == newPaymentDate.Year &&
							   s.PaymentDate.Month == newPaymentDate.Month &&
							   s.Id != id &&
							   !s.DeletedTime.HasValue);

			if (isDuplicateSalary)
			{
				return "The UserId has been received this Salary in this month!";
			}

			// Cập nhật thông tin lương
			existingSalary.UserId = model.UserId ?? existingSalary.UserId;
			existingSalary.BaseSalary = model.BaseSalary ?? existingSalary.BaseSalary;
			existingSalary.PaymentDate = newPaymentDate;
			existingSalary.DayOffPermitted = model.DayOffPermitted ?? existingSalary.DayOffPermitted;
			existingSalary.DayOffNoPermitted = model.DayOffNoPermitted ?? existingSalary.DayOffNoPermitted;

            if (userId != null)
            {
                existingSalary.LastUpdatedBy = userId;
            }
            else
            {
                existingSalary.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            }

            existingSalary.LastUpdatedTime = DateTimeOffset.UtcNow;

			// Tính toán tiền khấu trừ và thưởng
			decimal baseSalary = existingSalary.BaseSalary;
			decimal deductedSalary = 0;
			decimal bonusSalary = 0;

			// Quy tắc khấu trừ cho ngày nghỉ có phép
			var permittedDeductionRules = new List<(int minDays, int maxDays, decimal deductionPercentage)>
			{
				(3, 6, 1.0m / 28), // Từ 3 đến 6 ngày, trừ 1 ngày lương mỗi ngày
				(7, 8, 0.25m),     // Từ 7 đến 8 ngày, trừ 25% lương
				(9, 10, 0.5m),     // Từ 9 đến 10 ngày, trừ 50% lương
				(11, 12, 0.75m),   // Từ 11 đến 12 ngày, trừ 75% lương
				(13, int.MaxValue, 1.0m) // Trên 12 ngày, trừ toàn bộ lương
			};

			// Quy tắc khấu trừ cho ngày nghỉ không phép
			var nonPermittedDeductionRules = new List<(int minDays, decimal deductionPercentage)>
			{
				(1, 1.0m / 28),  // 1 ngày, trừ 1 ngày lương
				(2, 2.0m / 28),  // 2 ngày, trừ 2 ngày lương
				(3, 0.25m),      // Từ 3 ngày, trừ 25% lương
				(4, 0.5m),       // 4 ngày, trừ 50% lương
				(5, 0.75m),      // 5 ngày, trừ 75% lương
				(6, 1.0m)        // 6 ngày trở lên, trừ toàn bộ lương
			};

			// Quy tắc thưởng
			var bonusRules = new Dictionary<int, decimal>
			{
				{ 0, 0.10m },  // Không nghỉ ngày nào, thưởng 10%
				{ 1, 0.05m },  // Nghỉ 1 ngày, thưởng 5%
				{ 2, 0.02m }   // Nghỉ 2 ngày, thưởng 2%
			};

			// Tính tổng số ngày nghỉ từ existingSalary
			int permittedDaysOff = model.DayOffPermitted.HasValue ? model.DayOffPermitted.Value : existingSalary.DayOffPermitted;
			int nonPermittedDaysOff = model.DayOffNoPermitted.HasValue ? model.DayOffNoPermitted.Value : existingSalary.DayOffNoPermitted;
			int totalDaysOff = permittedDaysOff + nonPermittedDaysOff;

			// Tính tiền thưởng dựa trên tổng số ngày nghỉ
			if (totalDaysOff < 3)
			{
				if (bonusRules.TryGetValue(totalDaysOff, out decimal bonusPercentage))
				{
					bonusSalary = bonusPercentage * baseSalary;
				}
			}
			else
			{
				bonusSalary = 0; // Không có bonus nếu tổng số ngày nghỉ >= 3
			}

			// Xét khấu trừ chỉ khi tổng số ngày nghỉ >= 3
			if (totalDaysOff >= 3)
			{
				// Tính khấu trừ cho ngày nghỉ có phép
				foreach (var (minDays, maxDays, deductionPercentage) in permittedDeductionRules)
				{
					if (permittedDaysOff >= minDays && permittedDaysOff <= maxDays)
					{
						deductedSalary += deductionPercentage * baseSalary;
						break; // Ngừng kiểm tra nếu đã tìm thấy quy tắc khấu trừ
					}
				}

				// Tính khấu trừ cho ngày nghỉ không phép
				foreach (var (minDays, deductionPercentage) in nonPermittedDeductionRules.OrderByDescending(r => r.minDays))
				{
					if (nonPermittedDaysOff >= minDays)
					{
						deductedSalary += deductionPercentage * baseSalary;
						break; // Ngừng kiểm tra nếu đã tìm thấy quy tắc khấu trừ
					}
				}
			}

			// Cập nhật lại các giá trị khấu trừ và thưởng cho SalaryPayment
			existingSalary.DeductedSalary = deductedSalary;
			existingSalary.BonusSalary = bonusSalary;

			// Lưu thay đổi
			await _unitOfWork.GetRepository<SalaryPayment>().UpdateAsync(existingSalary);
			await _unitOfWork.SaveAsync();

			return "Updated salary payment successfully!";
		}


		// Delete a SalaryPayment (soft delete)
		public async Task<string> DeleteSalaryPaymentAsync(string id, string? userId)
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

            if (userId != null)
            {
                existingSalary.DeletedBy = userId;
            }
            else
            {
                existingSalary.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
            }

			// Save changes
			await _unitOfWork.GetRepository<SalaryPayment>().UpdateAsync(existingSalary);
			await _unitOfWork.SaveAsync();

			return "Deleted salary payment successfully!";
		}

		// Export Excel Salary Payments
		// Export Excel Salary Payments
		public async Task<byte[]> ExportSalaryPaymentsToExcelAsync(Guid? stylistId, string? paymentDateStr)
		{
			IQueryable<SalaryPayment> salaryPaymentQuery = _unitOfWork.GetRepository<SalaryPayment>().Entities
				.Include(sp => sp.User)
				.Where(p => !p.DeletedTime.HasValue);

			// Filter by Stylist ID if provided
			if (stylistId.HasValue)
			{
				salaryPaymentQuery = salaryPaymentQuery.Where(p => p.UserId == stylistId.Value);
			}

			// Filter by PaymentDate if provided
			if (!string.IsNullOrEmpty(paymentDateStr))
			{
				if (int.TryParse(paymentDateStr, out int month) && month >= 1 && month <= 12)
				{
					// If the string is a valid month
					salaryPaymentQuery = salaryPaymentQuery.Where(p => p.PaymentDate.Month == month);
				}
				else if (paymentDateStr.Length == 4 && int.TryParse(paymentDateStr, out int year))
				{
					// If the string is a valid year
					salaryPaymentQuery = salaryPaymentQuery.Where(p => p.PaymentDate.Year == year);
				}
				else if (DateTime.TryParseExact(paymentDateStr, "yyyy-MM", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime paymentDate))
				{
					// Filter by both year and month
					salaryPaymentQuery = salaryPaymentQuery.Where(p =>
						p.PaymentDate.Year == paymentDate.Year &&
						p.PaymentDate.Month == paymentDate.Month);
				}
				else if (DateTime.TryParse(paymentDateStr, out paymentDate))
				{
					// If it's a full date, filter by that specific date
					salaryPaymentQuery = salaryPaymentQuery.Where(p => p.PaymentDate.Date == paymentDate.Date);
				}
			}

			// Get the filtered SalaryPayments list
			var salaryPayments = await salaryPaymentQuery.ToListAsync();

			// Create an Excel workbook
			using var workbook = new XLWorkbook();
			var worksheet = workbook.Worksheets.Add("Salary Payments");

			// Define column headers
			worksheet.Cell(1, 1).Value = "Name";
			worksheet.Cell(1, 2).Value = "Email";
			worksheet.Cell(1, 3).Value = "Phone";
			worksheet.Cell(1, 4).Value = "Base Salary";
			worksheet.Cell(1, 5).Value = "Payment Date";
			worksheet.Cell(1, 6).Value = "Day Off Permitted";
			worksheet.Cell(1, 7).Value = "Day Off Not Permitted";
			worksheet.Cell(1, 8).Value = "Deducted Salary";
			worksheet.Cell(1, 9).Value = "Bonus Salary";
			worksheet.Cell(1, 10).Value = "Total Salary";

			// Apply styling to the header row
			var headerRow = worksheet.Row(1);
			foreach (var cell in headerRow.CellsUsed())
			{
				cell.Style.Font.Bold = true;
				cell.Style.Fill.BackgroundColor = XLColor.LightCyan;
				cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

				// Apply borders to header cells
				cell.Style.Border.TopBorder = XLBorderStyleValues.Thin;
				cell.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
				cell.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
				cell.Style.Border.RightBorder = XLBorderStyleValues.Thin;
				cell.Style.Border.OutsideBorderColor = XLColor.Black;
			}

			// Populate data and apply styling
			for (int i = 0; i < salaryPayments.Count; i++)
			{
				var payment = salaryPayments[i];
				var row = worksheet.Row(i + 2);

				worksheet.Cell(i + 2, 1).Value = payment.User != null ? payment.User.UserInfo.Lastname + " " + payment.User.UserInfo.Firstname : "Null";
				worksheet.Cell(i + 2, 2).Value = payment.User.Email;
				worksheet.Cell(i + 2, 3).Style.NumberFormat.Format = "@";
				worksheet.Cell(i + 2, 3).Value = payment.User.PhoneNumber ?? "Null";
				worksheet.Cell(i + 2, 4).Value = payment.BaseSalary;
				worksheet.Cell(i + 2, 5).Value = payment.PaymentDate.ToString("yyyy-MM-dd");
				worksheet.Cell(i + 2, 6).Value = payment.DayOffPermitted;
				worksheet.Cell(i + 2, 7).Value = payment.DayOffNoPermitted;
				worksheet.Cell(i + 2, 8).Value = payment.DeductedSalary;
				worksheet.Cell(i + 2, 9).Value = payment.BonusSalary;

				// Calculate total salary
				decimal totalSalary = payment.BaseSalary - payment.DeductedSalary + payment.BonusSalary;
				worksheet.Cell(i + 2, 10).Value = totalSalary;

				// Apply borders and center-align content
				foreach (var cell in row.CellsUsed())
				{
					cell.Style.Border.TopBorder = XLBorderStyleValues.Thin;
					cell.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
					cell.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
					cell.Style.Border.RightBorder = XLBorderStyleValues.Thin;
					cell.Style.Border.OutsideBorderColor = XLColor.Black;

					cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
				}

				// Apply alternating row colors
				row.CellsUsed().Style.Fill.BackgroundColor = i % 2 == 0 ? XLColor.White : XLColor.LightGray;

				// Apply light yellow background to the "Total Salary" column
				worksheet.Cell(i + 2, 10).Style.Fill.BackgroundColor = XLColor.LightYellow;
			}

			// Auto-size columns
			worksheet.Columns().AdjustToContents();

			// Save workbook to memory stream
			using var stream = new MemoryStream();
			workbook.SaveAs(stream);
			return stream.ToArray();
		}

        // Retrieve a SalaryPayment by its ID
        public async Task<SalaryPaymentModelView?> GetSalaryByIdAsync(string id)
        {
            // Check if the provided SalaryPayment ID is valid (non-empty and non-whitespace)
            if (string.IsNullOrWhiteSpace(id))
            {
                return null; // Or you could throw an exception or return an error message
            }

            // Try to find the SalaryPayment by its ID, including related User and UserInfo, and ensuring it hasn’t been marked as deleted
            var salaryEntity = await _unitOfWork.GetRepository<SalaryPayment>().Entities
                .Include(s => s.User)
                    .ThenInclude(u => u.UserInfo) // Include UserInfo for FullName
                .FirstOrDefaultAsync(ex => ex.Id == id && !ex.DeletedTime.HasValue);

            // If the SalaryPayment is not found, return null
            if (salaryEntity == null)
            {
                return null;
            }

            // Map to SalaryPaymentModelView and include FullName if UserInfo is available
            var salaryModelView = _mapper.Map<SalaryPaymentModelView>(salaryEntity);
            salaryModelView.FullName = salaryEntity.User?.UserInfo != null
                ? $"{salaryEntity.User.UserInfo.Firstname} {salaryEntity.User.UserInfo.Lastname}"
                : "N/A"; // Handle case when UserInfo is null

            return salaryModelView;
        }
    }
}
