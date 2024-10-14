using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.ModelViews.FeedbackModeViews
{
    public class UpdatedFeedbackModelView
    {
        [Range(1, 5, ErrorMessage = "Rate must be between 1 and 5.")]
        public int? Rate { get; set; }

        [MaxLength(255, ErrorMessage = "Comment cannot exceed 255 characters.")]
        public string? Comment { get; set; }
    }
}
