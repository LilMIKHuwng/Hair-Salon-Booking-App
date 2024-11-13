using HairSalon.ModelViews.AppointmentModelViews;
using HairSalon.ModelViews.VnPayModelViews;
using Microsoft.AspNetCore.Http;

namespace HairSalon.Contract.Services.Interface
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(PaymentRequestModelView model, HttpContext context);
        Task<string> ExcutePayment(PaymentResponseModelView collections, string? userId);
        Task<string> ExcuteDepositToWallet(Guid userId, double amount);
        Task<string> DepositWallet(VnPayDepositWalletRequestModelView model, HttpContext context, string? userId);
        Task<AppointmentModelView?> GetAppointmentByIdAsync(string id);
        /*Task<string> DepositToWalletWithVnPay(double amount);*/
    }
}
