using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Models
{
    public class Session2
    {
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public string Name { get; private set; }
        public string Teacher { get; private set; }

        public Session2(DateTime startTime, DateTime endTime, string name, string teacher)
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
