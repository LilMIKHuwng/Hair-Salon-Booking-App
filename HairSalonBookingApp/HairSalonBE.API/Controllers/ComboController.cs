using HairSalon.Contract.Services.Cache;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ComboModelViews;
using HairSalon.ModelViews.RoleModelViews;
using HairSalon.Services.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonBE.API.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    [Route("api/[controller]")]
    [ApiController]

    public class ComboController : ControllerBase
    {
        private readonly IComboService _comboService;
        private readonly ICacheService _cacheService;
        private const string ComboCachePrefix = "Combo";

        public ComboController(IComboService comboService, ICacheService cacheService)
        {
            _comboService = comboService;
            _cacheService = cacheService;
        }

        /// <summary>
        ///     Tạo combo
        /// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> CreateCombo([FromQuery] CreateComboModelView model)
        {
            var result = await _comboService.CreateComboAsync(model, null);

            // Clear all cached entries with the "Combo" prefix
            await _cacheService.RemoveByPrefixAsync(ComboCachePrefix);

            return Ok(new { Message = result });
        }

        /// <summary>
        ///     Lấy tất cả combo
        /// </summary>
        [HttpGet("all")]
        public async Task<ActionResult<BasePaginatedList<ComboModelView>>> GetAllCombos(int pageNumber = 1, int pageSize = 5, [FromQuery] string? id = null, [FromQuery] string? name = null)
        {
            // Generate a unique cache key for this combination of parameters
            string cacheKey = $"{ComboCachePrefix}_Page{pageNumber}_Size{pageSize}_Id{id}_Name{name}";

            // Try to retrieve data from cache
            var cachedData = await _cacheService.GetListAsync<BasePaginatedList<ComboModelView>>(cacheKey);
            if (cachedData != null)
            {
                return Ok(cachedData);
            }

            // If cache miss, retrieve from service
            var result = await _comboService.GetAllCombosAsync(pageNumber, pageSize, id, name);

            // Store the result in cache with the specified prefix
            await _cacheService.SetAsync(cacheKey, result, TimeSpan.FromMinutes(10), ComboCachePrefix);

            return Ok(result);
        }

        /// <summary>
        ///     Cập nhật combo
        /// </summary>
        [HttpPut("update/{id}")]
        public async Task<ActionResult<string>> UpdateCombo(string id, [FromQuery] UpdateComboModelView model)
        {

            string result = await _comboService.UpdateComboAsync(id, model, null);

            // Clear all cached entries with the "Combo" prefix
            await _cacheService.RemoveByPrefixAsync(ComboCachePrefix);

            return Ok(new { Message = result });
        }

        /// <summary>
        ///     Xóa combo
        /// </summary>
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCombo(string id)
        {
            var result = await _comboService.DeleteComboAsync(id, null);

            // Clear all cached entries with the "Combo" prefix
            await _cacheService.RemoveByPrefixAsync(ComboCachePrefix);

            return Ok(new { Message = result });
        }
	}
}
