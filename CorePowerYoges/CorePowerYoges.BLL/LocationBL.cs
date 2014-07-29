using CorePowerYoges.DAL;
using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace CorePowerYoges.BLL
{
    public class LocationBL
    {
        protected Cache cache = HttpRuntime.Cache;
        protected List<Location> AllLocations
        {
            get
            {
                string locationsCacheKey = "LocationBL.AllLocations";
                List<Location> allLocationsFromCache = (List<Location>)cache.Get(locationsCacheKey);
                if (allLocationsFromCache == null)
                {
                    // no data in cache, reload from Data Access Layer
                    ILocationDA locationDA = new LocationDA();
                    allLocationsFromCache = locationDA.GetAllLocations();

                    // insert item into cache for 1 day
                    // TODO externalize cache expiration time
                    cache.Insert(locationsCacheKey, allLocationsFromCache, null, DateTime.Now.AddMinutes(1440), Cache.NoSlidingExpiration);
                }
                return allLocationsFromCache;
            }
        }

        public LocationBL()
        {
        }

        public List<Location> GetAllLocations()
        {
            return AllLocations;
        }

        public List<Location> GetLocationsInState(State state)
        {
            return AllLocations.Where(l => l.State == state).ToList();
        }

        public List<Location> GetLocationsInState(string stateAbbr)
        {
            return AllLocations.Where(l => l.State.Abbreviation == stateAbbr.ToUpper()).ToList();
        }

        public Location GetLocationById(string id)
        {
            return AllLocations.Where(l => l.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Gets the first Location via its Id property.
        /// </summary>
        /// <param name="id">The Id of the Location you're looking for</param>
        /// <returns>The Name of the Location or an empty string if there was no match.</returns>
        public string GetLocationNameById(string id)
        {
            var location = AllLocations.FirstOrDefault(l => l.Id == id);
            var name = string.Empty;
            
            if (location != null)
            {
                name = location.Name;
            }
            
            return name;
        }
    }
}
