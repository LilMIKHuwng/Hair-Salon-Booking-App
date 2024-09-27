using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.ModelViews.AppointmentModelViews;
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

            CreateMap<Appointment, AppointmentCreateModel>();
            CreateMap<AppointmentCreateModel, Appointment>();
            CreateMap<Appointment, AppointmentModelView>();
            CreateMap<Appointment, UpdateAppointmentModel>();
            CreateMap<UpdateAppointmentModel, Appointment>();
        }
    }
}
