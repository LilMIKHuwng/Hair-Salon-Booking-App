using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
