using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorePowerYoges.WebAPI.Services
{
    public class LocationService : ILocationService
    {
        public IEnumerable<Location> GetAllLocations()
        {
            throw new NotImplementedException();
        }

        public Location GetLocationById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> GetAllLocationsInState(State state)
        {
            throw new NotImplementedException();
        }
    }
}