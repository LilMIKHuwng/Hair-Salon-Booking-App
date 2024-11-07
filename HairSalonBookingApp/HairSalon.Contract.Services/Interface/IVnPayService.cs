using HairSalon.ModelViews.AppointmentModelViews;
using HairSalon.ModelViews.VnPayModelViews;
using Microsoft.AspNetCore.Http;

namespace HairSalon.Contract.Services.Interface
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(PaymentRequestModelView model, HttpContext context);
        Task<string> ExcutePayment(PaymentResponseModelView collections, string? userId);
        Task<string> ExcuteDepositToWallet(double amount);
        Task<string> DepositWallet(VnPayDepositWalletRequestModelView model, HttpContext context);
        Task<AppointmentModelView?> GetAppointmentByIdAsync(string id);
    }
}
