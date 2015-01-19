using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Models
{
    public class DailySchedule2
    {
        public DateTime Date { get; private set; }
        public List<Session2> Sessions { get; set; }
        
        public DailySchedule2(DateTime date)
        {
            this.Date = date;
            this.Sessions = new List<Session2>();
        }

        public override string ToString()
        {
            return Date.DayOfWeek.ToString();
        }
    }
}
