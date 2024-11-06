﻿using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.ComboModelViews;
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

        public ComboController(IComboService comboService)
        {
            _comboService = comboService;
        }

        /// <summary>
        ///     Tạo combo
        /// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> CreateCombo([FromQuery] CreateComboModelView model)
        {
            var result = await _comboService.CreateComboAsync(model, null);

            return Ok(result);
        }

        /// <summary>
        ///     Lấy tất cả combo
        /// </summary>
        [HttpGet("all")]
        public async Task<ActionResult<BasePaginatedList<ComboModelView>>> GetAllCombos(int pageNumber = 1, int pageSize = 5, [FromQuery] string? id = null, [FromQuery] string? name = null)
        {
            var result = await _comboService.GetAllCombosAsync(pageNumber, pageSize, id, name);
            return Ok(result);
        }

        /// <summary>
        ///     Cập nhật combo
        /// </summary>
        [HttpPut("update/{id}")]
        public async Task<ActionResult<string>> UpdateCombo(string id, [FromQuery] UpdateComboModelView model)
        {
            var result = await _comboService.UpdateComboAsync(id, model, null);
            return Ok(result);
        }

        /// <summary>
        ///     Xóa combo
        /// </summary>
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCombo(string id)
        {
            var result = await _comboService.DeleteComboAsync(id, null);
            return Ok(result);
        }
	}
}
