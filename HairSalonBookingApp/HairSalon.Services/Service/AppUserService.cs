using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.Core.Base;
using HairSalon.Core.Utils;
using HairSalon.ModelViews.ApplicationUserModelViews;
using HairSalon.ModelViews.AuthModelViews;
using HairSalon.Repositories.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace HairSalon.Services.Service
{
    public class AppUserService : IAppUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IEmailService _emailService;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly IPasswordHasher<ApplicationUsers> _passwordHasher;

        public AppUserService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IEmailService emailService, UserManager<ApplicationUsers> userManager, IPasswordHasher<ApplicationUsers> passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = httpContextAccessor;
            _emailService = emailService;
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }

        /*public async Task<string> AddAppUserAsync(CreateAppUserModelView model)
		{
			var userInfo = new UserInfo
			{
				Firstname = model.FirstName,
				Lastname = model.LastName,

			};
            _passwordHasher = passwordHasher;
        }

        public async Task<string> AddAppUserAsync(CreateAppUserModelView model)
        {
            // Check for special characters in FirstName and LastName
            var regex = new Regex(@"^[a-zA-Z]+$");
            if (!regex.IsMatch(model.FirstName))
            {
                return "FirstName cannot contains special characters!";
            }

            if (!regex.IsMatch(model.LastName))
            {
                return "LastName cannot contains special characters!";
            }

            // Check if the username already exists
            var accountRepository = _unitOfWork.GetRepository<ApplicationUsers>();
            var existingUser = await accountRepository.Entities
                                                    .AsNoTracking()
                                                    .FirstOrDefaultAsync(x => x.UserName == model.UserName);
            if (existingUser != null)
            {
                return "UserName is already existed!";
            }

            // Create new user info and account
            var userInfo = new UserInfo
            {
                Firstname = model.FirstName,
                Lastname = model.LastName,
            };
            var newAccount = new ApplicationUsers
            {
                Id = Guid.NewGuid(),
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserInfo = userInfo
            };

            newAccount.PasswordHash = _passwordHasher.HashPassword(newAccount, model.Password);

            var accountRepositoryCheck = _unitOfWork.GetRepository<ApplicationUsers>();

            var user = await accountRepositoryCheck.Entities.FirstOrDefaultAsync(x => x.UserName == model.UserName);
            if (user != null)
            {
                throw new Exception("Duplicate");
            }

            accountRepository = _unitOfWork.GetRepository<ApplicationUsers>();
            await accountRepository.InsertAsync(newAccount);

            // Check if the user role exists
            var roleRepository = _unitOfWork.GetRepository<ApplicationRoles>();
            var userRole = await roleRepository.Entities.FirstOrDefaultAsync(r => r.Name == model.RoleName);
            if (userRole == null)
            {
                return "The 'User' role does not exist. Please make sure to create it first.";
            }

            // Create and insert user role mapping
            var userRoleRepository = _unitOfWork.GetRepository<ApplicationUserRoles>();
            var applicationUserRole = new ApplicationUserRoles
            {
                UserId = newAccount.Id,
                RoleId = userRole.Id,
                CreatedBy = newAccount.Id.ToString(),
                CreatedTime = DateTime.UtcNow,
                LastUpdatedBy = newAccount.Id.ToString(),
                LastUpdatedTime = DateTime.UtcNow
            };

			await userRoleRepository.InsertAsync(applicationUserRole);
			await _unitOfWork.SaveAsync();

			return "User added successfully.";
		}*/

        public async Task<string> AddAppUserAsync(CreateAppUserModelView model)
        {
            var accountRepo = _unitOfWork.GetRepository<ApplicationUsers>();
            var existingUser = await accountRepo.Entities.FirstOrDefaultAsync(x => x.UserName == model.UserName);
            if (existingUser != null) return "User with this username already exists.";

            var userInfo = new UserInfo
            {
                Firstname = model.FirstName,
                Lastname = model.LastName
            };

            var newUser = new ApplicationUsers
            {
                Id = Guid.NewGuid(),
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                PasswordHash = model.Password,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserInfo = userInfo,
                
            };

            await accountRepo.InsertAsync(newUser);
            await _unitOfWork.SaveAsync();

            // Tạo mã OTP
            var otpCode = GenerateOtpCode();
            newUser.OtpCode = otpCode;
            newUser.OtpExpiration = DateTime.UtcNow.AddMinutes(10); // OTP hết hạn sau 10 phút

            await _unitOfWork.SaveAsync();

            // Gửi mã OTP qua email
            await _emailService.SendEmailConfirmationCodeAsync(newUser.Email, otpCode);

            return "User added successfully. Please check your email for the OTP to confirm your account.";
        }

        public async Task<string> ConfirmEmailAsync(ConfirmEmailModelView model)
        {
            var accountRepo = _unitOfWork.GetRepository<ApplicationUsers>();
            var user = await accountRepo.Entities.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null) return "Invalid email.";

            // Kiểm tra mã OTP và thời gian hết hạn
            if (user.OtpCode != model.OtpCode || user.OtpExpiration < DateTime.UtcNow)
            {
                return "Invalid or expired OTP code.";
            }

            // Xác nhận tài khoản
            user.EmailConfirmed = true;
            user.OtpCode = null; // Xóa mã OTP sau khi xác nhận
            user.OtpExpiration = null;

            await _unitOfWork.SaveAsync();

            return "Email confirmed successfully. Your account is now active.";
        }

        private string GenerateOtpCode()
        {
            var random = new Random();
            return random.Next(1000, 9999).ToString(); // Tạo mã OTP 4 số
        }

        public async Task<string> DeleteAppUserAsync(string id)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				return "Please provide a valid Application User ID.";
			}

			var existingUser = await _unitOfWork.GetRepository<ApplicationUsers>().Entities
				.FirstOrDefaultAsync(s => s.Id == Guid.Parse(id) && !s.DeletedTime.HasValue);

			if (existingUser == null)
			{
				return "The Application User cannot be found or has been deleted!";
			}

			existingUser.DeletedTime = DateTimeOffset.UtcNow;
			existingUser.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;

            _unitOfWork.GetRepository<ApplicationUsers>().Update(existingUser);
            await _unitOfWork.SaveAsync();
            return "Deleted user successfully!";
        }

        public async Task<BasePaginatedList<AppUserModelView>> GetAllAppUserAsync(string? userId, int pageNumber, int pageSize)
        {
            IQueryable<ApplicationUsers> roleQuery = _unitOfWork.GetRepository<ApplicationUsers>().Entities
                .Where(p => !p.DeletedTime.HasValue);

            // Apply filtering by userId if provided
            if (!string.IsNullOrEmpty(userId))
            {
                roleQuery = roleQuery.Where(u => u.Id.ToString() == userId);
            }

            // Order by CreatedTime descending
            roleQuery = roleQuery.OrderByDescending(s => s.CreatedTime);

            // Get total count
            int totalCount = await roleQuery.CountAsync();

            // Get paginated results
            List<ApplicationUsers> paginatedUsers = await roleQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Map to AppUserModelView
            List<AppUserModelView> appUserModelViews = _mapper.Map<List<AppUserModelView>>(paginatedUsers);

            // Return paginated list
            return new BasePaginatedList<AppUserModelView>(appUserModelViews, totalCount, pageNumber, pageSize);
        }

        public async Task<string> UpdateAppUserAsync(string id, UpdateAppUserModelView model)
        {

            if (string.IsNullOrWhiteSpace(id))
            {
                return "Please provide a valid Application User ID.";
            }

            // Retrieve the existing user
            ApplicationUsers? existingUser = await _unitOfWork.GetRepository<ApplicationUsers>().Entities
                .FirstOrDefaultAsync(u => u.Id == Guid.Parse(id) && !u.DeletedTime.HasValue);

            if (existingUser == null)
            {
                return "The Application User cannot be found or has been deleted!";
            }

            bool isUpdated = false;

            // Manually map fields to retain existing data if the update fields are null
            if (!string.IsNullOrWhiteSpace(model.Email) && model.Email != existingUser.Email)
            {
                existingUser.Email = model.Email;
                isUpdated = true;
            }
            if (!string.IsNullOrWhiteSpace(model.PhoneNumber) && model.PhoneNumber != existingUser.PhoneNumber)
            {
                existingUser.PhoneNumber = model.PhoneNumber;
                isUpdated = true;
            }

            // Retrieve associated UserInfo if available
            UserInfo? existingUserInfo = await _unitOfWork.GetRepository<UserInfo>().Entities
                .FirstOrDefaultAsync(u => u.Id == existingUser.UserInfo.Id);

            if (existingUserInfo != null)
            {
                if (!string.IsNullOrWhiteSpace(model.FirstName) && model.FirstName != existingUserInfo.Firstname)
                {
                    existingUserInfo.Firstname = model.FirstName;
                    isUpdated = true;
                }
                if (!string.IsNullOrWhiteSpace(model.LastName) && model.LastName != existingUserInfo.Lastname)
                {
                    existingUserInfo.Lastname = model.LastName;
                    isUpdated = true;
                }

                if (isUpdated)
                {
                    existingUserInfo.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
                    existingUserInfo.LastUpdatedTime = DateTimeOffset.UtcNow;
                    _unitOfWork.GetRepository<UserInfo>().Update(existingUserInfo);
                }
            }

            if (isUpdated)
            {
                existingUser.LastUpdatedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;
                existingUser.LastUpdatedTime = DateTimeOffset.UtcNow;
                _unitOfWork.GetRepository<ApplicationUsers>().Update(existingUser);
                await _unitOfWork.SaveAsync();
            }

            return "Updated user successfully!";

        }

        public async Task<ApplicationUsers> AuthenticateAsync(LoginModelView model)
        {
            var accountRepository = _unitOfWork.GetRepository<ApplicationUsers>();

            // Find the user by Username
            var user = await accountRepository.Entities
                .FirstOrDefaultAsync(x => x.UserName == model.Username && x.EmailConfirmed == true);

            if (user == null)
            {
                return null; // User does not exist
            }

            // Verify the password
            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                return null; // Password does not match
            }

            // Check if a login record already exists
            var loginRepository = _unitOfWork.GetRepository<ApplicationUserLogins>();
            var existingLogin = await loginRepository.Entities
                .FirstOrDefaultAsync(x => x.UserId == user.Id && x.LoginProvider == "CustomLoginProvider");

            if (existingLogin == null)
            {
                // If no login record exists, add a new one
                var loginInfo = new ApplicationUserLogins
                {
                    UserId = user.Id, // UserId from the authenticated user
                    ProviderKey = user.Id.ToString(),
                    LoginProvider = "CustomLoginProvider", // Or another provider name
                    ProviderDisplayName = "Standard Login",
                    CreatedBy = user.UserName, // Record who performed the login
                    CreatedTime = CoreHelper.SystemTimeNow,
                    LastUpdatedBy = user.UserName,
                    LastUpdatedTime = CoreHelper.SystemTimeNow
                };

                await loginRepository.InsertAsync(loginInfo);
                await _unitOfWork.SaveAsync(); // Save changes to the database
            }
            else
            {
                // If the login record already exists, update it if necessary
                existingLogin.LastUpdatedBy = user.UserName;
                existingLogin.LastUpdatedTime = CoreHelper.SystemTimeNow;

                await loginRepository.UpdateAsync(existingLogin);
                await _unitOfWork.SaveAsync(); // Save changes to the database
            }

            return user; // Return the authenticated user
        }

public async Task<BasePaginatedList<AppUserModelView>> GetAllAppUserAsync(int pageNumber, int pageSize, string id, string email, string phoneNumber)
		{
			// Start building the query
			IQueryable<ApplicationUsers> userQuery = _unitOfWork.GetRepository<ApplicationUsers>().Entities
				.Where(p => !p.DeletedTime.HasValue)
				.OrderByDescending(s => s.CreatedTime);

			// Apply filtering by Id, Email, and PhoneNumber if provided
			if (!string.IsNullOrWhiteSpace(id))
			{
				userQuery = userQuery.Where(p => p.Id.ToString() == id);
			}

			if (!string.IsNullOrWhiteSpace(email))
			{
				userQuery = userQuery.Where(p => p.Email.Contains(email));
			}

			if (!string.IsNullOrWhiteSpace(phoneNumber))
			{
				userQuery = userQuery.Where(p => p.PhoneNumber.Contains(phoneNumber));
			}

			// Get total count of records after filtering
			int totalCount = await userQuery.CountAsync();

			// Apply pagination
			List<ApplicationUsers> paginatedUsers = await userQuery
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

			// Map entities to model views
			List<AppUserModelView> appUserModelViews = _mapper.Map<List<AppUserModelView>>(paginatedUsers);

			// Return the paginated list with users
			return new BasePaginatedList<AppUserModelView>(appUserModelViews, totalCount, pageNumber, pageSize);
		}
    }
}
