using HairSalon.Contract.Services.Interface;
using HairSalon.Core.Base;
using HairSalon.Core;
using Microsoft.AspNetCore.Mvc;
using HairSalon.ModelViews.SalaryPaymentModelViews;

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

        // Get All Roles
        [HttpGet("get_all_roles")]
        public async Task<ActionResult<BasePaginatedList<SalaryPaymentModelView>>> GetAllRoles(int pageNumber = 1, int pageSize = 5)
        {
            var paginatedRoles = await _salaryPaymentService.GetAllSalaryPaymentAsync(pageNumber, pageSize);
            return Ok(BaseResponse<BasePaginatedList<SalaryPaymentModelView>>.OkResponse(paginatedRoles));
        }

        // Create New Role
        [HttpPost("create_role")]
        public async Task<ActionResult<SalaryPaymentModelView>> CreateRole([FromQuery] CreateSalaryPaymentModelView model, string createdBy, string lastUpdatedBy)
        {
            
            var newSalaryPayment = await _salaryPaymentService.AddSalaryPaymentAsync(model, createdBy, lastUpdatedBy);
            return Ok(BaseResponse<SalaryPaymentModelView>.OkResponse(newSalaryPayment));
        }

        // POST api/<Role>
        [HttpPost("update_role")]
        public async Task<ActionResult<SalaryPaymentModelView>> UpdateRoleAsync(string id, [FromQuery] UpdatedSalaryPaymentModelView model, string lastUpdatedBy)
        {
            var updatedSalaryPayment = await _salaryPaymentService.UpdateSalaryPaymentAsync(id, model, lastUpdatedBy);
            return Ok(BaseResponse<SalaryPaymentModelView>.OkResponse(updatedSalaryPayment));
        }

        // PUT api/<Role>/5
        [HttpPut("delete_role")]
        public async Task<ActionResult<string>> DeleteRoleAsync([FromQuery] string id, string lastUpdatedBy)
        {
            string deleteMessage = await _salaryPaymentService.DeleteSalaryPaymentAsync(id, lastUpdatedBy);
            return Ok(BaseResponse<SalaryPaymentModelView>.OkResponse(deleteMessage));
        }
    }
}
