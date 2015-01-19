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
    public class State2
    {
        public string Id { get; private set; }
        public string Abbreviation { get; private set; }
        public string Name { get; private set; }
        public List<Location2> Locations { get; set; }

        public State2(string abbreviation, string name, string id)
        {
            this.Abbreviation = abbreviation;
            this.Name = name;
            this.Id = id;
            this.Locations = new List<Location2>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
