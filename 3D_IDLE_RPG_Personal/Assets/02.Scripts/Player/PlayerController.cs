using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInputs playerInput { get; private set; }
    public PlayerInputs.PlayerActions playerActions { get; private set; }

    private void Awake()
    {
        playerInput = new PlayerInputs();
        playerActions = playerInput.Player;
        
    }

    void OnEnable()
    {
        playerInput.Enable();
        playerActions.Inventory.started += OnInventory;
    }

    void OnDisable()
    {
        playerInput.Disable();
        playerActions.Inventory.started -= OnInventory;
    }

    private void OnInventory(InputAction.CallbackContext context)
    {
        UIManager.Instance.ToggleUI(1);
        
    }
}
