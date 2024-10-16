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
        string CreatePaymentUrl(VnPayRequestModelView model, HttpContext context);

        Task<string> ExcutePayment(VnPayResponseModelView collections);
    }
}
