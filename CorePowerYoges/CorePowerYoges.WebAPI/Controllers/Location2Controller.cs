using CorePowerYoges.Models;
using CorePowerYoges.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CorePowerYoges.WebAPI.Controllers
{
    public class Location2Controller : ApiController
    {
        ICorePowerYogesService2 _corePowerYogesService;

        public Location2Controller(ICorePowerYogesService2 corePowerYogesService)
        {
            this._corePowerYogesService = corePowerYogesService;
        }

        public Location2 Get(string id)
        {
            return this._corePowerYogesService.GetLocationById(id);
        }
    }
}
