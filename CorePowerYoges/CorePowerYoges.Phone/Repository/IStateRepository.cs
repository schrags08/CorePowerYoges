﻿using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CorePowerYoges.Phone.Repository
{
    public interface IStateRepository
    {
        Task<ObservableCollection<State>> GetAllStatesAsync();
    }
}
