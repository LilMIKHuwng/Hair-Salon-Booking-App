using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ShopModelViews;
using Microsoft.EntityFrameworkCore;
using HairSalon.Core.Base;
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

		public async Task<BasePaginatedList<ShopModelView>> GetAllShopAsync
			(int pageNumber, int pageSize, string? searchName, string? searchId)
		{
			IQueryable<Shop> shopQuery = _unitOfWork.GetRepository<Shop>().Entities
				.Where(p => !p.DeletedTime.HasValue);

			if (!string.IsNullOrWhiteSpace(searchName))
			{
				searchName = searchName.ToLower();
				shopQuery = shopQuery.Where(s => s.Name.ToLower().Contains(searchName));
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

		public async Task<string> AddShopAsync(CreateShopModelView model)
		{
			try
			{
				Shop newShop = _mapper.Map<Shop>(model);

				newShop.Id = Guid.NewGuid().ToString("N");
				newShop.CreatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
				newShop.CreatedTime = DateTimeOffset.UtcNow;
				newShop.LastUpdatedTime = DateTimeOffset.UtcNow;

				await _unitOfWork.GetRepository<Shop>().InsertAsync(newShop);
				await _unitOfWork.SaveAsync();

				return "Added new shop successfully!";
			}
			catch (BaseException.BadRequestException ex)
			{
				return ex.Message;
			}
			catch (Exception ex)
			{
				return "An error occurred while adding the shop.";
			}
		}
		public async Task<string> UpdateShopAsync(string id, UpdatedShopModelView model)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(id))
				{
					return "Please provide a valid Shop ID.";
				}

				Shop? existingShop = await _unitOfWork.GetRepository<Shop>().Entities
					.FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue);

				if (existingShop == null)
				{
					return "The Shop cannot be found or has been deleted!";
				}

				// Manually map fields to retain existing data if the update fields are null
				if (!string.IsNullOrWhiteSpace(model.Name) && model.Name != existingShop.Name)
				{
					existingShop.Name = model.Name;
				}
				if (!string.IsNullOrWhiteSpace(model.Address) && model.Address != existingShop.Address)
				{
					existingShop.Address = model.Address;
				}
				if (!string.IsNullOrWhiteSpace(model.ShopEmail) && model.ShopEmail != existingShop.ShopEmail)
				{
					existingShop.ShopEmail = model.ShopEmail;
				}
				if (!string.IsNullOrWhiteSpace(model.ShopPhone) && model.ShopPhone != existingShop.ShopPhone)
				{
					existingShop.ShopPhone = model.ShopPhone;
				}
				if (model.OpenTime != null && model.OpenTime != existingShop.OpenTime)
				{
					existingShop.OpenTime = (TimeSpan)model.OpenTime;
				}
				if (model.CloseTime != null && model.CloseTime != existingShop.CloseTime)
				{
					existingShop.CloseTime = (TimeSpan)model.CloseTime;
				}
				if (!string.IsNullOrWhiteSpace(model.Title) && model.Title != existingShop.Title)
				{
					existingShop.Title = model.Title;
				}

				existingShop.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
				existingShop.LastUpdatedTime = DateTimeOffset.UtcNow;

				_unitOfWork.GetRepository<Shop>().Update(existingShop);
				await _unitOfWork.SaveAsync();

				return "Updated shop successfully";
			}
			catch (BaseException.BadRequestException ex)
			{
				return ex.Message;
			}
			catch (Exception ex)
			{
				return "An error occurred while updating the shop.";
			}
		}

		public async Task<string> DeleteShopAsync(string id)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(id))
				{
					return "Please provide a valid Shop ID.";
				}

				Shop existingShop = await _unitOfWork.GetRepository<Shop>().Entities
					.FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue);

				if (existingShop == null)
				{
					return "The Shop cannot be found or has been deleted!";
				}

				existingShop.DeletedTime = DateTimeOffset.UtcNow;
				existingShop.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;

				_unitOfWork.GetRepository<Shop>().Update(existingShop);
				await _unitOfWork.SaveAsync();
				return "Deleted shop successfully!";
			}
			catch (BaseException.BadRequestException ex)
			{
				return ex.Message;
			}
			catch (Exception ex)
			{
				return "An error occurred while deleting the shop.";
			}
		}
	}
}