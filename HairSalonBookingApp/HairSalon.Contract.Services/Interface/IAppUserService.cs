using HairSalon.Core;
using HairSalon.ModelViews.ApplicationUserModelViews;
using HairSalon.ModelViews.AuthModelViews;
using HairSalon.ModelViews.ShopModelViews;
using HairSalon.Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Contract.Services.Interface
{
	public interface IAppUserService
	{
		Task<BasePaginatedList<AppUserModelView>> GetAllAppUserAsync(int pageNumber, int pageSize, string id, string email, string phoneNumber);
		Task<string> AddAppUserAsync(CreateAppUserModelView model);
		Task<string> UpdateAppUserAsync(string id, UpdateAppUserModelView model);
		Task<string> DeleteAppUserAsync(string id);
		Task<ApplicationUsers> AuthenticateAsync(LoginModelView model);
	}
}
