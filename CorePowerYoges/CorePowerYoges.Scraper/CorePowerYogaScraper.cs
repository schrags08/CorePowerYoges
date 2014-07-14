using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Scraper
{
    public static class CorePowerYogaScraper
    {
        private static bool ClassAttributeContainsString(HtmlNode node, string target)
        {
            return node.Attributes.Contains("class") && node.Attributes["class"].Value.Contains(target);
        }

        private static string RemoveUnwantedCharactersFromNode(HtmlNode node)
        {
            return node.InnerText.Replace("-", "").Replace(",", "");
        }

        /// <summary>
        /// Helper method to create a date with a specific time
        /// </summary>
        /// <param name="date">The date you need</param>
        /// <param name="time">The time you need, will be merged with the date</param>
        /// <returns>A strongly typed DateTime object with the specified date and time</returns>
        private static DateTime GetDateTime(DateTime date, string time)
        {
            var dateFormat = "{0} {1}";
            var shortDate = date.ToShortDateString();
            return DateTime.Parse(string.Format(dateFormat, shortDate, time));
        }

        //public static CorePowerYogaDailySchedule GetDailyScheduleByLocation(DateTime date, CorePowerYogaLocation location)
        //{
        //    throw new NotImplementedException();

        //    //var scheduleBaseUrl = ConfigurationHelpers.GetConfigurationValueByKey("scheduleBaseUrl");
        //    //var scheduleUrlShortDateFormat = ConfigurationHelpers.GetConfigurationValueByKey("scheduleUrlShortDateFormat");
        //    //var scheduleOptionsFormat = ConfigurationHelpers.GetConfigurationValueByKey("scheduleOptionsFormat");
        //    //var options = string.Format(scheduleOptionsFormat,
        //    //    location.LocationCode,
        //    //    date.ToString(scheduleUrlShortDateFormat),
        //    //    date.ToString(scheduleUrlShortDateFormat));
        //    //var cacheKey = GetCacheKey(date.ToString(scheduleUrlShortDateFormat), location.LocationCode);
        //    //var url = string.Concat(scheduleBaseUrl, options);

        //    //var schedule = new CorePowerYogaDailySchedule(date.Date, location);
        //    //schedule.Location.Name = CorePowerYogaLocationHelpers.GetNameByLocationCode(location.LocationCode);

        //    //using (var client = new WebClient())
        //    //{
        //    //    byte[] pageData;
        //    //    if (cache.Get(cacheKey) != null)
        //    //    {
        //    //        pageData = (byte[])cache.Get(cacheKey);
        //    //    }
        //    //    else
        //    //    {
        //    //        pageData = client.DownloadData(url);
        //    //    }

        //    //    string pageHtml = Encoding.ASCII.GetString(pageData);
        //    //    var htmlSnippet = Regex.Unescape(pageHtml);

        //    //    var doc = new HtmlDocument();
        //    //    doc.OptionFixNestedTags = true;
        //    //    doc.LoadHtml(htmlSnippet);

        //    //    var rawClasses = doc.DocumentNode.Descendants("tr").Where(t => ClassAttributeContainsString(t, "hc_class"));

        //    //    foreach (HtmlNode node in rawClasses)
        //    //    {
        //    //        var yc = new CorePowerYogaClass();

        //    //        var startTime = node.Descendants("span").Where(s => ClassAttributeContainsString(s, "hc_starttime")).FirstOrDefault();
        //    //        yc.StartTime = GetDateTime(date, RemoveUnwantedCharactersFromNode(startTime));

        //    //        var endTime = node.Descendants("span").Where(s => ClassAttributeContainsString(s, "hc_endtime")).FirstOrDefault();
        //    //        yc.EndTime = GetDateTime(date, RemoveUnwantedCharactersFromNode(endTime));

        //    //        var name = node.Descendants("td").Where(s => ClassAttributeContainsString(s, "mbo_class")).FirstOrDefault();
        //    //        yc.Name = name.InnerText.Trim().Replace("???", "-");

        //    //        var teacher = node.Descendants("td").Where(s => ClassAttributeContainsString(s, "trainer")).FirstOrDefault();
        //    //        yc.Teacher = teacher.InnerText.Trim();

        //    //        schedule.YogaClasses.Add(yc);
        //    //    }

        //    //    if (cache.Get(cacheKey) == null)
        //    //    {
        //    //        double scheduleCacheDurationInMinutes = 10;
        //    //        Double.TryParse(ConfigurationHelpers.GetConfigurationValueByKey("scheduleCacheDurationInMinutes"), out scheduleCacheDurationInMinutes);
        //    //        cache.Add(cacheKey, pageData, null, DateTime.Now.AddMinutes(scheduleCacheDurationInMinutes), Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        //    //    }
        //    //    return schedule;
        //    //}
        //}

        //public static List<CorePowerYogaDailySchedule> GetDailyScheduleByLocations(DateTime date, List<CorePowerYogaLocation> locations)
        //{
        //    //var schedules = new List<CorePowerYogaDailySchedule>();

        //    //foreach (var location in locations)
        //    //{
        //    //    var schedule = GetDailyScheduleByLocation(date, location);
        //    //    schedules.Add(schedule);
        //    //}

        //    //return schedules;

        //    throw new NotImplementedException();
        //}
    }
}
