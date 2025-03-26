using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IPoolable
{

    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }
    [field: SerializeField] public EnemySO Data { get; private set; }

    [field: SerializeField] public Weapon Weapon { get; private set; }

    public Health health;
    public CharacterController CharacterController { get; private set; }

    private EnemyStateMachine stateMachine;

    public Animator animator;

    private Action<GameObject> returnToPool;

    private void Awake()
    {
        AnimationData.Initialize();
        CharacterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        health = GetComponent<Health>();
        stateMachine = new EnemyStateMachine(this);
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        stateMachine.ChangeState(stateMachine.IdleState);

        health.OnDie += OnDie;
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

    void OnDie()
    {
        animator.SetTrigger("Die"); // Die 이름을 가진 애니메이션 실행
        OnDespawn();
        enabled = false;
    }

    public void Initialize(Action<GameObject> returnAction)
    {
        returnToPool = returnAction;
    }

    public void OnSpawn()
    {
        enabled = true;

        health.InitialHealth();
        stateMachine.ChangeState(stateMachine.IdleState);
        
    }

    public void OnDespawn()
    {
        returnToPool?.Invoke(gameObject);
    }
}
