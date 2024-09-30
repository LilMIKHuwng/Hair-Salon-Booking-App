using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ShopModelViews;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        // GET: api/Shop
        [HttpGet()]
        public async Task<ActionResult<BasePaginatedList<ShopModelView>>> GetAllShops(int pageNumber = 1, int pageSize = 5)
        {
            try
            {
                // Call service to get paginated list of shops
                var result = await _shopService.GetAllShopAsync(pageNumber, pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // GET: api/Shop/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopModelView>> GetShopById(string id)
        {
            try
            {
                // Call service to get shop by ID
                var result = await _shopService.GetShopAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // POST: api/Shop
        [HttpPost()]
        public async Task<ActionResult<ShopModelView>> CreateShop([FromQuery] CreateShopModelView model)
        {
            try
            {
                ShopModelView result = await _shopService.AddShopAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // PUT: api/Shop/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShop(string id, [FromQuery] UpdatedShopModelView model)
        {
            try
            {
                ShopModelView result = await _shopService.UpdateShopAsync(id, model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // DELETE: api/Shop/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShop(string id)
        {
            try
            {
                string result = await _shopService.DeleteShopAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
