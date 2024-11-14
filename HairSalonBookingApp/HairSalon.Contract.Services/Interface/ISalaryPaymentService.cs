using HairSalon.Core;
using HairSalon.ModelViews.SalaryPaymentModelViews;

namespace HairSalon.Contract.Services.Interface
{
    public interface ISalaryPaymentService
    {
        Task<BasePaginatedList<SalaryPaymentModelView>> GetAllSalaryPaymentAsync(string? id, Guid? stylistId, DateTime? paymentDate, decimal? baseSalary, int pageNumber, int pageSize);
		Task<string> CreateSalaryPaymentAsync(CreateSalaryPaymentModelView model, string? userId);
		Task<string> UpdateSalaryPaymentAsync(string id, string? userId, UpdatedSalaryPaymentModelView model);
		Task<string> DeleteSalaryPaymentAsync(string id, string? userId);
        Task<byte[]> ExportSalaryPaymentsToExcelAsync(Guid? stylistId, string? paymentDate);
        Task<SalaryPaymentModelView?> GetSalaryByIdAsync(string id);
    }
}
