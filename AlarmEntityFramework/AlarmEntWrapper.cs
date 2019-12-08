using AlarmProjectButenko.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmEntityFramework
{
    public static class AlarmEntWrapper
    {
        public static bool UserExistsInDB(string login)
        {
            using (var context = new AlarmDBContext())
            {
                return context.Users.Any(u => u.Login == login);
            }
        }
        public static User UserByLogin(string login)
        {
            using (var context = new AlarmDBContext())
            
                return context.Users.Include(us=>us.Alarms).FirstOrDefault(us => us.Login == login);
            }

       public static User UserByGuid(Guid guid)
    {
        using (var context = new AlarmDBContext())

            return context.Users.Include(us => us.Alarms).FirstOrDefault(us => us.Guid == guid);
    }
        public static void AddUser(User user)
        {
            using (var context = new AlarmDBContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
        public static void AddUser(User user)
        {
            using (var context = new AlarmDBContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
    

}
public static void Main()
        {

        }

    }
}
