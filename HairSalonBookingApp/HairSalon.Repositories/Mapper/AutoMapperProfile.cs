using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.ModelViews.RoleModelViews;
using HairSalon.ModelViews.ShopModelViews;

namespace HairSalon.Repositories.Mapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Shop, ShopModelView>();
            CreateMap<Role, RoleModelView>();

            CreateMap<Shop, CreateShopModelView>();
            CreateMap<Shop, UpdatedShopModelView>();
            CreateMap<Role, CreateRoleModelView>();
            CreateMap<Role, UpdatedRoleModelView>();

            CreateMap<CreateRoleModelView, Role>();
            CreateMap<UpdatedRoleModelView, Role>();
            CreateMap<UpdatedShopModelView, Shop>();
            CreateMap<CreateShopModelView, Shop>();
        }
    }
}
