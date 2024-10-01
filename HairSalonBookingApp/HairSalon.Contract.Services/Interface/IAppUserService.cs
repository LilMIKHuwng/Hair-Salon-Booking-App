using HairSalon.Core;
using HairSalon.ModelViews.ApplicationUserModelViews;
using HairSalon.ModelViews.ShopModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Contract.Services.Interface
{
	public interface IAppUserService
	{
		Task<BasePaginatedList<AppUserModelView>> GetAllAppUserAsync(int pageNumber, int pageSize);
		Task<AppUserModelView> AddAppUserAsync(CreateAppUserModelView model);
		Task<AppUserModelView> UpdateAppUserAsync(string id, UpdateAppUserModelView model);
		Task<string> DeleteAppUserAsync(string id);
		Task<AppUserModelView> GetAppUserAsync(string id);
	}
}
