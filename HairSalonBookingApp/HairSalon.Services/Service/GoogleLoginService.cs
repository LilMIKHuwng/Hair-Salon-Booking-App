using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.ApplicationUserModelViews;
using HairSalon.ModelViews.TokenModelViews;
using HairSalon.Repositories.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;

namespace HairSalon.Services.Service
{
	public class GoogleLoginService : IGoogleLoginService
	{
		private readonly IAppUserService _appUserService;
		private readonly TokenService _tokenService;
		private readonly IConfiguration _configuration;
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GoogleLoginService(IAppUserService appUserService, TokenService tokenService, IConfiguration configuration, IHttpClientFactory httpClientFactory, 
			IUnitOfWork unitOfWork, IMapper mapper)
		{
			_appUserService = appUserService;
			_tokenService = tokenService;
			_configuration = configuration;
			_httpClientFactory = httpClientFactory;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<string> GetGoogleLoginUrl()
		{
			var clientId = _configuration["Authentication:Google:ClientId"];
			var redirectUri = _configuration["Authentication:Google:RedirectUri"];
			string url = $"https://accounts.google.com/o/oauth2/v2/auth?client_id={clientId}&redirect_uri={redirectUri}&response_type=code&scope=openid profile email";
			return url;
		}

		public async Task<TokenModelView> GetTokenFromCode(string code)
		{
			try
			{
				var redirectUri = _configuration["Authentication:Google:RedirectUri"];

				// check can get google code or not
				if (string.IsNullOrEmpty(code))
				{
					throw new Exception("No code received from Google");
				}

				// genarate tokenResponse from code
				var tokenResponse = await GetGoogleAccessTokenAsync(code, redirectUri);
				if (tokenResponse == null || string.IsNullOrEmpty(tokenResponse.AccessToken))
				{
					throw new Exception("Failed to retrieve access token from Google");
				}

				// get user infor from Google
				var userInfo = await GetGoogleUserInfoAsync(tokenResponse.AccessToken);
				var user = await _appUserService.GetUserByEmailAsync(userInfo.Email);
				if (user == null)
				{
					user = await CreateAccount(userInfo);
				}

				var token = await _tokenService.GenerateJwtTokenAsync(user.Id, user.UserName);

				return token;
			}
			catch (Exception ex)
			{
				throw new Exception($"Error get token from google code: {ex.Message}", ex);
			}

		}

		
		private async Task<TokenResponseModelView> GetGoogleAccessTokenAsync(string code, string redirectUri)
		{
			try
			{
				var client = _httpClientFactory.CreateClient();

				var requestData = new Dictionary<string, string>
				{
					{ "code", code },
					{ "client_id", _configuration["Authentication:Google:ClientId"] },
					{ "client_secret", _configuration["Authentication:Google:ClientSecret"] },
					{ "redirect_uri", redirectUri },
					{ "grant_type", "authorization_code" }
				};

				var requestContent = new FormUrlEncodedContent(requestData);
				var response = await client.PostAsync("https://oauth2.googleapis.com/token", requestContent);
				var stream = await response.Content.ReadAsStreamAsync();

				using (var reader = new StreamReader(stream))
				{
					var rawContent = await reader.ReadToEndAsync();
					Console.WriteLine("Raw Response Stream: " + rawContent);
				}

				if (!response.IsSuccessStatusCode)
				{
					return null;
				}

				var content = await response.Content.ReadAsStringAsync();
				return JsonSerializer.Deserialize<TokenResponseModelView>(content);
			}
			catch (Exception ex)
			{
				throw new Exception($"Error GetGoogleAccessTokenAsync: {ex.Message}", ex);
			}
		}

		
		private async Task<UserInfoModelView> GetGoogleUserInfoAsync(string accessToken)
		{
			try
			{
				var client = _httpClientFactory.CreateClient();
				var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://www.googleapis.com/oauth2/v2/userinfo");
				requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

				var response = await client.SendAsync(requestMessage);
				if (!response.IsSuccessStatusCode)
				{
					throw new Exception("Error retrieving user info from Google.");
				}

				var content = await response.Content.ReadAsStringAsync();
				return JsonSerializer.Deserialize<UserInfoModelView>(content);
			}
			catch (Exception ex)
			{
				throw new Exception($"Error GetGoogleUserInfoAsync: {ex.Message}", ex);
			}
		}

		private async Task<AppUserModelView> CreateAccount(UserInfoModelView model)
		{
			// create user infor
			var userInfo = new UserInfo
			{
				Firstname = model.GivenName,
				Lastname = model.FamilyName,
			};

			// create application user
			var newAccount = new ApplicationUsers
			{
				Id = Guid.NewGuid(),
				UserName = model.Email.Split('@')[0],
				Email = model.Email,
				SecurityStamp = Guid.NewGuid().ToString(),
				UserInfo = userInfo
			};

			// create ApplicationUserRoles
			var userRole = await _unitOfWork.GetRepository<ApplicationRoles>().Entities.FirstOrDefaultAsync(r => r.Name == "User");

			var applicationUserRole = new ApplicationUserRoles
			{
				UserId = newAccount.Id,
				RoleId = userRole.Id,
				CreatedBy = newAccount.Id.ToString(),
				CreatedTime = DateTime.UtcNow,
				LastUpdatedBy = newAccount.Id.ToString(),
				LastUpdatedTime = DateTime.UtcNow
			};

			// save changes
			await _unitOfWork.GetRepository<ApplicationUserRoles>().InsertAsync(applicationUserRole);

			await _unitOfWork.GetRepository<ApplicationUsers>().InsertAsync(newAccount);
			await _unitOfWork.SaveAsync();
			AppUserModelView userModelView = _mapper.Map<AppUserModelView>(newAccount);

			return userModelView;
		}
	}
}
