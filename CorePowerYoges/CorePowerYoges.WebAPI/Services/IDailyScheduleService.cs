using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.WebAPI.Services
{
    public interface IDailyScheduleService
    {
        DailySchedule GetDailyScheduleByDateAndLocation(DateTime date, Location location);
    }
}
