using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Models
{
    public class State
    {
        public int StateId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string CorePowerYogaStateId { get; set; }
        
        public virtual List<Location> Locations { get; set; }

        public State()
        {
        }

        public State(int stateId, string name, string abbreviation, string corePowerYogaStateId)
        {
            this.StateId = stateId;
            this.Name = name;
            this.Abbreviation = abbreviation;
            this.CorePowerYogaStateId = corePowerYogaStateId;
            
            this.Locations = new List<Location>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
