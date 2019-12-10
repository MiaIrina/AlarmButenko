using AlarmEntityFramework.Configurations;

using Models;
using System.Data.Entity;

namespace AlarmEntityFramework
{
    public class AlarmDBContext:DbContext
    {
        public AlarmDBContext():base("AlarmDB")
        {
         // Database.SetInitializer(new MigrateDatabaseToLatestVersion<AlarmDBContext, Configuration>(true));
          // Configuration.ProxyCreationEnabled = false;
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
