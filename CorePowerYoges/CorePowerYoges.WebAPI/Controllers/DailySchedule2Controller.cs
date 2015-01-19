using CorePowerYoges.Models;
using CorePowerYoges.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CorePowerYoges.WebAPI.Controllers
{
    public class DailySchedule2Controller : ApiController
    {
        ICorePowerYogesService2 _corePowerYogesService;

        public DailySchedule2Controller(ICorePowerYogesService2 corePowerYogesService)
        {
            this._corePowerYogesService = corePowerYogesService;
        }

        public DailySchedule2 Get(string date, string stateId, string locationId)
        {
            return this._corePowerYogesService.GetDailyScheduleByStateIdAndLocationId(date, stateId, locationId);
        }
    }
}
