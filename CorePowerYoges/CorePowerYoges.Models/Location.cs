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
        public List<Session> Sessions { get; set; }

        public Location()
        {
            this.Sessions = new List<Session>();
        }

        public Location(string name, string id)
        {
            this.Name = name;
            this.Id = id;
            this.Sessions = new List<Session>();
        }
    }
}
