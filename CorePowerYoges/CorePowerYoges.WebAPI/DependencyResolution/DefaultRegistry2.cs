// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CorePowerYoges.WebAPI.DependencyResolution {
    using CorePowerYoges.BLL;
    using CorePowerYoges.DAL;
    using CorePowerYoges.Util;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
	
    public class DefaultRegistry2 : Registry {
        #region Constructors and Destructors

        public DefaultRegistry2() {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

            For(typeof(IState2Service)).Use(typeof(State2Service))
                .Ctor<IState2Repository>("stateRepository")
                .Is(new StateListDiskLoader2(ConfigurationHelpers.StateListPath))
                .Ctor<int>("allStateCacheDurationInMinutes")
                .Is(ConfigurationHelpers.AllStateCacheDurationInMinutes);

            For(typeof(IDailySchedule2Service)).Use(typeof(DailySchedule2Service))
                .Ctor<IDailySchedule2Repository>("dailyScheduleRepository")
                .Is(new CorePowerWebsiteScraper2(ConfigurationHelpers.WebsiteScraperUrlBaseFormatString,
                    ConfigurationHelpers.WebsiteScraperUrlShortDateFormat))
                .Ctor<int>("dailyScheduleForLocationCacheDurationInMinutes")
                .Is(ConfigurationHelpers.DailyScheduleForLocationCacheDurationInMinutes);
        }

        #endregion
    }
}