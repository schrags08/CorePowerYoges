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
        protected Cache cache = HttpRuntime.Cache;        

        public string ScraperUrlBase { get; set; }
        public string ScraperUrlQueryString { get; set; }
        public string ScraperUrlShortDateFormat { get; set; }
        public int ScraperCacheDurationInMinutes { get; set; }

        public DailyScheduleBL(string scraperUrlBase,
            string scraperUrlQueryString,
            string scraperUrlShortDateFormat,
            int scraperCacheDurationInMinutes = 720)
        {
            this.ScraperUrlBase = scraperUrlBase;
            this.ScraperUrlQueryString = scraperUrlQueryString;
            this.ScraperUrlShortDateFormat = scraperUrlShortDateFormat;
            this.ScraperCacheDurationInMinutes = scraperCacheDurationInMinutes;
        }

        private string GetCacheKey(string key)
        {
            return string.Format("DailyScheduleBL.{0}", key);
        }

        public DailySchedule GetDailyScheduleForLocation(DateTime date, Location location)
        {
            string stateId = location.State.Id;
            string locationId = location.Id;
            string cacheKey = GetCacheKey(locationId);

            DailySchedule dailyScheduleFromCache = (DailySchedule)cache.Get(cacheKey);
            if (dailyScheduleFromCache == null)
            {
                IDailyScheduleDA dailyScheduleDA = new CorePowerWebsiteScraper(this.ScraperUrlBase,
                    this.ScraperUrlQueryString, this.ScraperUrlShortDateFormat);

                // no data in cache, load data externally
                dailyScheduleFromCache = dailyScheduleDA.GetDailyScheduleByStateAndLocation(date, stateId, locationId);

                // add data to cache
                cache.Insert(cacheKey, 
                    dailyScheduleFromCache, 
                    null,
                    DateTime.Now.AddMinutes(this.ScraperCacheDurationInMinutes), 
                    Cache.NoSlidingExpiration);
            }
            return dailyScheduleFromCache;
        }
    }
}
