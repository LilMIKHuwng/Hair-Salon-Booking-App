using HairSalon.Core;
using HairSalon.ModelViews.RoleModelViews;
using HairSalon.ModelViews.SalaryPaymentModelViews;

namespace HairSalon.Contract.Services.Interface
{
    public interface ISalaryPaymentService
    {
        Task<BasePaginatedList<SalaryPaymentModelView>> GetAllSalaryPaymentAsync(int pageNumber, int pageSize);
		Task<SalaryPaymentModelView> AddSalaryPaymentAsync(CreateSalaryPaymentModelView model);
		Task<SalaryPaymentModelView> UpdateSalaryPaymentAsync(string id, UpdatedSalaryPaymentModelView model);
		Task<string> DeleteSalaryPaymentAsync(string id);
		Task<SalaryPaymentModelView> GetSalaryPaymentAsync(string id);
	}
}
