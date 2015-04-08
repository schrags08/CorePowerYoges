namespace CorePowerYoges.DAL.Migrations
{
    using CorePowerYoges.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<CorePowerYoges.DAL.CorePowerYogesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        //protected override void Seed(CorePowerYoges.DAL.CorePowerYogesContext context)
        //{
        //    var states = new List<State>() {
        //        new State { Name = "California", Abbreviation = "CA", CorePowerYogaStateId = "ec6baf3",
        //            Locations = new List<Location>() { 
        //                new Location { CorePowerYogaLocationId = "1419_7", Name = "Berkeley" },
        //                new Location { CorePowerYogaLocationId = "1419_26", Name = "Encino" },
        //                new Location { CorePowerYogaLocationId = "1419_30", Name = "Hollywood" },
        //                new Location { CorePowerYogaLocationId = "1419_12", Name = "Sherman Oaks" },
        //                new Location { CorePowerYogaLocationId = "1419_32", Name = "Studio City" },
        //                new Location { CorePowerYogaLocationId = "1419_18", Name = "Torrance" },
        //                new Location { CorePowerYogaLocationId = "1419_16", Name = "Wilshire" },
        //                new Location { CorePowerYogaLocationId = "1419_5", Name = "Aliso Viejo" },
        //                new Location { CorePowerYogaLocationId = "1419_9", Name = "Costa Mesa" },
        //                new Location { CorePowerYogaLocationId = "1419_3", Name = "Huntington Beach" },
        //                new Location { CorePowerYogaLocationId = "1419_15", Name = "Irvine" },
        //                new Location { CorePowerYogaLocationId = "1419_21", Name = "Tustin" },
        //                new Location { CorePowerYogaLocationId = "1419_37", Name = "UC Irvine" },
        //                new Location { CorePowerYogaLocationId = "1419_17", Name = "Clairemont Mesa" },
        //                new Location { CorePowerYogaLocationId = "1419_24", Name = "Del Mar" },
        //                new Location { CorePowerYogaLocationId = "1419_14", Name = "Encinitas" },
        //                new Location { CorePowerYogaLocationId = "1419_2", Name = "Hillcrest" },
        //                new Location { CorePowerYogaLocationId = "1419_6", Name = "La Jolla - UTC" },
        //                new Location { CorePowerYogaLocationId = "1419_33", Name = "La Mesa" },
        //                new Location { CorePowerYogaLocationId = "1419_8", Name = "Mission Valley" },
        //                new Location { CorePowerYogaLocationId = "1419_13", Name = "North Park" },
        //                new Location { CorePowerYogaLocationId = "1419_4", Name = "Pacific Beach" },
        //                new Location { CorePowerYogaLocationId = "1419_1", Name = "Point Loma" },
        //                new Location { CorePowerYogaLocationId = "1419_19", Name = "Poway" },
        //                new Location { CorePowerYogaLocationId = "39055_1", Name = "Santa Barbara" }
        //            }
        //        },
        //        new State { Name = "Colorado", Abbreviation = "CO", CorePowerYogaStateId = "ec4baf3",
        //            Locations = new List<Location>() {
        //                new Location { CorePowerYogaLocationId = "941_13", Name = "Aurora" },
        //                new Location { CorePowerYogaLocationId = "35507_3", Name = "Belmar" },
        //                new Location { CorePowerYogaLocationId = "110_9", Name = "Boulder on the Hill" },
        //                new Location { CorePowerYogaLocationId = "1797_1", Name = "Broomfield" },
        //                new Location { CorePowerYogaLocationId = "110_5", Name = "Cherry Hills" },
        //                new Location { CorePowerYogaLocationId = "110_15", Name = "Colorado Blvd" },
        //                new Location { CorePowerYogaLocationId = "2601_1", Name = "Parker" },
        //                new Location { CorePowerYogaLocationId = "2332_1", Name = "Stapleton" },
        //                new Location { CorePowerYogaLocationId = "1797_2", Name = "Flatirons" },
        //                new Location { CorePowerYogaLocationId = "110_13", Name = "Ft. Collins" },
        //                new Location { CorePowerYogaLocationId = "110_6", Name = "Garden of the Gods" },
        //                new Location { CorePowerYogaLocationId = "110_1", Name = "Grant Street - Downtown" },
        //                new Location { CorePowerYogaLocationId = "110_14", Name = "Highlands" },
        //                new Location { CorePowerYogaLocationId = "941_12", Name = "Highlands Ranch" },
        //                new Location { CorePowerYogaLocationId = "941_11", Name = "Ken Caryl" },
        //                new Location { CorePowerYogaLocationId = "35507_2", Name = "Littleton" },
        //                new Location { CorePowerYogaLocationId = "110_16", Name = "LoHi" },
        //                new Location { CorePowerYogaLocationId = "110_7", Name = "Nevada" },
        //                new Location { CorePowerYogaLocationId = "110_12", Name = "North Boulder" },
        //                new Location { CorePowerYogaLocationId = "941_2", Name = "Park Meadows" },
        //                new Location { CorePowerYogaLocationId = "110_3", Name = "South Boulder" }
        //            }
        //        },
        //        new State { Name = "Washington, DC", Abbreviation = "DC", CorePowerYogaStateId = "ec7994baf3",
        //            Locations = new List<Location>() {
        //                new Location { CorePowerYogaLocationId = "31731_1", Name = "Bethesda" },
        //                new Location { CorePowerYogaLocationId = "31731_9", Name = "DC - Falls Church" },
        //                new Location { CorePowerYogaLocationId = "31731_2", Name = "Georgetown" },
        //                new Location { CorePowerYogaLocationId = "31731_6", Name = "Glover Park" }
        //            }
        //        },
        //        new State { Name = "Hawaii", Abbreviation = "HI", CorePowerYogaStateId = "ec3446baf3",
        //            Locations = new List<Location>() {
        //                new Location { CorePowerYogaLocationId = "23291_1", Name = "Honolulu" }
        //            }
        //        },
        //        new State { Name = "Illinois", Abbreviation = "IL", CorePowerYogaStateId = "ec16baf3",
        //            Locations = new List<Location>() {
        //                new Location { CorePowerYogaLocationId = "10067_7", Name = "Arlington Heights" },
        //                new Location { CorePowerYogaLocationId = "10067_8", Name = "Deerfield/Highland Park" },
        //                new Location { CorePowerYogaLocationId = "10067_6", Name = "Elmhurst" },
        //                new Location { CorePowerYogaLocationId = "10067_5", Name = "Hinsdale" },
        //                new Location { CorePowerYogaLocationId = "864_16", Name = "Bucktown" },
        //                new Location { CorePowerYogaLocationId = "864_10", Name = "Gold Coast" },
        //                new Location { CorePowerYogaLocationId = "864_25", Name = "Hyde Park" },
        //                new Location { CorePowerYogaLocationId = "864_15", Name = "Lakeview" },
        //                new Location { CorePowerYogaLocationId = "864_12", Name = "Lincoln Park" },
        //                new Location { CorePowerYogaLocationId = "864_18", Name = "Lincoln Square" },
        //                new Location { CorePowerYogaLocationId = "864_17", Name = "Roscoe Village" },
        //                new Location { CorePowerYogaLocationId = "864_7", Name = "South Loop" },
        //                new Location { CorePowerYogaLocationId = "864_22", Name = "Streeterville" },
        //                new Location { CorePowerYogaLocationId = "864_19", Name = "Uptown" },
        //                new Location { CorePowerYogaLocationId = "864_23", Name = "West Loop" },
        //                new Location { CorePowerYogaLocationId = "10067_4", Name = "Naperville" },
        //                new Location { CorePowerYogaLocationId = "10067_1", Name = "Oak Park/River Forest" },
        //                new Location { CorePowerYogaLocationId = "10067_2", Name = "Old Orchard" },
        //                new Location { CorePowerYogaLocationId = "10067_3", Name = "Park Ridge" }
        //            }
        //        },
        //        new State { Name = "Massachussets", Abbreviation = "MA", CorePowerYogaStateId = "ec9750baf3",
        //            Locations = new List<Location>() {
        //                new Location { CorePowerYogaLocationId = "31731_4", Name = "Fresh Pond" },
        //                new Location { CorePowerYogaLocationId = "31731_5", Name = "Medford" },
        //                new Location { CorePowerYogaLocationId = "31731_8", Name = "Newton" }
        //            }
        //        },
        //        new State { Name = "Maryland", Abbreviation = "MD", CorePowerYogaStateId = "ec7994baf3",
        //            Locations = new List<Location>() {
        //                new Location { CorePowerYogaLocationId = "31731_1", Name = "Bethesda" }
        //            }
        //        },
        //        new State { Name = "Minnesota", Abbreviation = "MN", CorePowerYogaStateId = "ec17baf3",
        //            Locations = new List<Location>() {
        //                new Location { CorePowerYogaLocationId = "4059_1", Name = "Edina" },
        //                new Location { CorePowerYogaLocationId = "32618_1", Name = "Maple Grove" },
        //                new Location { CorePowerYogaLocationId = "864_1", Name = "Downtown (Minneapolis)" },
        //                new Location { CorePowerYogaLocationId = "864_4", Name = "Eden Prairie" },
        //                new Location { CorePowerYogaLocationId = "864_13", Name = "Highland Park" },
        //                new Location { CorePowerYogaLocationId = "864_6", Name = "Minnetonka" },
        //                new Location { CorePowerYogaLocationId = "864_2", Name = "St. Louis Park" },
        //                new Location { CorePowerYogaLocationId = "864_3", Name = "St. Paul" },
        //                new Location { CorePowerYogaLocationId = "864_8", Name = "Stadium Village" },
        //                new Location { CorePowerYogaLocationId = "864_5", Name = "Uptown" },
        //                new Location { CorePowerYogaLocationId = "13947_1", Name = "Woodbury" }
        //            }
        //        },
        //        new State { Name = "Oregon", Abbreviation = "OR", CorePowerYogaStateId = "ec8baf3",
        //            Locations = new List<Location>() {
        //                new Location { CorePowerYogaLocationId = "1419_22", Name = "Portland NW" },
        //                new Location { CorePowerYogaLocationId = "1419_23", Name = "Portland SE" }
        //            }
        //        },
        //        new State { Name = "Texas", Abbreviation = "TX", CorePowerYogaStateId = "ec7885baf3",
        //            Locations = new List<Location>() {
        //                new Location { CorePowerYogaLocationId = "864_20", Name = "Austin (Monarch)" },
        //                new Location { CorePowerYogaLocationId = "864_21", Name = "Austin (Triangle)" }
        //            }
        //        },
        //        new State { Name = "Utah", Abbreviation = "UT", CorePowerYogaStateId = "ec9025baf3",
        //            Locations = new List<Location>() {
        //                new Location { CorePowerYogaLocationId = "35507_4", Name = "Foothill SLC" },
        //            new Location { CorePowerYogaLocationId = "35507_1", Name = "Highland SLC" }
        //            }
        //        },
        //        new State { Name = "Virginia", Abbreviation = "VA", CorePowerYogaStateId = "ec7994baf3",
        //            Locations = new List<Location>() {
        //                new Location { CorePowerYogaLocationId = "31731_9", Name = "DC - Falls Church" }
        //            }
        //        },
        //        new State { Name = "Washington", Abbreviation = "WA", CorePowerYogaStateId = "ec7886baf3",
        //            Locations = new List<Location>() {
        //                new Location { CorePowerYogaLocationId = "1419_25", Name = "Ballard" },
        //                new Location { CorePowerYogaLocationId = "1419_35", Name = "Bellevue" },
        //                new Location { CorePowerYogaLocationId = "1419_31", Name = "Capitol Hill" },
        //                new Location { CorePowerYogaLocationId = "1419_34", Name = "Greenwood" },
        //                new Location { CorePowerYogaLocationId = "1419_36", Name = "Queen Anne" }
        //            }
        //        },
        //    };
        //    context.States.AddOrUpdate(states.ToArray());
        //}
    }
}
