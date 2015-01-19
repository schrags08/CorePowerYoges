using CorePowerYoges.BLL;
using CorePowerYoges.DAL;
using CorePowerYoges.Models;
using CorePowerYoges.Util;
using CorePowerYoges.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CorePowerYoges.WebAPI.Controllers
{
    public class State2Controller : ApiController
    {
        ICorePowerYogesService2 _corePowerYogesService;

        public State2Controller(ICorePowerYogesService2 corePowerYogesService)
        {
            this._corePowerYogesService = corePowerYogesService;
        }

        public IEnumerable<State2> Get()
        {
            return this._corePowerYogesService.GetAllStates();
        }

        public State2 Get(string id)
        {
            return this._corePowerYogesService.GetStateById(id);
        }
    }
}
