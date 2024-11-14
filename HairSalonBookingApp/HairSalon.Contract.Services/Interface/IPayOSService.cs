using HairSalon.ModelViews.VnPayModelViews;

namespace HairSalon.Contract.Services.Interface;

public interface IPayOSService
{
    Task<string> CreatePaymentLink(PaymentRequestModelView model);
}