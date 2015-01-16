using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Models
{
    /// <summary>
    /// One of the 50 states in the good ol' U.S. of A.
    /// </summary>
    public class State
    {
        public string Id { get; private set; }
        public string Abbreviation { get; private set; }
        public string Name { get; private set; }
        public List<Location> Locations { get; set; }

        public State(string abbreviation, string name, string id)
        {
            this.Abbreviation = abbreviation;
            this.Name = name;
            this.Id = id;
            this.Locations = new List<Location>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
