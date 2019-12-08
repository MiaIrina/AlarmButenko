using AlarmProjectButenko.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmEntityFramework.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users");
            HasKey(user => user.Guid);
            Property(user => user.Guid).HasColumnName("Guid").IsRequired();
            Property(user => user.Name).HasColumnName("Name").IsRequired();
            Property(user => user.Surname).HasColumnName("Surname").IsRequired();
            Property(user => user.Login).HasColumnName("Login").IsRequired();
            Property(user => user.Email).HasColumnName("Email").IsRequired();
            Property(user => user.Password).HasColumnName("Password").IsRequired();
            Property(user => user.LastLoginDate).HasColumnName("DateOfLastLogin").HasColumnType("datetime2").IsRequired();
            HasMany(user => user.Alarms).
                WithRequired(a => a.User)
                .HasForeignKey(a => a.OwnerGuid)
                .WillCascadeOnDelete(true);
                
        }
    }
}
