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
using Microsoft.EntityFrameworkCore;

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
            // Find the user by their userId using the _userManager
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // Get the token repository from the unit of work
                var tokenRepository = _unitOfWork.GetRepository<ApplicationUserTokens>();

                try
                {
                    // Begin a database transaction to ensure atomicity
                    _unitOfWork.BeginTransaction();

                    // Check if there's already an existing token for the user with the specific login provider
                    var existingToken = tokenRepository.Entities
                        .FirstOrDefault(t => t.UserId == Guid.Parse(userId) && t.LoginProvider == "CustomLoginProvider");

                    if (existingToken != null)
                    {
                        // If an existing token is found, update it with the new refresh token
                        existingToken.Value = refreshToken;
                        existingToken.LastUpdatedBy = user.UserName;
                        existingToken.LastUpdatedTime = CoreHelper.SystemTimeNow;

                        // Update the existing token in the database
                        await tokenRepository.UpdateAsync(existingToken);
                    }
                    else
                    {
                        // If no existing token is found, create a new token record for the user
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

                        // Insert the new token into the repository
                        await tokenRepository.InsertAsync(userToken);
                    }

                    // Commit the transaction to save changes to the database
                    await _unitOfWork.SaveAsync();
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception)
                {
                    _unitOfWork.RollBack();
                    throw;
                }
            }
        }

        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            // Retrieve the signing key for JWT from the configuration and convert it to a byte array
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            // Try to parse the token validity duration in minutes from the configuration
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

            // Create a new JWT token with the specified claims and other properties
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"], 
                audience: _configuration["Jwt:Audience"], 
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes), 
                claims: authClaims, 
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256) 
            );

            // Return the created JWT token
            return token;
        }

        private string GenerateRefreshToken()
        {
            // Create a byte array to store the random number for the refresh token
            var randomNumber = new byte[64];

            // Create a secure random number generator
            using var rng = RandomNumberGenerator.Create();

            // Fill the byte array with random bytes
            rng.GetBytes(randomNumber);

            // Convert the random byte array to a Base64 string and return it as the refresh token
            return Convert.ToBase64String(randomNumber);
        }

        public async Task<TokenModelView> RefreshToken(TokenModelView tokenModel)
        {
            // Check if the provided token model is null
            if (tokenModel is null)
            {
                throw new Exception("Token is null");
            }

            // Retrieve the access token and refresh token from the token model
            string? accessToken = tokenModel.AccessToken;
            string? refreshToken = tokenModel.RefreshToken;

            // Extract the principal (user identity and claims) from the expired access token
            var principal = GetPrincipalFromExpiredToken(accessToken);
            if (principal == null)
            {
                throw new Exception("Principal"); 
            }

            // Get the username from the principal
            #pragma warning disable CS8600 
            #pragma warning disable CS8602 
            string username = principal.Identity.Name;
            #pragma warning restore CS8602 
            #pragma warning restore CS8600 

            // Find the user by username (from the database)
            var user = await _unitOfWork.GetRepository<ApplicationUsers>().Entities.
                FirstOrDefaultAsync(x => x.UserName == username);
            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                throw new Exception("Something went wrong with refresh"); 
            }

            // Create a new access token based on the claims of the expired token
            var newAccessToken = CreateToken(principal.Claims.ToList());

            // Generate a new refresh token
            var newRefreshToken = GenerateRefreshToken();

            // Update the user's refresh token in the database with the new token
            user.RefreshToken = newRefreshToken;

            // Optionally, update the user's security stamp (often used for invalidating sessions or triggering reauthentication)
            user.SecurityStamp = "a"; 

            // Save the updated user information to the database
            await _userManager.UpdateAsync(user);

            // Return the new access token and refresh token as a model
            return new TokenModelView()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken), // Serialize the new access token to a string
                RefreshToken = newRefreshToken // Return the new refresh token
            };
        }
        public async Task<string> Revoke(string username)
        {
            // Look up the user by their username
            var user = await _unitOfWork.GetRepository<ApplicationUsers>().Entities.
                FirstOrDefaultAsync(x => x.UserName == username);

            // If the user is not found, return null (indicating the revocation failed or the user does not exist)
            if (user == null) return null;

            // Remove the user's refresh token (revoking it)
            user.RefreshToken = null;

            // Update the user's information in the database to reflect the revoked token
            await _userManager.UpdateAsync(user);

            // Return a success message indicating the revocation was successful
            return "Ok";
        }

        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            // Define the parameters for validating the JWT token.
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, 
                ValidateIssuer = false,   
                ValidateIssuerSigningKey = true, 
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"])),
                ValidateLifetime = false  
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            // Validate the token and get the principal (claims) from it.
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            // Check that the token is a valid JWT token and that it uses the correct signing algorithm.
            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            // Return the principal (claims) extracted from the token.
            return principal;
        }

        public async Task<List<string>> GetUserRoles(string token)
        {
            var roles = new List<string>();

            try
            {
                var principal = GetPrincipalFromExpiredToken(token);
                if (principal == null) throw new Exception("Unable to get principal from token.");

                roles = principal.Claims
                    .Where(c => c.Type == ClaimTypes.Role)
                    .Select(c => c.Value)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while getting roles: {ex.Message}");
            }

            return roles;
        }
    }
}
