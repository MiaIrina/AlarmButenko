
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AlarmEntityFramework
{
    public static class AlarmEntWrapper
    {
        public static bool UserExistsInDB(User user)
        {
            using (var context = new AlarmDBContext())
            {
                return context.Users.Any(u => (u.Login == user.Login)||(u.Email==user.Email));
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
        public static void AddAlarm(Alarm alarm)
        {
            using (var context = new AlarmDBContext())
            {
                
                context.Alarms.Add(alarm);
                context.SaveChanges();
            }
        }
        public static void UpdateAlarm(Alarm alarm,int h,int m)
        {
            using (var context = new AlarmDBContext())
            {

                if (context.Alarms.Any(u => u.Hour == h && u.Minutes == m&&u.Guid!=alarm.Guid))
                {
                    throw new Exception("This alarm is already exists!");
                }
                Alarm al=context.Alarms.Where(u => u.Guid == alarm.Guid).First();
                al.Hour = h;
                al.Minutes = m;
                context.SaveChanges();
            }
        }
        public static void UpdateAlarms()
        {
            using (var context = new AlarmDBContext())
            {

              foreach (Alarm al in context.Alarms)
                {
                    al.BeginTime = al.CountDate(al.Hour,al.Minutes);
                }
                context.SaveChanges();
            }
        }
        public static void SaveAlarm(Alarm alarm)
        {
            using (var context = new AlarmDBContext())
            {
                context.Entry(alarm).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void DeleteAlarm(Alarm alarm)
        {
            using (var context = new AlarmDBContext())
            {
                alarm.deleteDBValues();
                context.Alarms.Attach(alarm);
                context.Alarms.Remove(alarm);
                context.SaveChanges();
            }
        }
        public static IEnumerable<Alarm> GetAlarms(Guid guid)
        {
            using (var context = new AlarmDBContext())
            {
                return context.Alarms.Where(r => r.UserGuid == guid).ToList();
            }
        }
        public static void EndAlarm(Alarm alarm, DateTime end)
        {
            using (var context = new AlarmDBContext())
            {

               
                Alarm al = context.Alarms.Where(u => u.Guid == alarm.Guid).First();
                if (al != null)
                {
                    al.EndTime = end;
                }
                context.SaveChanges();
            }
        }

        public static void Main()
        {

        }
}

    }

