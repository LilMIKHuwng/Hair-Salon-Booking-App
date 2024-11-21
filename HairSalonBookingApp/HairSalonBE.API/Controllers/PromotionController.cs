using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.PromotionModelViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _promotionService;

        public PromotionController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        /// <summary>
        ///     Create a new promotion
        /// </summary>
        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> CreatePromotion([FromQuery] CreatePromotionModelView model)
        {
            string result = await _promotionService.AddPromotionAsync(model, null);
            return Ok(result);
        }

        /// <summary>
        ///     Get all promotions with pagination
        /// </summary>
        [HttpGet("all")]
        public async Task<ActionResult<BasePaginatedList<PromotionModelView>>> GetAllPromotions(
            int pageNumber = 1,
            int pageSize = 5,
            string? name = null,
            string? code = null)
        {
            var result = await _promotionService.GetAllPromotionsAsync(pageNumber, pageSize, name, code);
            return Ok(result);
        }

        /// <summary>
        ///     Update an existing promotion
        /// </summary>
        [HttpPut("update/{promotionId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePromotion(string promotionId, [FromQuery] UpdatePromotionModelView model)
        {
            string result = await _promotionService.UpdatePromotionAsync(promotionId, model, null);
            return Ok(result);
        }

        /// <summary>
        ///     Delete a promotion
        /// </summary>
        [HttpDelete("delete/{promotionId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePromotion(string promotionId)
        {
            string result = await _promotionService.DeletePromotionAsync(promotionId, null);
            return Ok(result);
        }

        /// <summary>
        ///     Get promotion details by ID
        /// </summary>
        [HttpGet("details/{promotionId}")]
        public async Task<ActionResult<PromotionModelView>> GetPromotionDetails(string promotionId)
        {
            var result = await _promotionService.GetPromotionByIdAsync(promotionId);

            if (result == null)
            {
                return NotFound("Promotion not found");
            }

            return Ok(result);
        }
    }
}