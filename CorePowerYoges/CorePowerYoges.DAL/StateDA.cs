using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorePowerYoges.Models;

namespace CorePowerYoges.DAL
{
    public class StateDA
    {
        public List<State> GetAllStates()
        {
            return new List<State>
            {
                new State() { Name = "California", Abbreviation="CA" },
                new State() { Name = "Colorado", Abbreviation="CO" },
                new State() { Name = "Washington, DC", Abbreviation="DC" },
                new State() { Name = "Hawaii", Abbreviation="HI" },
                new State() { Name = "Illinois", Abbreviation="IL" },
                new State() { Name = "Massachussetts", Abbreviation="MA" },
                new State() { Name = "Maryland", Abbreviation="MD" },
                new State() { Name = "Minnesota", Abbreviation="MN" },
                new State() { Name = "Oregon", Abbreviation="OR" },
                new State() { Name = "Texas", Abbreviation="TX" },
                new State() { Name = "Utah", Abbreviation="UT" },
                new State() { Name = "Washington", Abbreviation="WA" }
            };
        }
    }
}
