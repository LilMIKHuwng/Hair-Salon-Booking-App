using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.ModelViews.ComboModelViews
{
    public class UpdateComboModelView
    {
        public string? Name { get; set; } // Không có thuộc tính [Required]
        public List<string> ServiceIdsToAdd { get; set; } = new List<string>();
        public List<string> ServiceIdsToRemove { get; set; } = new List<string>();
    }
}
