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
    public class LocationController : ApiController
    {
        ICorePowerYogesService _corePowerYogesService;

        public LocationController(ICorePowerYogesService corePowerYogesService)
        {
            this._corePowerYogesService = corePowerYogesService;
        }

        public Location Get(string id)
        {
            return this._corePowerYogesService.GetLocationById(id);
        }
    }
}
