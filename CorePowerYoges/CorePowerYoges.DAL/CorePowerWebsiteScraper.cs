using CorePowerYoges.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CorePowerYoges.DAL
{
    /// <summary>
    /// Scrapes the CPY website at www.corepoweryoga.com, caching should be handled externally.
    /// </summary>
    public class CorePowerWebsiteScraper : IDailyScheduleRepository
    {
        private string urlBaseFormatString { get; set; }
        private string urlShortDateFormat { get; set; }

        /// <summary>
        /// Creates a new CorePowerYogaScraper
        /// </summary>
        public CorePowerWebsiteScraper(string urlBaseFormatString,
            string urlShortDateFormat)
        {
            this.urlBaseFormatString = urlBaseFormatString;
            this.urlShortDateFormat = urlShortDateFormat;
        }

        /// <summary>
        /// Gets a Daily Schedule from the CPY website.
        /// </summary>
        /// <param name="date">The date of the desired Daily Schedule</param>
        /// <param name="stateId">the stateId of the desired Daily Schedule</param>
        /// <param name="locationId">the locationId of the desired Daily Schedule</param>
        /// <returns>A Daily Schedule for a Location on a given date</returns>
        public DailySchedule GetDailyScheduleByStateIdAndLocationId(DateTime date, string stateId, string locationId)
        {
            var schedule = new DailySchedule(date.Date, locationId);
            var url = string.Format(urlBaseFormatString, 
                stateId,
                locationId,
                date.ToString(urlShortDateFormat),
                date.ToString(urlShortDateFormat));

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
                        var startTimeElement = node.Descendants("span").Where(s => ClassAttributeContainsString(s, "hc_starttime")).FirstOrDefault();
                        var startTime = GetDateTime(date, RemoveUnwantedCharactersFromNode(startTimeElement));

                        var endTimeElement = node.Descendants("span").Where(s => ClassAttributeContainsString(s, "hc_endtime")).FirstOrDefault();
                        var endTime = GetDateTime(date, RemoveUnwantedCharactersFromNode(endTimeElement));

                        var nameElement = node.Descendants("td").Where(s => ClassAttributeContainsString(s, "mbo_class")).FirstOrDefault();
                        var name = nameElement.InnerText.Trim().Replace("???", "-");

                        var teacherElement = node.Descendants("td").Where(s => ClassAttributeContainsString(s, "trainer")).FirstOrDefault();
                        var teacher = teacherElement.InnerText.Trim();

                        var session = new Session(startTime, endTime, name, teacher, locationId);
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
        }

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
