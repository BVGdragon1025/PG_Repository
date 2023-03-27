using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlatformServices;

public class CameraPlayerFollow : MonoBehaviour
{
    [SerializeField] Vector3 offset;

    private void Awake()
    {
        UserStats.SetAchievement("cameraControlled");
    }


    private void LateUpdate()
    {
        transform.position = PlayerController.Instance.transform.position + offset;
    }
}
