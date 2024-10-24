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

                worksheet.Cell(i + 2, 1).Value = payment.User != null ? payment.User.UserInfo.Lastname + " " + payment.User.UserInfo.Firstname  : "Null";
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
    }
}
