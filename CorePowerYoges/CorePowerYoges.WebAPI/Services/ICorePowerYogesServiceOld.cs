using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.WebAPI.Services
{
    public interface ICorePowerYogesService
    {
        IEnumerable<State> GetAllStates();
        State GetStateById(string id);
        Location GetLocationById(string id);
        DailySchedule GetDailyScheduleByStateIdAndLocationId(string date, string stateId, string locationId);
    }
}
