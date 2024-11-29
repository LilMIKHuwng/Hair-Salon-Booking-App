using HairSalon.ModelViews.AppointmentModelViews;
using HairSalon.ModelViews.VnPayModelViews;
using Microsoft.AspNetCore.Http;

namespace HairSalon.Contract.Services.Interface
{
    public interface IVnPayService
    {
        Task<string> CreatePaymentUrl(PaymentRequestModelView model, HttpContext context);
        Task<string> ExecutePayment(PaymentResponseModelView collections, string? userId);
        Task<string> ExecuteDepositToWallet(Guid userId, double amount);
        Task<AppointmentModelView?> GetAppointmentByIdAsync(string id);
        Task<string> CreateDepositUrl(PaymentRequestModelView model, HttpContext context);
        /*Task<string> DepositToWalletWithVnPay(double amount);*/

    }
}
