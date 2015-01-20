using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Models
{
    public class Location
    {
        public string Name { get; private set; }
        public string Id { get; private set; }
        public List<DailySchedule> DailySchedules { get; set; }

        public Location(string name, string id)
        {
            this.Name = name;
            this.Id = id;
            this.DailySchedules = new List<DailySchedule>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
