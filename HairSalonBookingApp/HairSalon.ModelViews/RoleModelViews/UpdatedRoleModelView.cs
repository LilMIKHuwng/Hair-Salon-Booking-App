using System.ComponentModel.DataAnnotations;

namespace HairSalon.ModelViews.RoleModelViews
{
    public class UpdatedRoleModelView
    {
		[Required(ErrorMessage = "RoleName is required.")]
		public string Name { get; set;}
    }
}
