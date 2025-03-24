using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : IState
{
    protected PlayerStateMachine stateMachine;
    protected readonly PlayerGroundData groundData;
    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        stateMachine = playerStateMachine; // 현재 플레이어 상태에 대한 정보를 얻고, 상태를 바꾸는 기능을 쉽게 사용하기 위함
        groundData = stateMachine.Player.Data.GroundData;
    }


    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void HandleInput()
    {

    }

    public virtual void PhysicsUpate()
    {
    }

    public virtual void Update()
    {
        Move();
    }

    protected void StartAnimation(int hash)
    {
        // hash에 해당하는 애니메이션 시작
        stateMachine.Player.animator.SetBool(hash, true);
    }

    protected void StopAnimation(int hash)
    {
        // hash에 해당하는 애니메이션 끝
        stateMachine.Player.animator.SetBool(hash, false);
    }

    private void Move()
    {

    }

    private void Rotate()
    {

    }
}
