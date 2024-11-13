using HairSalon.Core;
using HairSalon.ModelViews.PaymentModelViews;

namespace HairSalon.Contract.Services.Interface
{
    public interface IPaymentService
    {
        Task<BasePaginatedList<PaymentModelView>> GetAllPaymentAsync(int pageNumber, int pageSize, string id, string AppointmentId, string PaymentMethod);
        Task<string> DeletePaymentAsync(string id, string? userId);
        Task<PaymentModelView?> GetPaymentByIdAsync(string id);
        Task<BasePaginatedList<PaymentModelView>> GetAllPaymentByUserIdAsync(string userid, int pageNumber, int pageSize);
        Task<bool> IsAppointmentPaidAsync(string appointmentId);
    }
}
