using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Models
{
    public class StateSummary : SummaryBase
    {
        private readonly string locationString = "studio";
        private readonly string locationStringPlural = "studios";
        private State state;

        public StateSummary(State state)
        {
            this.state = state;
        }

        public string TotalLocationsLabel
        {
            get 
            {
                return GetPrettyPluralCountLabel(locationString,
                    locationStringPlural,
                    state.Locations.Count());                
            }
        }
    }
}
