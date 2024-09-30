using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.ModelViews.RoleModelViews;
using HairSalon.ModelViews.SalaryPaymentModelViews;
using HairSalon.ModelViews.ShopModelViews;
using HairSalon.ModelViews.UserModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            CreateMap<User, UserModelView>();
            CreateMap<User,  CreateUserModelView>();
            CreateMap<User,  UpdateUserModelView>();
            CreateMap<CreateUserModelView, User>();
            CreateMap<UpdateUserModelView, User>();
            CreateMap<UserModelView, User>();

            CreateMap<UpdatedShopModelView, Shop>();

            CreateMap<CreateSalaryPaymentModelView, SalaryPayment>();
            CreateMap<UpdatedShopModelView, SalaryPayment>();
    }
}
