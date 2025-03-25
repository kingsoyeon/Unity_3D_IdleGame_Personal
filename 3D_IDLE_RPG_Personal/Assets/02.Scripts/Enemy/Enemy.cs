using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }
    [field: SerializeField] public EnemySO Data { get; private set; }

    public CharacterController CharacterController { get; private set; }

    private EnemyStateMachine stateMachine;

    public Animator animator;

    private void Awake()
    {
        AnimationData.Initialize();
        CharacterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();    
        stateMachine = new EnemyStateMachine(this);
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        stateMachine.ChangeState(stateMachine.IdleState);
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
