﻿using HairSalon.Core;
using HairSalon.ModelViews.PaymentModelViews;
using HairSalon.ModelViews.ShopModelViews;

namespace HairSalon.Contract.Services.Interface
{
    public interface IPaymentService
    {
        Task<BasePaginatedList<PaymentModelView>> GetAllPaymentAsync(int pageNumber, int pageSize, string id, string AppointmentId, string PaymentMethod);
        Task<string> DeletePaymentpAsync(string id, string? userId);
        Task<PaymentModelView?> GetPaymentByIdAsync(string id);
    }
}
