using System.ComponentModel.DataAnnotations;

namespace HairSalon.ModelViews.ComboModelViews
{
    public class CreateComboModelView
    {
        [Required(ErrorMessage = "List services is required.")]
        /*public string[] ServiceIds { get; set; }*/
        public List<string> ServiceIds { get; set; }
        public string Name { get; set; }
    }
}
