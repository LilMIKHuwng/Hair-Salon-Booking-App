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

        [HttpGet("all")]
        public async Task<ActionResult<BasePaginatedList<ShopModelView>>> GetAllShops(int pageNumber = 1, int pageSize = 5, string searchName = null, string searchId = null)
        {
            var result = await _shopService.GetAllShopAsync(pageNumber, pageSize, searchName, searchId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShopModelView>> GetShopById(string id)
        {
            var result = await _shopService.GetShopAsync(id);
            return Ok(result);

        }

        [HttpPost()]
        public async Task<ActionResult<ShopModelView>> CreateShop([FromQuery] CreateShopModelView model)
        {
            string result = await _shopService.AddShopAsync(model);
            return Ok(result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShop(string id, [FromQuery] UpdatedShopModelView model)
        {
            string result = await _shopService.UpdateShopAsync(id, model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShop(string id)
        {
            string result = await _shopService.DeleteShopAsync(id);
            return Ok(result);

        }
    }
}
