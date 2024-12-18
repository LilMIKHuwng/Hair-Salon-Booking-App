using AutoMapper;
using Azure;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.VnPayModelViews;
using HairSalon.Repositories.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Net.payOS;
using Net.payOS.Types;

namespace HairSalon.Services.Service;

public class PayOSService(PayOS payOs, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration) : IPayOSService
{
    public async Task<string> CreatePaymentLink(PaymentRequestModelView model)
    {
        try
        {
            int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));
            ItemData item = new ItemData(model.Information, 1, (int)model.Amount);
            List<ItemData> items = new List<ItemData>();
            items.Add(item);
            PaymentData paymentData = new PaymentData(orderCode,
                (int)model.Amount,
                "Thanh toan cat toc",
                items,
                configuration["PayOS:ReturnUrl"],
                configuration["PayOS:ReturnUrl"],
                "", "", "", "", "",
                long.Parse(model.TimeExpire));
            CreatePaymentResult createPayment = await payOs.createPaymentLink(paymentData);

            return createPayment.checkoutUrl;
        }
        catch (System.Exception exception)
        {
            Console.WriteLine(exception);
            return null;
        }
    }

    public async Task<PaymentLinkInformation> GetInformationPayment(long orderCode)
    {
        return await payOs.getPaymentLinkInformation(orderCode);

    }
}