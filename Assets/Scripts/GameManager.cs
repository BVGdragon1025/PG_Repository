using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class GameManager : MonoBehaviour
{

    private void Awake()
    {
        SteamUserStats.SetAchievement("welcomeAchievement");
    }
}
