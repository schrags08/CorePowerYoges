using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.BLL
{
    public interface IState2Service
    {
        IEnumerable<State2> GetAllStates();
		State2 GetStateById(string id);
        State2 GetStateByAbbreviation(string stateAbbr);
        Location2 GetLocationById(string id);
    }
}
