using CorePowerYoges.BLL;
using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorePowerYoges.WebAPI.Services
{
    public class CorePowerYogesService : ICorePowerYogesService
    {
        IStateService _stateService;
        IDailyScheduleService _dailyScheduleService;

        public CorePowerYogesService(IStateService stateService, IDailyScheduleService dailyScheduleService)
        {            
            this._stateService = stateService;
            this._dailyScheduleService = dailyScheduleService;
        }

        public IEnumerable<State> GetAllStates()
        {
            return this._stateService.GetAllStates();
        }

        public State GetStateById(string id)
        {
            return this._stateService.GetStateById(id);
        }

        public Location GetLocationById(string id)
        {
            return this._stateService.GetLocationById(id);
        }

        public DailySchedule GetDailyScheduleByStateIdAndLocationId(string date, string stateId, string locationId)
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