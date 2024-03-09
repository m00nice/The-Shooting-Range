using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInputs : MonoBehaviour
{
    
    [SerializeField] private Player player;
    [SerializeField] private TPS_Camera tpsCam;
    [SerializeField] private FPS_Camera fpsCam;
    private InputSystem inputSystem;
    
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start()
    {
        inputSystem.Player.Jump.performed += OnJumpPerformed;
        inputSystem.Player.Shoot.performed += OnShootPerformed;
    }

    private void FixedUpdate()
    {
        player.Move(inputSystem.Player.Movement.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        inputSystem = new InputSystem();
        inputSystem.Enable();
    }

    private void OnDisable()
    {
        inputSystem.Disable();
    }
    
    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        player.Jump();
    }

    private void OnShootPerformed(InputAction.CallbackContext context)
    {
        player.ShootGun();
    }

}
