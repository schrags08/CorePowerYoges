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
            string cacheKey = "LocationBL-AllLocations";
            IEnumerable<Location> dataFromCache = (IEnumerable<Location>)cache.Get(cacheKey);

            if (dataFromCache == null)
            {
                // no data in cache, reload from Data Access Layer
                dataFromCache = locationDA.GetAllLocations();

                // insert item into cache
                cache.Insert(cacheKey, 
                    dataFromCache, 
                    null, 
                    DateTime.Now.AddMinutes(allLocationCacheDurationInMinutes), 
                    Cache.NoSlidingExpiration);
            }

            return dataFromCache;
        }        

        public Location GetLocationById(string id)
        {
            return GetAllLocations().Where(l => l.Id == id).FirstOrDefault();
        }

        public IEnumerable<Location> GetAllLocationsInState(State state)
        {
            return locationDA.GetAllLocations()
                .Where(l => l.StateId == state.Id).OrderBy(l => l.Name);
        }
    }
}
