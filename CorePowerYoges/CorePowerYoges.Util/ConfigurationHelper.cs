using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Util
{
    public static class ConfigurationHelpers
    {
        public static string GetConfigurationValueByKey(string key)
        {
            return !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings[key]) ? ConfigurationManager.AppSettings[key] : string.Empty;
        }

        public static int GetConfigurationIntValueByKey(string key)
        {
            int value;
            string valueRaw = GetConfigurationValueByKey(key);

            if (Int32.TryParse(valueRaw, out value))
            {
                return value;
            }

            throw new ArgumentNullException(key);
        }

        public static string WebsiteScraperUrlBaseFormatString
        {
            get
            {
                return GetConfigurationValueByKey("WebsiteScraperUrlBaseFormatString");
            }
        }

        public static string WebsiteScraperUrlShortDateFormat
        {
            get
            {
                return GetConfigurationValueByKey("WebsiteScraperUrlShortDateFormat");
            }
        }

        public static int DailyScheduleForLocationCacheDurationInMinutes
        {
            get
            {
                return GetConfigurationIntValueByKey("DailyScheduleForLocationCacheDurationInMinutes");
            }
        }

        public static int AllLocationCacheDurationInMinutes
        {
            get
            {
                return GetConfigurationIntValueByKey("AllLocationCacheDurationInMinutes");
            }
        }

        public static int AllStateCacheDurationInMinutes
        {
            get
            {
                return GetConfigurationIntValueByKey("AllStateCacheDurationInMinutes");
            }
        }

        public static string LocationListPath
        {
            get
            {
                return GetConfigurationValueByKey("LocationListPath");
            }
        }
    }
}