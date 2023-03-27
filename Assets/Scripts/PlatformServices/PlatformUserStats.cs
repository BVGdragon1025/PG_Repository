using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformServices
{
    public static class UserStats
    {
        static IPlatformUserStats _platform;

        [RuntimeInitializeOnLoadMethod]
        public static void Initialize()
        {
#if !DISABLESTEAMWORKS
            _platform = new SteamUserStats();
            return;
#endif

#if UNITY_ANDROID
            _platform = new AndroidUserStats();
            return;
#endif
        }

        public static bool SetAchievement(string achievementId)
        {
            Debug.Log($"Achievement: {achievementId}");
            return _platform.SetAchievement(achievementId);
        }
    }

    public interface IPlatformUserStats
    {
        public bool SetAchievement(string achievementId);
    }

#if !DISABLESTEAMWORKS
    public class SteamUserStats : IPlatformUserStats
    {
        public bool SetAchievement(string achievementId)
        {
            return Steamworks.SteamUserStats.SetAchievement(achievementId);
        }
    }

#endif

#if UNITY_ANDROID
    public class AndroidUserStats : IPlatformUserStats
    {
        public bool SetAchievement(string achievementId)
        {
            throw new NotImplementedException();
        }
    }

#endif

}

