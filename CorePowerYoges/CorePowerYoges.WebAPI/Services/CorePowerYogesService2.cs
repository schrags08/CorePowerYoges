using CorePowerYoges.BLL;
using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorePowerYoges.WebAPI.Services
{
    public class CorePowerYogesService2 : ICorePowerYogesService2
    {
        IState2Service _stateService;
        IDailySchedule2Service _dailyScheduleService;

        public CorePowerYogesService2(IState2Service stateService, IDailySchedule2Service dailyScheduleService)
        {            
            this._stateService = stateService;
            this._dailyScheduleService = dailyScheduleService;
        }

        public IEnumerable<State2> GetAllStates()
        {
            return this._stateService.GetAllStates();
        }

        public State2 GetStateById(string id)
        {
            return this._stateService.GetStateById(id);
        }

        public Location2 GetLocationById(string id)
        {
            return this._stateService.GetLocationById(id);
        }

        public DailySchedule2 GetDailyScheduleByStateIdAndLocationId(string date, string stateId, string locationId)
        {
            var parsedDate = new DateTime();
            if (DateTime.TryParse(date, out parsedDate))
            {
                return this._dailyScheduleService.GetDailyScheduleByStateIdAndLocationId(parsedDate,
                    stateId,
                    locationId);
            }
            return null;
        }
    }
}