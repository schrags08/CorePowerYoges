using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Scraper
{
    public interface ICorePowerScraper
    {
        DailySchedule GetDailyScheduleForLocation(DateTime date, string stateId, string locationId);
        //List<DailySchedule> GetDailyScheduleForLocations(DateTime date, List<Location> locations); 
    }
}
