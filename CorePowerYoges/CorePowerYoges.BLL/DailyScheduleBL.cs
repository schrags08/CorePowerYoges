using CorePowerYoges.Models;
using CorePowerYoges.Scraper;
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
        protected ICorePowerScraper scraper;

        string scheduleUrlPrefix = ConfigurationManager.AppSettings["scheduleUrlPrefix"];
        string scheduleUrlSuffix = ConfigurationManager.AppSettings["scheduleUrlSuffix"];
        string scheduleUrlShortDateFormat = ConfigurationManager.AppSettings["scheduleUrlShortDateFormat"];
        double scraperCacheDurationInMinutes = Double.Parse(ConfigurationManager.AppSettings["scraperCacheDurationInMinutes"]);

        public DailyScheduleBL()
        {
            this.scraper = new CorePowerWebsiteScraper(scheduleUrlPrefix,
                scheduleUrlSuffix,
                scheduleUrlShortDateFormat);
        }

        private string GetCacheKey(string locationId)
        {
            return string.Format("DailyScheduleBL.{0}", locationId);
        }

        public DailySchedule GetDailyScheduleForLocation(DateTime date, Location location)
        {
            string stateId = location.State.Id;
            string locationId = location.Id;
            string cacheKey = GetCacheKey(locationId);

            DailySchedule dailyScheduleFromCache = (DailySchedule)cache.Get(cacheKey);
            if (dailyScheduleFromCache == null)
            {
                // no data in cache, load data from scraper
                dailyScheduleFromCache = scraper.GetDailyScheduleForLocation(date, stateId, locationId);

                // add scraped data to cache
                cache.Insert(cacheKey, 
                    dailyScheduleFromCache, 
                    null, 
                    DateTime.Now.AddMinutes(scraperCacheDurationInMinutes), 
                    Cache.NoSlidingExpiration);
            }
            return dailyScheduleFromCache;
        }
    }
}
