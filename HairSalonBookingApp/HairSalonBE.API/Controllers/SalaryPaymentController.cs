using HairSalon.Contract.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using HairSalon.ModelViews.SalaryPaymentModelViews;
using Microsoft.AspNetCore.Authorization;
using HairSalon.Core.Constants;
using HairSalon.Core.Base;
using HairSalon.Core;

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

        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllSalaryPayments(string? id, DateTime? paymentDate, int pageNumber = 1, int pageSize = 5)
        {
            var result = await _salaryPaymentService.GetAllSalaryPaymentAsync(id, paymentDate, pageNumber, pageSize);
            return Ok(new BaseResponse<BasePaginatedList<SalaryPaymentModelView>>(StatusCodeHelper.OK,
                                                                                 "Loaded data successfully!", result));
        }


        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<SalaryPaymentModelView>> CreateSalaryPayment
                                    ([FromQuery] CreateSalaryPaymentModelView model)
        {
            SalaryPaymentModelView result = await _salaryPaymentService.AddSalaryPaymentAsync(model);
            return Ok(new BaseResponse<SalaryPaymentModelView>(StatusCodeHelper.OK, "Created data succesfully!", result));
        }

        [HttpPut("update/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateSalaryPayment(string id, [FromQuery] UpdatedSalaryPaymentModelView model)
        {
            SalaryPaymentModelView result = await _salaryPaymentService.UpdateSalaryPaymentAsync(id, model);
            return Ok(new BaseResponse<SalaryPaymentModelView>(StatusCodeHelper.OK, "Updated data succesfully!", result));
        }

        [HttpDelete("delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteSalaryPayment(string id)
        {
            string result = await _salaryPaymentService.DeleteSalaryPaymentAsync(id);
            return Ok(new BaseResponse<SalaryPaymentModelView>(StatusCodeHelper.OK, "Deleted data succesfully!", result));
        }
    }
}
