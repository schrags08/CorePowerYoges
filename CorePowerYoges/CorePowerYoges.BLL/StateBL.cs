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
        public List<State> GetAllStates()
        {
            StateDA daState = new StateDA();
            return daState.GetAllStates();
        }
    }
}
