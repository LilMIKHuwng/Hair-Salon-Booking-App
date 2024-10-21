using HairSalon.ModelViews.VnPayModelViews;
using Microsoft.AspNetCore.Http;

namespace HairSalon.Contract.Services.Interface
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(PaymentRequestModelView model, HttpContext context);

        Task<string> ExcutePayment(PaymentResponseModelView collections);

        Task<string> ExcuteDepositToWallet(Guid userIdString, double amount);
        Task<string> DepositWallet(VnPayDepositWalletRequestModelView model, HttpContext context);
    }
}
