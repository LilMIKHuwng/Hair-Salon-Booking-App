using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.Core.Base;
using HairSalon.Core.Constants;
using HairSalon.Core.Utils;
using HairSalon.ModelViews.ApplicationUserModelViews;
using HairSalon.ModelViews.AuthModelViews;
using HairSalon.Repositories.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Services.Service
{
    public class AppUserService : IAppUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public AppUserService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = httpContextAccessor;
        }

        public async Task<string> AddAppUserAsync(CreateAppUserModelView model)
        {
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
                PasswordHash = model.Password,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserInfo = userInfo
            };

            var accountRepositoryCheck = _unitOfWork.GetRepository<ApplicationUsers>();

            var user = await accountRepositoryCheck.Entities.FirstOrDefaultAsync(x => x.UserName == model.UserName);
            if (user != null)
            {
                throw new Exception("Duplicate");
            }

            var accountRepository = _unitOfWork.GetRepository<ApplicationUsers>();
            await accountRepository.InsertAsync(newAccount);
            await _unitOfWork.SaveAsync();

            var roleRepository = _unitOfWork.GetRepository<ApplicationRoles>();
            var userRole = await roleRepository.Entities.FirstOrDefaultAsync(r => r.Name == model.RoleName);
            if (userRole == null)
            {
                return "The 'User' role does not exist. Please make sure to create it first.";
            }

            var userRoleRepository = _unitOfWork.GetRepository<ApplicationUserRoles>();
            var applicationUserRole = new ApplicationUserRoles
            {
                UserId = newAccount.Id,
                RoleId = userRole.Id,
                CreatedBy = model.UserName,
                CreatedTime = DateTime.UtcNow,
                LastUpdatedBy = model.UserName,
                LastUpdatedTime = DateTime.UtcNow
            };

            await userRoleRepository.InsertAsync(applicationUserRole);
            await _unitOfWork.SaveAsync();

            return "Add user successfully!";
        }

        public async Task<string> DeleteAppUserAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Please provide a valid Application User ID.");
            }

            ApplicationUsers existingUser = await _unitOfWork.GetRepository<ApplicationUsers>().Entities
                .FirstOrDefaultAsync(s => s.Id == Guid.Parse(id) && !s.DeletedTime.HasValue)
                ?? throw new Exception("The Application User cannot be found or has been deleted!");

            existingUser.DeletedTime = DateTimeOffset.UtcNow;
            existingUser.DeletedBy = _contextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;

            _unitOfWork.GetRepository<ApplicationUsers>().Update(existingUser);
            await _unitOfWork.SaveAsync();
            return "Deleted user successfully!";
        }

        public async Task<BasePaginatedList<AppUserModelView>> GetAllAppUserAsync(int pageNumber, int pageSize)
        {
            IQueryable<ApplicationUsers> roleQuery = _unitOfWork.GetRepository<ApplicationUsers>().Entities
                .Where(p => !p.DeletedTime.HasValue)
                .OrderByDescending(s => s.CreatedTime);

            int totalCount = await roleQuery.CountAsync();

            List<ApplicationUsers> paginatedShops = await roleQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            List<AppUserModelView> appUserModelViews = _mapper.Map<List<AppUserModelView>>(paginatedShops);

            return new BasePaginatedList<AppUserModelView>(appUserModelViews, totalCount, pageNumber, pageSize);
        }

        public async Task<AppUserModelView> GetAppUserAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Please provide a valid Application User ID.");
            }

            ApplicationUsers existingUser = await _unitOfWork.GetRepository<ApplicationUsers>().Entities
                .FirstOrDefaultAsync(s => s.Id == Guid.Parse(id) && !s.DeletedTime.HasValue)
                ?? throw new Exception("The Application User cannot be found or has been deleted!");

            return _mapper.Map<AppUserModelView>(existingUser);
        }

        public async Task<string> UpdateAppUserAsync(string id, UpdateAppUserModelView model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    return "Please provide a valid Application User ID.";
                }

                // Retrieve the existing user
                ApplicationUsers existingUser = await _unitOfWork.GetRepository<ApplicationUsers>().Entities
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
                UserInfo existingUserInfo = await _unitOfWork.GetRepository<UserInfo>().Entities
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
            catch (BaseException.BadRequestException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return "An error occurred while updating the user.";
            }
        }


        public async Task<ApplicationUsers> AuthenticateAsync(LoginModelView model)
        {
            var accountRepository = _unitOfWork.GetRepository<ApplicationUsers>();

            // Tìm người dùng theo Username
            var user = await accountRepository.Entities
                .FirstOrDefaultAsync(x => x.UserName == model.Username);

            if (user == null)
            {
                return null; // Người dùng không tồn tại
            }

            // So sánh mật khẩu (bạn có thể sử dụng cơ chế mã hóa mật khẩu)
            if (model.Password != user.PasswordHash)
            {
                return null; // Mật khẩu không khớp
            }
            // Kiểm tra xem đã tồn tại bản ghi đăng nhập chưa
            var loginRepository = _unitOfWork.GetRepository<ApplicationUserLogins>();
            var existingLogin = await loginRepository.Entities
                .FirstOrDefaultAsync(x => x.UserId == user.Id && x.LoginProvider == "CustomLoginProvider");

            if (existingLogin == null)
            {
                // Nếu chưa có bản ghi đăng nhập, thêm mới
                var loginInfo = new ApplicationUserLogins
                {
                    UserId = user.Id, // UserId từ người dùng đã đăng nhập
                    ProviderKey = user.Id.ToString(),
                    LoginProvider = "CustomLoginProvider", // Hoặc có thể là tên provider khác
                    ProviderDisplayName = "Standard Login",
                    CreatedBy = user.UserName, // Ghi lại ai đã thực hiện đăng nhập
                    CreatedTime = CoreHelper.SystemTimeNow,
                    LastUpdatedBy = user.UserName,
                    LastUpdatedTime = CoreHelper.SystemTimeNow
                };

                await loginRepository.InsertAsync(loginInfo);
                await _unitOfWork.SaveAsync(); // Lưu thay đổi vào cơ sở dữ liệu
            }
            else
            {
                // Nếu bản ghi đăng nhập đã tồn tại, có thể cập nhật thông tin nếu cần
                existingLogin.LastUpdatedBy = user.UserName;
                existingLogin.LastUpdatedTime = CoreHelper.SystemTimeNow;

                await loginRepository.UpdateAsync(existingLogin);
                await _unitOfWork.SaveAsync(); // Lưu thay đổi vào cơ sở dữ liệu
            }

            return user; // Trả về người dùng đã xác thực
        }

    }
}
