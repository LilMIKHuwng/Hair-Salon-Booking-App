using HairSalon.ModelViews.VnPayModelViews;
using Microsoft.AspNetCore.Http;

namespace HairSalon.Contract.Services.Interface
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(VnPayRequestModelView model, HttpContext context);

        Task<string> ExcutePayment(VnPayResponseModelView collections);
    }
}
