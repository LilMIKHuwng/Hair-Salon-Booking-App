using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ShopModelViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonBE.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        /// <summary>
		///		Lấy tất cả thông tin shop
		/// </summary>
        [HttpGet("all")]
        public async Task<ActionResult<BasePaginatedList<ShopModelView>>> GetAllShops(string? searchName, string? searchId, int pageNumber = 1, int pageSize = 5)
        {
            var result = await _shopService.GetAllShopAsync(pageNumber, pageSize, searchName, searchId);
            return Ok(result);
        }

        /// <summary>
		///		Tạo thông tin shop
		/// </summary>
        [HttpPost("create")]
        public async Task<ActionResult<ShopModelView>> CreateShop([FromQuery] CreateShopModelView model)
        {
            string result = await _shopService.AddShopAsync(model);
            return Ok(result);

        }

        /// <summary>
		///		Cập nhật thông tin shop
		/// </summary>
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateShop(string id, [FromQuery] UpdatedShopModelView model)
        {
            string result = await _shopService.UpdateShopAsync(id, model);
            return Ok(result);
        }

        /// <summary>
		///		Xóa shop
		/// </summary>
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteShop(string id)
        {
            string result = await _shopService.DeleteShopAsync(id);
            return Ok(result);

        }
    }
}
