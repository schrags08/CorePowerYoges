using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Models
{
    public class SummaryBase
    {
        /// <summary>
        /// Gets a "pretty" label for the inputString based on the count.
        /// e.g. 1 would yield the inputString while 2 or more would yield the inputStringPlural
        /// e.g. "no sessions...", "16 sessions..." or "1 session..."
        /// </summary>
        public string GetPrettyPluralCountLabel(string inputString,
            string inputStringPlural,
            int count)
        {
            var prefix = "no";
            var suffix = count == 1 ? inputString : inputStringPlural;

            if (count > 0)
            {
                prefix = count.ToString();
            }

            return string.Format("{0} {1}", prefix, suffix);
        }
    }
}
