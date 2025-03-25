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

    public Health health;

    public PlayerController input;
    public Animator animator;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    
    private void Awake()
    {
       
        animator = GetComponentInChildren<Animator>();
        CharacterController = GetComponent<CharacterController>();
        health = GetComponent<Health>();

        input = GetComponent<PlayerController>();

        AnimationData.Initialize();
        
        health.OnDie += OnDie; // health의 OnDie 액션에 메서드 추가


        stateMachine = new PlayerStateMachine(this);
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

    void OnDie()
    {
        animator.SetTrigger("Die"); // Die 이름을 가진 애니메이션 실행
    }
}
