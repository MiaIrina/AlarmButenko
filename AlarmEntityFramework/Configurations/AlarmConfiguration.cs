using AlarmProjectButenko.Models;
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
            Property(a => a.Hour).HasColumnName("Hour").IsRequired();
            Property(a => a.Minutes).HasColumnName("Minutes").IsRequired();

        }

        
    }
}
