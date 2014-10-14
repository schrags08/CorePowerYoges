using CorePowerYoges.BLL;
using CorePowerYoges.DAL;
using CorePowerYoges.Models;
using CorePowerYoges.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.ConsoleTester
{
    class Program
    {
        private static StateBL blState;
        private static LocationBL blLocation;
        private static DailyScheduleBL blDailySchedule;

        static void Main(string[] args)
        {
            Init();

            PrintSeparator();

            PrintAllStatesWithLocations();

            PrintSeparator();

            PrintAllLocationsInState("CO");

            PrintSeparator();

            PrintDailyScheduleForLocation(DateTime.Now, "110_6");

            PrintSeparator();

            PrintDailyScheduleForLocation(DateTime.Now.AddDays(1), "110_6");

            PrintSeparator();

            Console.ReadLine();
        }

        private static void Init()
        {
            var locationListFromDiskLoader = new LocationListDiskLoader(ConfigurationHelpers.LocationListPath);
            blLocation = new LocationBL(locationListFromDiskLoader,
                ConfigurationHelpers.AllLocationCacheDurationInMinutes);
            blState = new StateBL(locationListFromDiskLoader,
                ConfigurationHelpers.AllStateCacheDurationInMinutes);

            var websiteScraper = new CorePowerWebsiteScraper(ConfigurationHelpers.WebsiteScraperUrlBaseFormatString,
                ConfigurationHelpers.WebsiteScraperUrlShortDateFormat);            
            blDailySchedule = new DailyScheduleBL(websiteScraper, 
                ConfigurationHelpers.DailyScheduleForLocationCacheDurationInMinutes);
        }

        private static void PrintSeparator()
        {
            Console.WriteLine("============================================================");
        }

        private static void PrintAllStatesWithLocations()
        {
            var states = blState.GetAllStates();

            if (states.Count() > 0)
            {
                Console.WriteLine(string.Format("{1} States With Locations:{0}",
                    Environment.NewLine,
                    states.Count()));

                foreach (State state in states)
                {
                    var stateSummary = new StateSummary(state);

                    Console.WriteLine(string.Format("{0} [{3}] ({1}) - {2}",
                        state.Name,
                        state.Id,
                        stateSummary.TotalLocationsLabel,
                        state.Abbreviation));
                }

                Console.Write(Environment.NewLine);
            }
        }

        private static void PrintAllLocationsInState(string stateAbbr)
        {
            var state = blState.GetStateByAbbreviation(stateAbbr);
            var locations = blLocation.GetAllLocationsInState(state);

            if (locations.Count() > 0)
            {
                Console.WriteLine(string.Format("{1} Locations in {2}:{0}", 
                    Environment.NewLine,
                    locations.Count(),
                    state.Abbreviation));

                foreach (Location location in locations)
                {
                    Console.WriteLine(string.Format("{0} - {1}", location.Name, location.Id));
                }

                Console.Write(Environment.NewLine);
            }
        }

        private static void PrintDailyScheduleForLocation(DateTime date, string locationId)
        {
            var location = blLocation.GetLocationById(locationId);
            var dailySchedule = blDailySchedule.GetDailyScheduleByDateAndLocation(date, location);

            if (dailySchedule.Sessions.Count() > 0)
            {
                var dailyScheduleSummary = new DailyScheduleSummary(dailySchedule);

                Console.WriteLine(string.Format("{1} Schedule for {0} ({2}):",
                    location.Name, 
                    date.ToShortDateString(),
                    location.Id));

                Console.WriteLine(string.Format("{1}{0}",
                    Environment.NewLine,
                    dailyScheduleSummary.RemainingSessionsLabel));

                foreach (Session session in dailySchedule.Sessions)
                {
                    var sessionSummary = new SessionSummary(session);

                    Console.WriteLine(string.Format("{0}", sessionSummary.TimeSummaryLabel));

                    Console.WriteLine(string.Format("{1} ({2}){0}", 
                        Environment.NewLine,
                        session.Name, 
                        session.Teacher));
                }

                Console.Write(Environment.NewLine);
            }            
        }
    }
}
