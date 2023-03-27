using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class CameraPlayerFollow : MonoBehaviour
{
    [SerializeField] Vector3 offset;

    private void Awake()
    {
        SteamUserStats.SetAchievement("cameraControlled");
    }

    private void LateUpdate()
    {
        transform.position = PlayerController.Instance.transform.position + offset;
    }
}
