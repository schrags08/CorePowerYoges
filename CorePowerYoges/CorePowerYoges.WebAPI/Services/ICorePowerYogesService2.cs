using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.WebAPI.Services
{
    public interface ICorePowerYogesService2
    {
        IEnumerable<State2> GetAllStates();
        State2 GetStateById(string id);
        Location2 GetLocationById(string id);
        DailySchedule2 GetDailyScheduleByStateIdAndLocationId(string date, string stateId, string locationId);
    }
}
