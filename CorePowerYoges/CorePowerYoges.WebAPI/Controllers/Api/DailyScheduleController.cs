using CorePowerYoges.Models;
using CorePowerYoges.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CorePowerYoges.WebAPI.Controllers.Api
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