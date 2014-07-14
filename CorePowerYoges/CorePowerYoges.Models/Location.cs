using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Models
{
    /// <summary>
    /// Represents a CorePowerYoga Location.  There can be one or many Locations in a State.
    /// A location has multiple sessions per day.
    /// </summary>
    public class Location
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public State State { get; set; }

        public Location()
        {
        }

        public Location(string name, string id, State state)
        {
            this.Name = name;
            this.Id = id;
            this.State = state;
        }
    }
}
