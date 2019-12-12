

using Models;
using System;

namespace Client.Tools.Managers
{
    internal static class StationManager
    {
        internal static User Current { get; set; }
        public static event Action CloseThreads;
        internal static void CloseApp()
        {
            CloseThreads?.Invoke();
            Environment.Exit(1);
        }
    }
}
