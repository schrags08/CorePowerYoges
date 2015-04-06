using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Models
{
    public class DailySchedule
    {
        public DateTime Date { get; private set; }
        public virtual List<Session> Sessions { get; set; }
        
        public DailySchedule(DateTime date)
        {
            this.Date = date;
            this.Sessions = new List<Session>();
        }

        public override string ToString()
        {
            return Date.DayOfWeek.ToString();
        }
    }
}
