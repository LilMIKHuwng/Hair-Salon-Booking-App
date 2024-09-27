using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.ModelViews.RoleModelViews;
using HairSalon.ModelViews.SalaryPaymentModelViews;
using HairSalon.ModelViews.ShopModelViews;

namespace HairSalon.Repositories.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Shop, ShopModelView>();
            CreateMap<Role, RoleModelView>();
            CreateMap<SalaryPayment, SalaryPaymentModelView>();

            CreateMap<Shop, CreateShopModelView>();
            CreateMap<Shop, UpdatedShopModelView>();
            CreateMap<Role, CreateRoleModelView>();
            CreateMap<Role, UpdatedRoleModelView>();
            CreateMap<SalaryPayment, CreateSalaryPaymentModelView>();
            CreateMap<SalaryPayment, UpdatedSalaryPaymentModelView>();

            CreateMap<CreateRoleModelView, Role>();
            CreateMap<UpdatedRoleModelView, Role>();

            CreateMap<CreateShopModelView, Shop>();
            CreateMap<UpdatedShopModelView, Shop>();

            CreateMap<CreateSalaryPaymentModelView, SalaryPayment>();
            CreateMap<UpdatedShopModelView, SalaryPayment>();
        }
    }
}
