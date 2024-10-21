using HairSalon.ModelViews.VnPayModelViews;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
