using HairSalon.ModelViews.VnPayModelViews;
using Net.payOS.Types;

namespace HairSalon.Contract.Services.Interface;

public interface IPayOSService
{
    Task<string> CreatePaymentLink(PaymentRequestModelView model);

    Task<PaymentLinkInformation> GetInformationPayment(long orderCode);
}