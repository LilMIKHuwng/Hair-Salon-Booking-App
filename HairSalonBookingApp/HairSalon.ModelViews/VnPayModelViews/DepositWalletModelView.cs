using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.ModelViews.VnPayModelViews
{
    public class DepositWalletModelView
    {
        public string? UserId { get; set; }
        public double Amount { get; set; }

        public bool IsAdmin { get; set; }
    }
}
