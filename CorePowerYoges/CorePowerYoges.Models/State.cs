using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Models
{
    public class State
    {
        /// <summary>
        /// The two letter abbreviation for the State, in caps
        /// </summary>
        public string Id { get; private set; }
        public string CorePowerYogaId { get; private set; }
        public string Name { get; private set; }                
        public virtual List<Location> Locations { get; set; }

        public State(string id, string corePowerYogaId, string name)
        {
            this.Id = id;
            this.CorePowerYogaId = corePowerYogaId;
            this.Name = name;
            this.Locations = new List<Location>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
