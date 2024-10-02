using HairSalon.Core;
using HairSalon.ModelViews.PaymentModelViews;

namespace HairSalon.Contract.Services.Interface
{
    public interface IPaymentService
    {
        Task<BasePaginatedList<PaymentModelView>> GetAllPaymentAsync(int pageNumber, int pageSize);

        Task<PaymentModelView> AddPaymentAsync(CreatePaymentModelView model);

        Task<PaymentModelView> UpdatePaymentAsync(string id, UpdatedPaymentModelView model);

        Task<string> DeletePaymentpAsync(string id);

        Task<PaymentModelView> GetPaymentAsync(string id);
    }
}
