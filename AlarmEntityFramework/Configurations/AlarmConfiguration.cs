using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmEntityFramework.Configurations
{
   public  class AlarmConfiguration :EntityTypeConfiguration<Alarm>
    {
        public AlarmConfiguration()
        {
            ToTable("Alarms");
            HasKey(a => a.Guid);
            Property(a => a.Guid).HasColumnName("Id").IsRequired();
            Property(a => a.BeginTime).HasColumnName("BeginTime").HasColumnType("datetime2").IsRequired();
            Property(a => a.EndTime).HasColumnName("EndTime").HasColumnType("datetime2").IsRequired();
            Property(a => a.Hour).HasColumnName("Hour").HasColumnType("int").IsRequired();
            Property(a => a.Minutes).HasColumnName("Minutes").HasColumnType("int").IsRequired();

        }

        
    }
}
