using System.ComponentModel.DataAnnotations;

namespace HairSalon.ModelViews.RoleModelViews
{
    public class CreateRoleModelView
    {
        [Required(ErrorMessage = "RoleName is required.")]
        public string Name { get; set; }

    }
}
