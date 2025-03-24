using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    [field:SerializeField] public PlayerAnimationData AnimationData { get; private set; }
    [field:SerializeField] public PlayerSO Data { get; private set; }

    public CharacterController CharacterController { get; private set; }

    private PlayerStateMachine stateMachine;

    public PlayerController input;
    public Animator animator;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    
    private void Awake()
    {
        stateMachine = new PlayerStateMachine(this);

        AnimationData.Initialize();

        CharacterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        input = GetComponent<PlayerController>();
    }

    private void Update()
    {
        stateMachine.Update();
        stateMachine.HandleInput();
    }
    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }


}
