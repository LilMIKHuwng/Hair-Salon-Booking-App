using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.ModelViews.FeedBackModeViews
{
    public class FeedBackModelView
    {
        public string Id { get; set; }

        public string AppointmentId { get; set; }

        public int? Rate { get; set; }

        public string? Comment { get; set; }
    }
}
