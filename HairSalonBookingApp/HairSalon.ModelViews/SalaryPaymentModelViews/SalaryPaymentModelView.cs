﻿namespace HairSalon.ModelViews.SalaryPaymentModelViews
{
    public class SalaryPaymentModelView
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public decimal BaseSalary { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}
