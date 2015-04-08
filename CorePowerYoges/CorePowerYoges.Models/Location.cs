using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string CorePowerYogaLocationId { get; set; }
        public int StateId { get; set; }
        
        [JsonIgnore]
        public virtual State State { get; set; }

        public Location()
        {
        }

        public Location(int locationId, string name, string corePowerYogaLocationId, int stateId)
        {
            this.LocationId = locationId;
            this.Name = name;
            this.CorePowerYogaLocationId = corePowerYogaLocationId;
            this.StateId = stateId;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
