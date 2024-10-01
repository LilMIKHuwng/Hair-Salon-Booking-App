using HairSalon.Core;
using HairSalon.ModelViews.ApplicationUserModelViews;
using HairSalon.ModelViews.AppUserRoleViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Contract.Services.Interface
{
	public interface IAppUserRoleService
	{
		Task<BasePaginatedList<AppUserRoleModelView>> GetAllAppUserRoleAsync(int pageNumber, int pageSize);
		Task<AppUserRoleModelView> AddAppUserRoleAsync(CreateAppUserRoleModelView model);
		Task<AppUserRoleModelView> UpdateAppUserRoleAsync(string UserId, string RoleId, UpdateAppUserRoleModelView model);
		Task<string> DeleteAppUserRoleAsync(string UserId, string RoleId);
		Task<AppUserRoleModelView> GetAppUserRoleAsync(string UserId, string RoleId);
	}
}
