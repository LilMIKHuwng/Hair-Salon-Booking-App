using System.ComponentModel.DataAnnotations;

namespace HairSalon.ModelViews.RoleModelViews
{
    public class CreateRoleModelView
    {
        [Required(ErrorMessage = "RoleName is required.")]
        public string RoleName { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
    }
}
