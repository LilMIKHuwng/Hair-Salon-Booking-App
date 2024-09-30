using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.ModelViews.AppointmentModelViews;
using HairSalon.ModelViews.ServiceModelViews;
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
            CreateMap<Shop, CreateShopModelView>();
            CreateMap<Shop, UpdatedShopModelView>();
            CreateMap<UpdatedShopModelView, Shop>();
            CreateMap<CreateShopModelView, Shop>();

            CreateMap<Appointment, AppointmentModelView>();
            CreateMap<Appointment, CreateAppointmentModelView>();
            CreateMap<Appointment, UpdateAppointmentModelView>();
            CreateMap<CreateAppointmentModelView, Appointment>();
            CreateMap<UpdateAppointmentModelView, Appointment>();
            
            CreateMap<Service, ServiceModelView>();
            CreateMap<Service, CreateServiceModelView>();
            CreateMap<Service, UpdatedServiceModelView>();
            CreateMap<UpdatedServiceModelView, Service>();
            CreateMap<CreateServiceModelView, Service>();
            
			CreateMap<Role, RoleModelView>();
			CreateMap<Role, CreateRoleModelView>();
			CreateMap<Role, UpdatedRoleModelView>();
			CreateMap<CreateRoleModelView, Role>();
			CreateMap<UpdatedRoleModelView, Role>();

            CreateMap<SalaryPayment, SalaryPaymentModelView>();    
            CreateMap<SalaryPayment, CreateSalaryPaymentModelView>();
            CreateMap<SalaryPayment, UpdatedSalaryPaymentModelView>();
			CreateMap<CreateSalaryPaymentModelView, SalaryPayment>();
			CreateMap<UpdatedSalaryPaymentModelView, SalaryPayment>();

			CreateMap<User, UserModelView>();
            CreateMap<User, CreateUserModelView>();
            CreateMap<User, UpdateUserModelView>();
            CreateMap<CreateUserModelView, User>();
            CreateMap<UpdateUserModelView, User>();

            

           
        }
    }
}
