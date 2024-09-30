using HairSalon.Contract.Services.Interface;
using HairSalon.Core.Base;
using HairSalon.Core;
using Microsoft.AspNetCore.Mvc;
using HairSalon.ModelViews.SalaryPaymentModelViews;
using HairSalon.ModelViews.RoleModelViews;
using HairSalon.Services.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HairSalonBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryPaymentController : ControllerBase
    {
        private readonly ISalaryPaymentService _salaryPaymentService;

        public SalaryPaymentController(ISalaryPaymentService salaryPaymentService)
        {
            _salaryPaymentService = salaryPaymentService;
        }

		[HttpGet()]
		public async Task<ActionResult<BasePaginatedList<SalaryPaymentModelView>>> GetAllSalaryPayments(int pageNumber = 1, int pageSize = 5)
		{
			try
			{
				var result = await _salaryPaymentService.GetAllSalaryPaymentAsync(pageNumber, pageSize);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<SalaryPaymentModelView>> GetSalaryPaymentById(string id)
		{
			try
			{
				var result = await _salaryPaymentService.GetSalaryPaymentAsync(id);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return NotFound(new { Message = ex.Message });
			}
		}

		[HttpPost()]
		public async Task<ActionResult<SalaryPaymentModelView>> CreateSalaryPayment([FromQuery] CreateSalaryPaymentModelView model)
		{
			try
			{
				SalaryPaymentModelView result = await _salaryPaymentService.AddSalaryPaymentAsync(model);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateSalaryPayment(string id, [FromQuery] UpdatedSalaryPaymentModelView model)
		{
			try
			{
				SalaryPaymentModelView result = await _salaryPaymentService.UpdateSalaryPaymentAsync(id, model);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSalaryPayment(string id)
		{
			try
			{
				string result = await _salaryPaymentService.DeleteSalaryPaymentAsync(id);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
		}
	}
}
