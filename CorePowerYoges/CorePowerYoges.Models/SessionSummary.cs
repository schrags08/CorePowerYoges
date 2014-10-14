using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Models
{
    public class SessionSummary : SummaryBase
    {
        private readonly string hourString = "hour";
        private readonly string hourStringPlural = "hours";
        private readonly string minuteString = "minute";
        private readonly string minuteStringPlural = "minutes";

        private Session session;
        private string timeFormat;
        private string timeSummaryLabelFormat;

        public SessionSummary(Session session, 
            string timeFormat = "t",
            string timeSummaryLabelFormat = "{0} - {1} ({2})")
        {
            this.session = session;
            this.timeFormat = timeFormat;
            this.timeSummaryLabelFormat = timeSummaryLabelFormat;
        }

        public string StartTimeLabel 
        {
            get { return this.session.StartTime.ToString(timeFormat); } 
        }

        public string EndTimeLabel
        {
            get { return this.session.EndTime.ToString(timeFormat); }
        }

        public string DurationLabel 
        {
            get { return this.GetFancyDuration(this.session.EndTime - this.session.StartTime); }
        }

        public string TimeSummaryLabel
        {
            get
            {
                return string.Format(timeSummaryLabelFormat, 
                    this.StartTimeLabel, 
                    this.EndTimeLabel, 
                    this.DurationLabel);
            }
        }       

        private string GetFancyDuration(TimeSpan duration)
        {
            var hours = duration.Hours;
            var hoursLabel = GetPrettyPluralCountLabel(hourString, hourStringPlural, hours);

            var minutes = duration.Minutes;
            var minutesLabel = GetPrettyPluralCountLabel(minuteString, minuteStringPlural, minutes);

            var label = string.Empty;
            if (hours <= 0)
            {
                label = string.Format("{0}", minutesLabel);
            }
            else if (hours > 0)
            {
                label = string.Format("{0}", hoursLabel);

                if (minutes > 0)
                {
                    label = string.Format("{0} and {1}", label, minutesLabel);
                }
            }

            return label;
        }
    }
}
