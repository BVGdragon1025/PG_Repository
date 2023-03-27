using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlatformServices;

public class GameManager : MonoBehaviour
{

    private void Start()
    {
        UserStats.SetAchievement("welcomeAchievement");
    }
}
