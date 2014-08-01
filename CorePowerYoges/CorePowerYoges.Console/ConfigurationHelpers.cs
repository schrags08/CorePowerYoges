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

        public static string ScraperUrlBase
        {
            get
            {
                return GetConfigurationValueByKey("scraperUrlBase");
            }
        }

        public static string ScraperUrlQueryString
        {
            get
            {
                return GetConfigurationValueByKey("scraperUrlQueryString");
            }
        }

        public static string ScraperUrlShortDateFormat
        {
            get
            {
                return GetConfigurationValueByKey("scraperUrlShortDateFormat");
            }
        }

        public static int ScraperCacheDurationInMinutes
        {
            get
            {
                int cacheDuration;
                string valueRaw = GetConfigurationValueByKey("scraperCacheDurationInMinutes");

                if (Int32.TryParse(valueRaw, out cacheDuration))
                {
                    return cacheDuration;
                }

                throw new ArgumentNullException("ScraperCacheDurationInMinutes");
            }
        }
    }
}
