using Azure.Core;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Core.Utils;
using HairSalon.ModelViews.TokenModelViews;
using HairSalon.Repositories.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HairSalon.Services.Service
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly RoleManager<ApplicationRoles> _roleManager;
        private readonly IUnitOfWork _unitOfWork;

        public TokenService(IConfiguration configuration, UserManager<ApplicationUsers> userManager, RoleManager<ApplicationRoles> roleManager, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<TokenModelView> GenerateJwtTokenAsync(string userId, string userName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var roles = await _userManager.GetRolesAsync(user ?? throw new Exception("User not found"));
            
            // Các claims của token
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(ClaimTypes.Name, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("userId", userId)
            };

            foreach (var role in roles) {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // Tạo token
            var token = CreateToken(claims);

            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);


            // Add refresh token to database
            await AddTokenToDatabaseAsync(userId, refreshToken);

            return new TokenModelView
            {
                AccessToken = tokenString,
                RefreshToken = refreshToken
            };
        }

        private async Task AddTokenToDatabaseAsync(string userId, string refreshToken)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var tokenRepository = _unitOfWork.GetRepository<ApplicationUserTokens>();

                try
                {
                    // Bắt đầu giao dịch
                    _unitOfWork.BeginTransaction();

                    var existingToken = tokenRepository.Entities
                        .FirstOrDefault(t => t.UserId == Guid.Parse(userId) && t.LoginProvider == "CustomLoginProvider");

                    if (existingToken != null)
                    {
                        // Cập nhật token hiện tại
                        existingToken.Value = refreshToken;
                        existingToken.LastUpdatedBy = user.UserName;
                        existingToken.LastUpdatedTime = CoreHelper.SystemTimeNow;

                        await tokenRepository.UpdateAsync(existingToken);
                    }
                    else
                    {
                        // Thêm token mới
                        var userToken = new ApplicationUserTokens
                        {
                            UserId = Guid.Parse(userId),
                            LoginProvider = "CustomLoginProvider",
                            Name = "JWT",
                            Value = refreshToken,
                            CreatedBy = user.UserName,
                            CreatedTime = CoreHelper.SystemTimeNow,
                            LastUpdatedBy = user.UserName,
                            LastUpdatedTime = CoreHelper.SystemTimeNow
                        };

                        await tokenRepository.InsertAsync(userToken);
                    }

                    // Lưu và commit giao dịch
                    await _unitOfWork.SaveAsync();
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception)
                {
                    // Rollback giao dịch nếu có lỗi xảy ra
                    _unitOfWork.RollBack();
                    throw;
                }
            }
        }
        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public async Task<TokenModelView> RefreshToken(TokenModelView tokenModel)
        {
            if (tokenModel is null)
            {
                throw new Exception("Token is null");
            }

            string? accessToken = tokenModel.AccessToken;
            string? refreshToken = tokenModel.RefreshToken;

            var principal = GetPrincipalFromExpiredToken(accessToken);
            if (principal == null)
            {
                throw new Exception("Principal");

            }

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            string username = principal.Identity.Name;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            var user = await _userManager.FindByNameAsync(username);
            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                throw new Exception("Some thing error in refresh");
            }

            var newAccessToken = CreateToken(principal.Claims.ToList());
            var newRefreshToken = GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            user.SecurityStamp = "a";
            await _userManager.UpdateAsync(user);

            return new()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken
            };
        }

        public async Task<string> Revoke(string username)
        {
            
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) return null;

            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);
            return "Ok";

        }

        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"])),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;

        }

    }
}
