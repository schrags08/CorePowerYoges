using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.WinPhone.Repository
{
    public interface ILocation2Repository
    {
        Task<Location2> GetLocationByIdAsync(string locationId);
    }
}
