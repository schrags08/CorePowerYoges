using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.WebAPI.Services
{
    public interface ILocationService
    {
        IEnumerable<Location> GetAllLocations();
        Location GetLocationById(string id);
        IEnumerable<Location> GetAllLocationsInState(State state);
    }
}
