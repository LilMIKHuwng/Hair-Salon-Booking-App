﻿using System.ComponentModel.DataAnnotations;

namespace HairSalon.ModelViews.FeedBackModeViews
{
    public class CreateFeedbackModelView
    {
        [Required(ErrorMessage = "AppointmentId is required.")]
        public string AppointmentId { get; set; }

        [Range(1, 5, ErrorMessage = "Rate must be between 1 and 5.")]
        public int? Rate { get; set; }

        [MaxLength(255, ErrorMessage = "Comment cannot exceed 255 characters.")]
        public string? Comment { get; set; }
    }
}
