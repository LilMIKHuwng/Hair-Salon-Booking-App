﻿using System.ComponentModel.DataAnnotations;

namespace HairSalon.ModelViews.PaymentModelViews
{
    public class UpdatedPaymentModelView
    {
        [Required(ErrorMessage = "AppointmentId is required.")]
        public string AppointmentId { get; set; }

        [Required(ErrorMessage = "PaymentMethod is required.")]
        public string PaymentMethod { get;  set; }
    }
}
