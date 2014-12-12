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
    public class StateController : ApiController
    {
        ICorePowerYogesService _corePowerYogesService;

        public StateController(ICorePowerYogesService corePowerYogesService)
        {
            this._corePowerYogesService = corePowerYogesService;
        }

        public IEnumerable<State> Get()
        {
            return this._corePowerYogesService.GetAllStates();
        }

        public State Get(string id)
        {
            return this._corePowerYogesService.GetStateById(id);
        }
    }
}
