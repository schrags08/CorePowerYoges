using CorePowerYoges.Models;
using CorePowerYoges.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.BLL
{
    public class StateBL
    {
        public List<State> GetAllStatesAndLocations()
        {
            StateDA daState = new StateDA();
            return daState.GetAllStatesAndLocations();
        }

        public List<State> GetAllStatesWithLocations()
        {
            StateDA daState = new StateDA();
            return daState.GetAllStatesWithLocations();
        }
    }
}
