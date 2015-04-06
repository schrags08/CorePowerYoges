using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Models
{
    public class Location
    {
        public int Id { get; private set; }
        public string StateId { get; private set; }
        public string CorePowerYogaId { get; private set; }
        public string Name { get; private set; }
        public virtual List<DailySchedule> DailySchedules { get; set; }

        public Location(int id, string stateId, string corePowerYogaId, string name)
        {
            this.Id = id;
            this.StateId = stateId;
            this.CorePowerYogaId = corePowerYogaId;
            this.Name = name;
            this.DailySchedules = new List<DailySchedule>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
