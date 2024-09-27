using HairSalon.Core;
using HairSalon.ModelViews.SalaryPaymentModelViews;

namespace HairSalon.Contract.Services.Interface
{
    public interface ISalaryPaymentService
    {
        Task<BasePaginatedList<SalaryPaymentModelView>> GetAllSalaryPaymentAsync(int pageNumber, int pageSize);
        Task<SalaryPaymentModelView> AddSalaryPaymentAsync(CreateSalaryPaymentModelView model, string createdBy, string lastUpdatedBy);
        Task<SalaryPaymentModelView> UpdateSalaryPaymentAsync(string id, UpdatedSalaryPaymentModelView model, string lastUpdatedBy);
        Task<string> DeleteSalaryPaymentAsync(string id, string deletedBy);
    }
}
