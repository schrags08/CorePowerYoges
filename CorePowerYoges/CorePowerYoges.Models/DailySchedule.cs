using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Models
{
    public class DailySchedule
    {
        public DateTime Date { get; set; }
        public Location Location { get; set; }
        public List<Session> Sessions { get; set; }
    }
}
