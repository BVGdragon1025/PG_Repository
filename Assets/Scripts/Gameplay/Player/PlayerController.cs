using RoboRyanTron.Unite2017.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] private FloatVariable HealthVariable;
    [SerializeField] private FloatVariable ManaVariable;
    [SerializeField] private FloatVariable StaminaVariable;

    private CharacterController characterController;

    [Header("Movmeent Settings")]
    [SerializeField] private float velocity = 5;
    [SerializeField] private float sprintModificator = 3;
    [SerializeField] private float staminaUse = 0.5f;
    [SerializeField] private LayerMask layerMask;

    [Header("Skill Settings")]
    [SerializeField] SkillSO JumpSkill;
    [SerializeField] SkillSO SprintSkill;

    private float _yMovement = -9.81f;

    [Header("Input System Settings")]
    [SerializeField] private InputActionAsset _actionAsset;
    [SerializeField] private InputActionReference _movementReference;
    [SerializeField] private InputActionReference _sprintReference;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("There is more than one instance of this!", gameObject);
        
        Instance = this;
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        _actionAsset.Enable();
    }

    private void OnDisable()
    {
        _actionAsset.Disable();
    }

    private void Update()
    {
        var movementValue = _movementReference.action.ReadValue<Vector2>();

        if (SprintSkill.IsActive && _sprintReference.action.ReadValue<float>() > 0 && StaminaVariable.Value > 0)
        {
            movementValue *= sprintModificator;
            StaminaVariable.Value -= staminaUse * Time.deltaTime;
        }
        else
        {
            StaminaVariable.Value += Time.fixedDeltaTime;
            StaminaVariable.Value = Mathf.Clamp01(StaminaVariable.Value);
        }

        movementValue *= velocity;
        movementValue *= Time.deltaTime;

        characterController.Move(new Vector3(movementValue.x, _yMovement * Time.deltaTime, movementValue.y));
        if (characterController.velocity.sqrMagnitude > 0.1)
            transform.forward = new Vector3(movementValue.x, 0f, movementValue.y);

        _yMovement = Mathf.Max(-9.81f, _yMovement - Time.deltaTime * 30f);

    }

    public void Jump()
    {
        if (JumpSkill.IsActive && characterController.isGrounded)
            _yMovement = 10f;
    }

}
