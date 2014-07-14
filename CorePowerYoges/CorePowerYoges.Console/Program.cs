using CorePowerYoges.BLL;
using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            StateBL blState = new StateBL();
            //List<State> states = blState.GetAllStatesAndLocations();
            List<State> states = blState.GetAllStatesWithLocations();

            foreach (State s in states)
            {
                Console.WriteLine(string.Format("{0} ({1})", s.Name, s.Abbreviation));
            }

            Console.ReadLine();
        }
    }
}
