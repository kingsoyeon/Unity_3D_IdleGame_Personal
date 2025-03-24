using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : IState
{
    protected PlayerStateMachine stateMachine;
    protected readonly PlayerGroundData groundData;
    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        stateMachine = playerStateMachine; // ���� �÷��̾� ���¿� ���� ������ ���, ���¸� �ٲٴ� ����� ���� ����ϱ� ����
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
        // hash�� �ش��ϴ� �ִϸ��̼� ����
        stateMachine.Player.animator.SetBool(hash, true);
    }

    protected void StopAnimation(int hash)
    {
        // hash�� �ش��ϴ� �ִϸ��̼� ��
        stateMachine.Player.animator.SetBool(hash, false);
    }

    private void Move()
    {

    }

    private void Rotate()
    {

    }
}
