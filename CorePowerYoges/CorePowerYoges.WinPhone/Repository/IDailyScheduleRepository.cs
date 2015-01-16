using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.WinPhone.Repository
{
    public interface IDailyScheduleRepository
    {
        Task<DailySchedule> GetDailyScheduleByStateIdAndLocationIdAsync(DateTime date, string stateId, string locationId);
    }
}
