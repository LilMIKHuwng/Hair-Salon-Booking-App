using HairSalon.Contract.Repositories.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.ModelViews.PaymentModelViews
{
    public class CreatePaymentModelView
    {
        [Required(ErrorMessage = "AppointmentId is required.")]
        public string AppointmentId { get; set; }

        [Required(ErrorMessage = "PaymentMethod is required.")]
        public string PaymentMethod { get; set; }
    }
}
