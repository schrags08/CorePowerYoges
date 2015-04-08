using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.DAL
{
    public class CorePowerYogesContext : DbContext
    {
        public DbSet<State> States { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
