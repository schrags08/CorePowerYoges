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
    public class DailyScheduleController : ApiController
    {
        ICorePowerYogesService _corePowerYogesService;

        public DailyScheduleController(ICorePowerYogesService corePowerYogesService)
        {
            this._corePowerYogesService = corePowerYogesService;
        }

        public DailySchedule Get(string date, string stateId, string locationId)
        {
            return this._corePowerYogesService.GetDailyScheduleByStateIdAndLocationId(date, stateId, locationId);
        }
    }
}
