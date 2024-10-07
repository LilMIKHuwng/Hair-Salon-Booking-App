using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ShopModelViews;
using Microsoft.EntityFrameworkCore;
using HairSalon.Core.Base;
using HairSalon.Core.Constants;
using Microsoft.AspNetCore.Http;

namespace HairSalon.Services.Service
{
    public class ShopService : IShopService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;


        public ShopService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = httpContextAccessor;
        }

        public async Task<BasePaginatedList<ShopModelView>> GetAllShopAsync(int pageNumber, int pageSize, string searchName = null, string searchId = null)
        {
            try
            {
                IQueryable<Shop> shopQuery = _unitOfWork.GetRepository<Shop>().Entities
                    .Where(p => !p.DeletedTime.HasValue);

                if (!string.IsNullOrWhiteSpace(searchName))
                {
                    searchName = searchName.ToLower();
                    shopQuery = shopQuery.Where(s =>
                        s.Name.ToLower().Contains(searchName)
                    );
                }

                if (!string.IsNullOrWhiteSpace(searchId))
                {
                    shopQuery = shopQuery.Where(s => s.Id == searchId);
                }

                shopQuery = shopQuery.OrderByDescending(s => s.CreatedTime);

                int totalCount = await shopQuery.CountAsync();

                List<Shop> paginatedShops = await shopQuery
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                List<ShopModelView> shopModelViews = _mapper.Map<List<ShopModelView>>(paginatedShops);

                return new BasePaginatedList<ShopModelView>(shopModelViews, totalCount, pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                throw new BaseException.CoreException("GET_ALL_SHOPS_ERROR", "An error occurred while retrieving shops.", (int)StatusCodeHelper.ServerError);
            }
        }

        public async Task<ShopModelView> AddShopAsync(CreateShopModelView model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Name))
                {
                    throw new BaseException.BadRequestException("EMPTY_SHOP_NAME", "Shop name cannot be empty.");
                }

                Shop newShop = _mapper.Map<Shop>(model);

                newShop.Id = Guid.NewGuid().ToString("N");
                newShop.CreatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value; ;
                newShop.CreatedTime = DateTimeOffset.UtcNow;
                newShop.LastUpdatedTime = DateTimeOffset.UtcNow;

                await _unitOfWork.GetRepository<Shop>().InsertAsync(newShop);
                await _unitOfWork.SaveAsync();

                return _mapper.Map<ShopModelView>(newShop);
            }
            catch (BaseException.BadRequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BaseException.CoreException("ADD_SHOP_ERROR", "An error occurred while adding the shop.", (int)StatusCodeHelper.ServerError);
            }
        }

        public async Task<ShopModelView> UpdateShopAsync(string id, UpdatedShopModelView model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new BaseException.BadRequestException("INVALID_SHOP_ID", "Please provide a valid Shop ID.");
                }

                Shop existingShop = await _unitOfWork.GetRepository<Shop>().Entities
                    .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
                    ?? throw new BaseException.BadRequestException("SHOP_NOT_FOUND", "The Shop cannot be found or has been deleted!");

                bool isUpdated = false;

                // Manually map fields to retain existing data if the update fields are null
                if (!string.IsNullOrWhiteSpace(model.Name) && model.Name != existingShop.Name)
                {
                    existingShop.Name = model.Name;
                    isUpdated = true;
                }
                if (!string.IsNullOrWhiteSpace(model.Address) && model.Address != existingShop.Address)
                {
                    existingShop.Address = model.Address;
                    isUpdated = true;
                }
                if (!string.IsNullOrWhiteSpace(model.ShopEmail) && model.ShopEmail != existingShop.ShopEmail)
                {
                    existingShop.ShopEmail = model.ShopEmail;
                    isUpdated = true;
                }
                if (!string.IsNullOrWhiteSpace(model.ShopPhone) && model.ShopPhone != existingShop.ShopPhone)
                {
                    existingShop.ShopPhone = model.ShopPhone;
                    isUpdated = true;
                }
                if (model.OpenTime != default && model.OpenTime != existingShop.OpenTime)
                {
                    existingShop.OpenTime = model.OpenTime;
                    isUpdated = true;
                }
                if (model.CloseTime != default && model.CloseTime != existingShop.CloseTime)
                {
                    existingShop.CloseTime = model.CloseTime;
                    isUpdated = true;
                }
                if (!string.IsNullOrWhiteSpace(model.Title) && model.Title != existingShop.Title)
                {
                    existingShop.Title = model.Title;
                    isUpdated = true;
                }

                if (isUpdated)
                {
                    existingShop.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
                    existingShop.LastUpdatedTime = DateTimeOffset.UtcNow;

                    _unitOfWork.GetRepository<Shop>().Update(existingShop);
                    await _unitOfWork.SaveAsync();
                }

                return _mapper.Map<ShopModelView>(existingShop);
            }
            catch (BaseException.BadRequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BaseException.CoreException("UPDATE_SHOP_ERROR", "An error occurred while updating the shop.", (int)StatusCodeHelper.ServerError);
            }
        }



        public async Task<string> DeleteShopAsync(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new BaseException.BadRequestException("INVALID_SHOP_ID", "Please provide a valid Shop ID.");
                }

                Shop existingShop = await _unitOfWork.GetRepository<Shop>().Entities
                    .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
                    ?? throw new BaseException.BadRequestException("SHOP_NOT_FOUND", "The Shop cannot be found or has been deleted!");

                existingShop.DeletedTime = DateTimeOffset.UtcNow;
                existingShop.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value; ;

                _unitOfWork.GetRepository<Shop>().Update(existingShop);
                await _unitOfWork.SaveAsync();
                return "Deleted";
            }
            catch (BaseException.BadRequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BaseException.CoreException("DELETE_SHOP_ERROR", "An error occurred while deleting the shop.", (int)StatusCodeHelper.ServerError);
            }
        }

        public async Task<ShopModelView> GetShopAsync(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new BaseException.BadRequestException("INVALID_SHOP_ID", "Please provide a valid Shop ID.");
                }

                Shop existingShop = await _unitOfWork.GetRepository<Shop>().Entities
                    .FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
                    ?? throw new BaseException.BadRequestException("SHOP_NOT_FOUND", "The Shop cannot be found or has been deleted!");

                return _mapper.Map<ShopModelView>(existingShop);
            }
            catch (BaseException.BadRequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BaseException.CoreException("GET_SHOP_ERROR", "An error occurred while retrieving the shop.", (int)StatusCodeHelper.ServerError);
            }
        }
    }
}