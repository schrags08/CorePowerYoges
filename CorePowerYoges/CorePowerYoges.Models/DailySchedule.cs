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
        public string LocationId { get; private set; }
        public List<Session> Sessions { get; set; }
        
        public DailySchedule(DateTime date, string locationId)
        {
            this.Date = date;
            this.LocationId = locationId;
            this.Sessions = new List<Session>();
        }
    }
}
