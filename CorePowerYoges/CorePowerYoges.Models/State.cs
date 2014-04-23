﻿using System;
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
        public string Abbreviation { get; set; }
        public string Name { get; set; }
        public List<Location> Locations { get; set; }

        public State()
        {
            this.Locations = new List<Location>();
        }

        public State(string abbreviation, string name)
        {
            this.Abbreviation = abbreviation;
            this.Name = name;
            this.Locations = new List<Location>();
        }
    }
}
