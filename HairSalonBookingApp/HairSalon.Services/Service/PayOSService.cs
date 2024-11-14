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
        var appoinment = unitOfWork.GetRepository<Appointment>().Entities.FirstOrDefault(x => x.Id == model.AppoinmentId);
        if (appoinment == null) return "Appointment not found.";
        if (!string.Equals(appoinment.StatusForAppointment, "Completed")) return "Appointment has not been completed.";
        try
        {
            int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));
            ItemData item = new ItemData(appoinment.Id, 1, (int)appoinment.TotalAmount);
            List<ItemData> items = new List<ItemData>();
            items.Add(item);
            PaymentData paymentData = new PaymentData(orderCode, (int)appoinment.TotalAmount, "Thanh toan cat toc", items, configuration["VnPay:ReturnUrl"], configuration["VnPay:ReturnUrl"]);

            CreatePaymentResult createPayment = await payOs.createPaymentLink(paymentData);

            return createPayment.checkoutUrl;
        }
        catch (System.Exception exception)
        {
            Console.WriteLine(exception);
            return null;
        }
    }
   
}