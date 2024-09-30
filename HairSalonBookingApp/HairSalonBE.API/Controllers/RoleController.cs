using HairSalon.Contract.Services.Interface;
using HairSalon.Core.Base;
using HairSalon.Core;
using HairSalon.ModelViews.RoleModelViews;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HairSalonBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // Get All Roles
        [HttpGet("get_all_roles")]
        public async Task<ActionResult<BasePaginatedList<RoleModelView>>> GetAllRoles(int pageNumber = 1, int pageSize = 5)
        {
            var paginatedRoles = await _roleService.GetAllRoleAsync(pageNumber, pageSize);
            return Ok(BaseResponse<BasePaginatedList<RoleModelView>>.OkResponse(paginatedRoles));
        }

        // Create New Role
        [HttpPost("create_role")]
        public async Task<ActionResult<RoleModelView>> CreateRole([FromQuery] CreateRoleModelView model, string createdBy, string lastUpdatedBy)
        {
            var newRole = await _roleService.AddRoleAsync(model, createdBy, lastUpdatedBy);
            return Ok(BaseResponse<RoleModelView>.OkResponse(newRole));
        }

        // POST api/<Role>
        [HttpPost("update_role")]
        public async Task<ActionResult<RoleModelView>> UpdateRoleAsync(string id, [FromQuery] UpdatedRoleModelView model, string lastUpdatedBy)
        {
            var newRole = await _roleService.UpdateRoleAsync(id, model, lastUpdatedBy);
            return Ok(BaseResponse<RoleModelView>.OkResponse(newRole));
        }

        // PUT api/<Role>/5
        [HttpPut("delete_role")]
        public async Task<ActionResult<string>> DeleteRoleAsync([FromQuery] string id, string lastUpdatedBy)
        {
            string newRole = await _roleService.DeleteRoleAsync(id, lastUpdatedBy);
            return Ok(BaseResponse<RoleModelView>.OkResponse(newRole));
        }
    }
}
