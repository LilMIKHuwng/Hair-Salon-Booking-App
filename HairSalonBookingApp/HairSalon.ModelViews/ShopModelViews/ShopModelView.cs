using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.ModelViews.ShopModelViews
{
    public class ShopModelView
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string ShopEmail { get; set; }

        public string ShopPhone { get; set; }

        public TimeSpan OpenTime { get; set; }

        public TimeSpan CloseTime { get; set; }

        public string Title { get; set; }

    }
}
