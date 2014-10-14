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
            string allLocationsCacheKey = "LocationBL-AllLocations";
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

        public Location GetLocationById(string id)
        {
            return GetAllLocations().Where(l => l.Id == id).FirstOrDefault();
        }

        public IEnumerable<Location> GetAllLocationsInState(State state)
        {
            return GetAllLocations().Where(l => l.State == state).OrderBy(l => l.Name);
        }

        public IEnumerable<Location> GetAllLocationsInStateByStateId(string stateId)
        {
            return GetAllLocations().Where(l => l.State.Id == stateId).OrderBy(l => l.Name);
        }

        public IEnumerable<Location> GetAllLocationsInStateByStateAbbreviation(string stateAbbr)
        {
            return GetAllLocations().Where(l => l.State.Abbreviation == stateAbbr.ToUpper()).OrderBy(l => l.Name);
        }

        public IEnumerable<State> GetAllStatesContainingLocations()
        {
            return GetAllLocations().Select(l => l.State).Distinct().OrderBy(s => s.Name);
        }
    }
}
