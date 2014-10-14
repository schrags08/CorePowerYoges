using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Models
{
    public class DailyScheduleSummary : SummaryBase
    {
        private readonly string sessionString = "session";
        private readonly string sessionStringPlural = "sessions";
        private readonly string remainingString = "remaining";
        private DailySchedule dailySchedule;

        public DailyScheduleSummary(DailySchedule dailySchedule)
        {
            this.dailySchedule = dailySchedule;
        }

        public string TotalSessionsLabel
        {
            get
            {
                return GetPrettyPluralCountLabel(sessionString,
                    sessionStringPlural,
                    this.dailySchedule.Sessions.Count());
            }
        }

        public string RemainingSessionsLabel
        {
            get 
            {
                var sessionLabel = GetPrettyPluralCountLabel(sessionString,
                    sessionStringPlural,
                    this.dailySchedule.Sessions.Where(c => c.StartTime >= DateTime.Now).Count());

                return string.Format("{0} {1}", sessionLabel, remainingString);
            }
        }
    }
}
