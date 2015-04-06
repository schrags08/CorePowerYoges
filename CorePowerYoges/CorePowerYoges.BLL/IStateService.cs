using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.BLL
{
    public interface IStateService
    {
        IEnumerable<State> GetAllStates();
		State GetStateById(string id);
        Location GetLocationById(string id);
    }
}
