using System.ComponentModel.DataAnnotations;
namespace HairSalon.ModelViews.AppUserRoleViewModels
{
	public class CreateAppUserRoleModelView
	{
		[Required(ErrorMessage = "User ID is required.")]
		public string UserId { get; set;}

		[Required(ErrorMessage = "Role ID is required.")]
		public string RoleId { get; set;}

	}
}
