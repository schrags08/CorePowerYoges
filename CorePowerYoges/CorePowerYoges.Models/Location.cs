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
        public string Name { get; private set; }
        public string Id { get; private set; }
        public string StateId { get; private set; }

        public Location(string name, string id, string stateId)
        {
            this.Name = name;
            this.Id = id;
            this.StateId = stateId;
        }
    }
}
