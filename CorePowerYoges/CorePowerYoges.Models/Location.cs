using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Models
{
    /// <summary>
    /// Represents a CorePowerYoga Location.  A Location has Sessions as children and a State as a parent.
    /// </summary>
    public class Location
    {
        public string Name { get; set; }
        public string Id { get; set; }

        public Location()
        {

        }

        public Location(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }
    }
}
