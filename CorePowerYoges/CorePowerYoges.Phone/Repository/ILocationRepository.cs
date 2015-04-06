using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Phone.Repository
{
    public interface ILocationRepository
    {
        Task<Location> GetLocationByIdAsync(string locationId);
    }
}
