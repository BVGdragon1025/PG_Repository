using GooglePlayGames.BasicApi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoogleManager : MonoBehaviour
{
#if UNITY_ANDROID
    private void Awake()
    {
        GooglePlayGames.PlayGamesPlatform.Activate();
        Social.localUser.Authenticate(status =>
        {
            Debug.Log($"Authntication status: {status}");
        });
    }

    internal bool ProcessAuthentication(SignInStatus status)
    {
        if(status == SignInStatus.Success)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

#endif
}
