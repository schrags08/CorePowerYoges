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
    public class DailyScheduleService : IDailyScheduleService
    {
        private Cache cache = HttpRuntime.Cache;
        private IDailyScheduleRepository _dailyScheduleRepository;
        private int dailyScheduleForLocationCacheDurationInMinutes;

        public DailyScheduleService(IDailyScheduleRepository dailyScheduleRepository, 
            int dailyScheduleForLocationCacheDurationInMinutes = 720)
        {
            this._dailyScheduleRepository = dailyScheduleRepository;
            this.dailyScheduleForLocationCacheDurationInMinutes = dailyScheduleForLocationCacheDurationInMinutes;
        }

        private string GenerateCacheKey(string key)
        {
            return string.Format("DailySchedule2Service-{0}", key);
        }

        public DailySchedule GetDailyScheduleByStateIdAndLocationId(DateTime date, string corePowerYogaStateId, string corePowerYogaLocationId)
        {
            string key = string.Format("{0}-{1}-{2}", 
                "DailyScheduleForLocation", 
                corePowerYogaLocationId, 
                date.ToShortDateString().Replace("/", ""));

            string cacheKey = GenerateCacheKey(key);
            DailySchedule dailyScheduleFromCache = (DailySchedule)cache.Get(cacheKey);

            if (dailyScheduleFromCache == null)
            {
                // no data in cache, load data externally
                dailyScheduleFromCache = _dailyScheduleRepository.GetDailyScheduleByStateIdAndLocationId(date,
                    corePowerYogaStateId,
                    corePowerYogaLocationId);

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
