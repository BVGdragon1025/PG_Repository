using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private DefaultControlls _controlls;

    private void Awake()
    {
        _controlls = new DefaultControlls();
    }

    private void OnEnable()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        PlayerController controller = player.GetComponent<PlayerController>();

        _controlls.Player.Jump.performed += movementContext => controller.Jump();

        _controlls.Player.Enable();
    }

    private void OnDisable()
    {
        _controlls.Player.Disable();
    }
}
