using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Core.Utils;
using HairSalon.Repositories.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Services.Service
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public TokenService(IConfiguration configuration, UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> GenerateJwtTokenAsync(string userId, string userName)
        {
            // Các claims của token
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, userName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("userId", userId)
        };

            // Tạo khóa bí mật để ký token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Tạo token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            // Thêm token vào bảng ApplicationUserTokens bằng cách sử dụng UnitOfWork
            await AddTokenToDatabaseAsync(userId, tokenString);

            return tokenString;
        }

        private async Task AddTokenToDatabaseAsync(string userId, string tokenString)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var tokenRepository = _unitOfWork.GetRepository<ApplicationUserTokens>();

                try
                {
                    // Bắt đầu giao dịch
                    _unitOfWork.BeginTransaction();

                    var existingToken = await tokenRepository.Entities
                        .FirstOrDefaultAsync(t => t.UserId == Guid.Parse(userId) && t.LoginProvider == "CustomLoginProvider");

                    if (existingToken != null)
                    {
                        // Cập nhật token hiện tại
                        existingToken.Value = tokenString;
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
                            Value = tokenString,
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


    }
}
