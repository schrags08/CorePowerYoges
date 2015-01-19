using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CorePowerYoges.WinPhone.Repository
{
    public interface IState2Repository
    {
        Task<ObservableCollection<State2>> GetAllStatesAsync();
    }
}
