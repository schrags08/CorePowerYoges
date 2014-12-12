using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.DAL
{
    public interface IDailyScheduleRepository
    {
        DailySchedule GetDailyScheduleByStateIdAndLocationId(DateTime date, string stateId, string locationId);
    }
}
