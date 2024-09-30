using HairSalon.Contract.Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.ModelViews.PaymentModelViews
{
    public class PaymentModelView
    {
        public string Id { get; set; }

        public string AppointmentId { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime PaymentTime { get; set; } = DateTime.Now;

        public string PaymentMethod { get; set; }

    }
}
