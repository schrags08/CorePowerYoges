using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Models
{
    /// <summary>
    /// Represents a Core Power Yoga Session.
    /// </summary>
    public class Session
    {
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public string Name { get; private set; }
        public string Teacher { get; private set; }
        public string LocationId { get; private set; }

        public Session(DateTime startTime, DateTime endTime, string name, string teacher, string locationId)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Name = name;
            this.Teacher = teacher;
            this.LocationId = locationId;
        }
    }
}
