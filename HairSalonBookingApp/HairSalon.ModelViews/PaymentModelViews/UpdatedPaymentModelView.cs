using HairSalon.Contract.Repositories.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.ModelViews.PaymentModelViews
{
    public class UpdatedPaymentModelView
    {
        public string AppointmentId { get; set; }

        public decimal TotalAmount { get; set; }

		public string PaymentMethod { get;  set; }
    }
}
