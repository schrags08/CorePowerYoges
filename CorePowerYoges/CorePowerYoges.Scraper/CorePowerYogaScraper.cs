using CorePowerYoges.BLL;
using CorePowerYoges.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CorePowerYoges.Scraper
{
    public class CorePowerYogaScraper
    {
        private string scheduleUrl { get; set; }
        private string scheduleUrlShortDateFormat { get; set; }
        private string scheduleUrlOptionsFormat { get; set; }        

        /// <summary>
        /// Creates a new CorePowerYogaScraper
        /// </summary>
        /// <param name="scheduleUrl">The address portion of the Url all the way to the initial query string parameter.
        /// e.g. "https://www.healcode.com/widgets/schedules/print/ec16baf3?" </param>
        /// <param name="scheduleUrlShortDateFormat">The short date format required for the Url's date parameters.
        /// e.g. "yyyy-MM-dd" </param>
        /// <param name="scheduleUrlOptionsFormat">The format string template for the scheduleUrl's query string parameters.
        /// e.g. "options[location]={0}&amp;options[start_date]={1}&amp;options[end_date]={2}" </param>
        public CorePowerYogaScraper(string scheduleUrl, string scheduleUrlShortDateFormat, string scheduleUrlOptionsFormat)
        {
            this.scheduleUrl = scheduleUrl;
            this.scheduleUrlShortDateFormat = scheduleUrlShortDateFormat;
            this.scheduleUrlOptionsFormat = scheduleUrlOptionsFormat;
        }

        public DailySchedule GetDailyScheduleForLocation(DateTime date, Location location)
        {
            var locationBL = new LocationBL();
            var options = string.Format(scheduleUrlOptionsFormat,
                location.Id,
                date.ToString(scheduleUrlShortDateFormat),
                date.ToString(scheduleUrlShortDateFormat));
            var url = string.Concat(scheduleUrl, options);
            var schedule = new DailySchedule(date.Date, location);
            schedule.Location.Name = locationBL.GetLocationNameById(location.Id);

            try
            {
                using (var client = new WebClient())
                {
                    byte[] pageData;
                    pageData = client.DownloadData(url);

                    string pageHtml = Encoding.ASCII.GetString(pageData);
                    var htmlSnippet = Regex.Unescape(pageHtml);

                    var doc = new HtmlDocument();
                    doc.OptionFixNestedTags = true;
                    doc.LoadHtml(htmlSnippet);

                    var rawClasses = doc.DocumentNode.Descendants("tr").Where(t => ClassAttributeContainsString(t, "hc_class"));

                    foreach (HtmlNode node in rawClasses)
                    {
                        var session = new Session();

                        var startTime = node.Descendants("span").Where(s => ClassAttributeContainsString(s, "hc_starttime")).FirstOrDefault();
                        session.StartTime = GetDateTime(date, RemoveUnwantedCharactersFromNode(startTime));

                        var endTime = node.Descendants("span").Where(s => ClassAttributeContainsString(s, "hc_endtime")).FirstOrDefault();
                        session.EndTime = GetDateTime(date, RemoveUnwantedCharactersFromNode(endTime));

                        var name = node.Descendants("td").Where(s => ClassAttributeContainsString(s, "mbo_class")).FirstOrDefault();
                        session.Name = name.InnerText.Trim().Replace("???", "-");

                        var teacher = node.Descendants("td").Where(s => ClassAttributeContainsString(s, "trainer")).FirstOrDefault();
                        session.Teacher = teacher.InnerText.Trim();

                        schedule.Sessions.Add(session);
                    }
                }
            }
            catch (WebException ex)
            {
                // log error
                throw ex;
            }

            return schedule;

            throw new NotImplementedException();
        }

        public List<DailySchedule> GetDailyScheduleForLocations(DateTime date, List<Location> locations)
        {
            throw new NotImplementedException();
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

        /// <summary>
        /// Returns true if the HtmlNode's class attribute contains the target string.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool ClassAttributeContainsString(HtmlNode node, string target)
        {
            return node.Attributes.Contains("class") && node.Attributes["class"].Value.Contains(target);
        }

        /// <summary>
        /// Strips some unwanted characters from the HtmlNode
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private string RemoveUnwantedCharactersFromNode(HtmlNode node)
        {
            return node.InnerText.Replace("-", "").Replace(",", "");
        }

        /// <summary>
        /// Helper method to create a date with a specific time
        /// </summary>
        /// <param name="date">The date you need</param>
        /// <param name="time">The time you need, will be merged with the date</param>
        /// <returns>A strongly typed DateTime object with the specified date and time</returns>
        private DateTime GetDateTime(DateTime date, string time)
        {
            var dateFormat = "{0} {1}";
            var shortDate = date.ToShortDateString();
            return DateTime.Parse(string.Format(dateFormat, shortDate, time));
        }
    }
}
