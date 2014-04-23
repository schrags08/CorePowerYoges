using CorePowerYoges.BLL;
using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            StateBL blState = new StateBL();
            List<State> states = blState.GetAllStates();
        }
    }
}
