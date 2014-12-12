using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.WebAPI.Services
{
    public interface IStateService
    {
        IEnumerable<State> GetAllStates();
        State GetStateById(string id);
        State GetStateByAbbreviation(string stateAbbr);
    }
}
