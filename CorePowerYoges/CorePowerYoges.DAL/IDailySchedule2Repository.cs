using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.DAL
{
    public interface IDailySchedule2Repository
    {
        DailySchedule GetDailyScheduleByStateIdAndLocationId(DateTime date, string stateId, string locationId);
    }
}
