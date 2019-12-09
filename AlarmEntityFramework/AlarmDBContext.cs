using AlarmEntityFramework.Configurations;
using AlarmEntityFramework.Migrations;

using Models;
using System;
using System.Collections.Generic;

using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmEntityFramework
{
   public class AlarmDBContext:DbContext
    {
        public AlarmDBContext() : base("Alarm")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AlarmDBContext, Configuration>(true));
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Alarm> Alarms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new AlarmConfiguration());
        }
    }
}
