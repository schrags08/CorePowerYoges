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
    public class StateService : IStateService
    {
        private Cache cache = HttpRuntime.Cache;
        private IStateRepository _stateRepository;
        private int allStateCacheDurationInMinutes;

        public StateService(IStateRepository stateRepository,
            int allStateCacheDurationInMinutes = 1440)
        {
            this._stateRepository = stateRepository;
            this.allStateCacheDurationInMinutes = allStateCacheDurationInMinutes;
        }

        public IEnumerable<State> GetAllStates()
        {
            string cacheKey = "StateService-AllStates";
            IEnumerable<State> dataFromCache = (IEnumerable<State>)cache.Get(cacheKey);

            if (dataFromCache == null)
            {
                // no data in cache, reload from Data Access Layer
                dataFromCache = _stateRepository.GetAllStates();

                // insert item into cache
                cache.Insert(cacheKey, 
                    dataFromCache, 
                    null, 
                    DateTime.Now.AddMinutes(allStateCacheDurationInMinutes), 
                    Cache.NoSlidingExpiration);
            }

            return dataFromCache;
        }

        public State GetStateById(string id)
        {
            return GetAllStates()
                .Where(s => s.Id == id).FirstOrDefault();
        }

        public State GetStateByAbbreviation(string stateAbbr)
        {
            return GetAllStates()
                .Where(s => s.Abbreviation == stateAbbr.ToUpper()).FirstOrDefault();
        }

        public Location GetLocationById(string id)
        {
            return GetAllStates().SelectMany(s => s.Locations).FirstOrDefault(l => l.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase));
        }

        //will we need a GetLocationByIds?
    }
}
