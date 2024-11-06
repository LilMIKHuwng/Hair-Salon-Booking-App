using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.AuthModelViews;
using HairSalon.ModelViews.TokenModelViews;
using HairSalon.Repositories.Entity;
using HairSalon.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonBE.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService, IAppUserService userService) {
            _tokenService = tokenService;
            _appUserService = userService;
        }

        /// <summary>
        ///     Đăng nhập
        /// </summary>
        [HttpPost("auth-account")]
        public async Task<IActionResult> Login(LoginModelView model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Authenticate user
            ApplicationUsers account = await _appUserService.AuthenticateAsync(model);
            if (account == null)
            {
                return Unauthorized("Invalid credentials");
            }

            var token = await _tokenService.GenerateJwtTokenAsync(account.Id.ToString(), account.UserName);
            return Ok(token);
        }

        /// <summary>
        ///     Lấy refresh token
        /// </summary>
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(TokenModelView tokenModel)
        {
            var token = await _tokenService.RefreshToken(tokenModel);
            if (token != null)
            { 
                return Ok(token);
            }
            return BadRequest("Something error when Refresh Token");
        }

        /// <summary>
        ///     Đăng xuất
        /// </summary>
        [HttpPost("logout")]
        public async Task<IActionResult> Logout(string username)
        {
            var result = await _tokenService.Revoke(username);
            if (result == null)
            {
                return BadRequest("Can't find username");
            }
            return Ok();
        }
    }
}
