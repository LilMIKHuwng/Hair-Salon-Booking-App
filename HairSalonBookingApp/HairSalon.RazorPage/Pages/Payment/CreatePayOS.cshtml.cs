using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.VnPayModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Globalization;

namespace HairSalon.RazorPage.Pages.Payment
{
    public class CreatePayOSModel : PageModel
    {
        private readonly IPayOSService _payOsService;

        public CreatePayOSModel(IPayOSService payOsService)
        {
            _payOsService = payOsService;
        }


        public async Task<IActionResult> OnGetAsync()
        {
            var code = Request.Query["code"];
            var status = Request.Query["status"];
            var orderCode = Request.Query["orderCode"];
            var appointmentId = HttpContext.Session.GetString("AppointmentId");
            var url = "";
            if (code == "00" && status == "PAID")
            {
                var paymentLinkInformation = await _payOsService.GetInformationPayment(int.Parse(orderCode));
                var totalAmount = paymentLinkInformation.amount * 100;
                var bankCode = "00";
                var bankTranNo = paymentLinkInformation.transactions.FirstOrDefault().counterAccountName ?? "testBank" ;
                var cardType = "ATM";
                var responseCode = paymentLinkInformation.status;
                var transactionNo = paymentLinkInformation.transactions.FirstOrDefault().reference;
                var transactionStatus = paymentLinkInformation.status;
                var method = "PayOS";
                var paymentTime = DateTime.Parse(paymentLinkInformation.createdAt);

                 url = $"/payment/createvnpay?vnp_OrderInfo={appointmentId}" +
                          $"&vnp_Amount={totalAmount}" +
                          $"&vnp_BankCode={bankCode}" +
                          $"&vnp_BankTranNo={bankTranNo}" +
                          $"&vnp_CardType={cardType}" +
                          $"&vnp_ResponseCode={responseCode}" +
                          $"&vnp_TransactionNo={transactionNo}" +
                          $"&vnp_TransactionStatus={transactionStatus}" +
                          $"&method={method}" +
                          $"&vnp_PayDate={paymentTime:yyyyMMddHHmmss}";

            }
            else
            {
                 url = $"/payment/createvnpay?vnp_OrderInfo={appointmentId}" +
                          $"&vnp_TransactionStatus=24";
            }
            
            return Redirect(url);

        }
    }
}
