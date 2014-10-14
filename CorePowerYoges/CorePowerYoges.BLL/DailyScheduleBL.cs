using CorePowerYoges.DAL;
using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace CorePowerYoges.BLL
{
    public class DailyScheduleBL
    {
        private Cache cache = HttpRuntime.Cache;
        private IDailyScheduleDA dailyScheduleDA;
        private int dailyScheduleForLocationCacheDurationInMinutes;

        public DailyScheduleBL(IDailyScheduleDA DailyScheduleDA, int DailyScheduleForLocationCacheDurationInMinutes = 720)
        {
            this.dailyScheduleDA = DailyScheduleDA;
            this.dailyScheduleForLocationCacheDurationInMinutes = DailyScheduleForLocationCacheDurationInMinutes;
        }

        private string GenerateCacheKey(string key)
        {
            return string.Format("DailyScheduleBL-{0}", key);
        }

        public DailySchedule GetDailyScheduleByLocation(DateTime date, Location location)
        {
            string key = string.Format("{0}-{1}-{2}", 
                "DailyScheduleForLocation", 
                location.Id, 
                date.ToShortDateString().Replace("/", ""));

            string cacheKey = GenerateCacheKey(key);
            DailySchedule dailyScheduleFromCache = (DailySchedule)cache.Get(cacheKey);

            if (dailyScheduleFromCache == null)
            {
                // no data in cache, load data externally
                dailyScheduleFromCache = dailyScheduleDA.GetDailyScheduleByStateIdAndLocationId(date,
                    location.State.Id,
                    location.Id);

                // add data to cache
                cache.Insert(cacheKey, 
                    dailyScheduleFromCache, 
                    null,
                    DateTime.Now.AddMinutes(dailyScheduleForLocationCacheDurationInMinutes), 
                    Cache.NoSlidingExpiration);
            }

            return dailyScheduleFromCache;
        }
    }
}
