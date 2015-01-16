using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Models
{
    public class Location2
    {
        public string Name { get; private set; }
        public string Id { get; private set; }
        public List<DailySchedule2> DailySchedules { get; set; }

        public Location2(string name, string id)
        {
            this.Name = name;
            this.Id = id;
            this.DailySchedules = new List<DailySchedule2>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
