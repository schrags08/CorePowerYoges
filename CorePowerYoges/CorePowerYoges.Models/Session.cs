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

        public Session(DateTime startTime, DateTime endTime, string name, string teacher)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Name = name;
            this.Teacher = teacher;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
