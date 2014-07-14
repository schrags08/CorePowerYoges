using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Models
{
    public class DailySchedule
    {
        public DateTime Date { get; set; }
        public Location Location { get; set; }
        public List<Session> Sessions { get; set; }
        public int TotalClasses { get { return this.Sessions.Count(); } }
        public int RemainingClasses { get { return this.Sessions.Where(c => c.StartTime >= DateTime.Now).Count(); } }
        public string TotalClassesLabel { get { return this.GetTotalClassesLabel(this.TotalClasses); } }
        public string RemainingClassesLabel { get { return this.GetRemainingClassesLabel(this.RemainingClasses); } }

        public DailySchedule(DateTime date, Location location)
        {
            this.Date = date;
            this.Location = location;
            this.Sessions = new List<Session>();
        }

        /// <summary>
        /// Gets a "pretty" label for the word "class" based on the location count.
        /// e.g. 1 location would yield "class" while 2 or more would yield "classes"
        /// used to say "16 classes remaining" or "1 class remaining"
        /// </summary>
        /// <param name="fmt"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private string GetPrettyClassLabel(string fmt, int count)
        {
            var suffix = count == 1 ? string.Empty : "es";
            var prefix = "no";
            if (count > 0)
            {
                prefix = count.ToString();
            }
            return string.Format(fmt, prefix, suffix);
        }

        private string GetRemainingClassesLabel(int remainingClasses)
        {
            var fmt = "{0} class{1} remaining";
            return GetPrettyClassLabel(fmt, remainingClasses);
        }

        private string GetTotalClassesLabel(int totalClasses)
        {
            var fmt = "{0} class{1}";
            return GetPrettyClassLabel(fmt, totalClasses);
        }
    }
}
