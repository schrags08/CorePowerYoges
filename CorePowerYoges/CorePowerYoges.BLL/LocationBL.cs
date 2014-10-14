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
        private Cache cache = HttpRuntime.Cache;
        private ILocationDA locationDA;
        private int allLocationCacheDurationInMinutes;

        public LocationBL(ILocationDA locationDA, int allLocationCacheDurationInMinutes = 1440)
        {
            this.locationDA = locationDA;
            this.allLocationCacheDurationInMinutes = allLocationCacheDurationInMinutes;
        }

        public IEnumerable<Location> GetAllLocations()
        {
            string allLocationsCacheKey = "LocationBL.AllLocations";
            IEnumerable<Location> allLocationsFromCache = (IEnumerable<Location>)cache.Get(allLocationsCacheKey);

            if (allLocationsFromCache == null)
            {
                // no data in cache, reload from Data Access Layer
                allLocationsFromCache = locationDA.GetAllLocations();

                // insert item into cache
                cache.Insert(allLocationsCacheKey, allLocationsFromCache, null, DateTime.Now.AddMinutes(allLocationCacheDurationInMinutes), Cache.NoSlidingExpiration);
            }

            return allLocationsFromCache;
        }

        public IEnumerable<Location> GetLocationsInState(State state)
        {
            return GetAllLocations().Where(l => l.State == state);
        }

        public IEnumerable<Location> GetLocationsInState(string stateAbbr)
        {
            return GetAllLocations().Where(l => l.State.Abbreviation == stateAbbr.ToUpper());
        }

        public Location GetLocationById(string id)
        {
            return GetAllLocations().Where(l => l.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Gets a Location's Name via its Id property.
        /// </summary>
        /// <param name="id">The Id of the Location you're looking for</param>
        /// <returns>The Name of the Location or an empty string if there was no match.</returns>
        public string GetLocationNameById(string id)
        {
            var name = string.Empty;
            var location = GetAllLocations().FirstOrDefault(l => l.Id == id);

            if (location != null)
            {
                name = location.Name;
            }
            
            return name;
        }
    }
}
