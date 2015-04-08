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
        IDailyScheduleService _dailyScheduleService;

        public CorePowerYogesService(IDailyScheduleService dailyScheduleService)
        {
            this._dailyScheduleService = dailyScheduleService;
        }

        public DailySchedule GetDailyScheduleByStateIdAndLocationId(string date, string corePowerYogaStateId, string corePowerYogaLocationId)
        {
            var parsedDate = new DateTime();
            if (DateTime.TryParse(date, out parsedDate))
            {
                return this._dailyScheduleService.GetDailyScheduleByStateIdAndLocationId(parsedDate,
                    corePowerYogaStateId,
                    corePowerYogaLocationId);
            }
            return null;
        }
    }
}