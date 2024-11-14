using HairSalon.Contract.Services.Interface;
using HairSalon.Contract.Services.Cache;
using HairSalon.Core;
using HairSalon.ModelViews.ShopModelViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using HairSalon.ModelViews.RoleModelViews;

namespace HairSalonBE.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;
        private readonly ICacheService _cacheService;
        private const string ShopCachePrefix = "Shops";


        public ShopController(IShopService shopService, ICacheService cacheService)
        {
            _shopService = shopService;
            _cacheService = cacheService;
        }

        /// <summary>
		///		Lấy tất cả thông tin shop
		/// </summary>
        [HttpGet("all")]
        public async Task<ActionResult<BasePaginatedList<ShopModelView>>> GetAllShops(string? searchName, string? searchId, int pageNumber = 1, int pageSize = 5)
        {
            string cacheKey = $"{ShopCachePrefix}_Page{pageNumber}_Size{pageSize}_Id{searchId}_Name{searchName}";

            var cachedData = await _cacheService.GetListAsync<BasePaginatedList<ShopModelView>>(cacheKey);
            if (cachedData != null)
            {
                return Ok(cachedData);
            }

            var result = await _shopService.GetAllShopAsync(pageNumber, pageSize, searchName, searchId);
            await _cacheService.SetAsync(cacheKey, result, TimeSpan.FromMinutes(10), ShopCachePrefix);
            return Ok(result);
        }

        /// <summary>
		///		Tạo thông tin shop
		/// </summary>
        [HttpPost("create")]
        public async Task<ActionResult<ShopModelView>> CreateShop([FromQuery] CreateShopModelView model)
        {
            string result = await _shopService.AddShopAsync(model, null);
            await _cacheService.RemoveByPrefixAsync(ShopCachePrefix);
            return Ok(result);
        }

        /// <summary>
		///		Cập nhật thông tin shop
		/// </summary>
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateShop(string id, [FromQuery] UpdatedShopModelView model)
        {
            string result = await _shopService.UpdateShopAsync(id, model, null);
            await _cacheService.RemoveByPrefixAsync(ShopCachePrefix);
            return Ok(result);
        }

        /// <summary>
		///		Xóa shop
		/// </summary>
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteShop(string id)
        {
            string result = await _shopService.DeleteShopAsync(id, null);
            await _cacheService.RemoveByPrefixAsync(ShopCachePrefix);
            return Ok(result);

        }
    }
}
