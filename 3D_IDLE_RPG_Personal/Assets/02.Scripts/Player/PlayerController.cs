using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInputs playerInput { get; private set; }
    public PlayerInputs.PlayerActions playerActions { get; private set; }

    void Awake()
    {
        playerInput = new PlayerInputs();
        playerActions = playerInput.Player;
    }

    void OnEnable()
    {
        playerInput.Enable();
    }

    void OnDisable()
    {
        playerInput.Disable();
    }
}
