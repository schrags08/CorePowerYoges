using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Models
{
    public class Session
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }
        public string StartTimeLabel { get { return this.StartTime.ToString("t"); } }
        public string EndTimeLabel { get { return this.EndTime.ToString("t"); } }
        public string DurationLabel { get { return this.GetFancyDuration(this.EndTime - this.StartTime); } }
        public string TimeLabel
        {
            get
            {
                return string.Format("{0} - {1} ({2})", this.StartTimeLabel, this.EndTimeLabel, this.DurationLabel);
            }
        }

        public Session()
        {
        }

        public Session(DateTime startTime, DateTime endTime, string name, string teacher)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Name = name;
            this.Teacher = teacher;
        }

        private string GetFancyDuration(TimeSpan duration)
        {
            var hours = duration.Hours;
            var hoursLabel = string.Format("{0} {1}", hours, hours == 1 ? "hour" : "hours");

            var minutes = duration.Minutes;
            var minutesLabel = string.Format("{0} {1}", minutes, minutes == 1 ? "minute" : "minutes");


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
