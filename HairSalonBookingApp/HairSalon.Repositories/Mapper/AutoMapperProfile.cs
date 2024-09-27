using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.ModelViews.PaymentModelViews;
using HairSalon.ModelViews.ShopModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Repositories.Mapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Shop, ShopModelView>();
            CreateMap<Shop, CreateShopModelView>();
            CreateMap<Shop, UpdatedShopModelView>();
            CreateMap<UpdatedShopModelView, Shop>();
            CreateMap<CreateShopModelView, Shop>();

            CreateMap<Payment, PaymentModelView>();
            CreateMap<Payment, CreatePaymentModelView>();
            CreateMap<Payment, UpdatedPaymentModelView>();
            CreateMap<UpdatedPaymentModelView, Payment>();
            CreateMap<CreatePaymentModelView, Payment>();
        }
    }
}
