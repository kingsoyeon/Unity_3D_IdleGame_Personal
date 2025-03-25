using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : IState
{
    protected PlayerStateMachine stateMachine;
    protected readonly PlayerGroundData groundData;
    protected readonly PlayerAttackData attackData;

    
    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        stateMachine = playerStateMachine; // ���� �÷��̾� ���¿� ���� ������ ���, ���¸� �ٲٴ� ����� ���� ����ϱ� ����
        groundData = stateMachine.Player.Data.GroundData;
        attackData = stateMachine.Player.Data.AttackData;
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

        if (isInAttackRange())
        {

            // attack state�� ����
            stateMachine.ChangeState(stateMachine.ComboAttackState);
            return;
        }
    }

    protected bool isInAttackRange()
    {
        if (stateMachine.Target.IsDie) return false; // ������ �׸� ����

        float enemyDistanceSqr = (stateMachine.Target.transform.position  - stateMachine.Player.transform.position).sqrMagnitude;
        return enemyDistanceSqr <= stateMachine.Player.Data.GroundData.AttackRange * stateMachine.Player.Data.GroundData.AttackRange;

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
        float movementSpeed = GetMovementSpeed();
        stateMachine.Player.CharacterController.Move((movementSpeed * stateMachine.Player.transform.forward) * Time.deltaTime);
    }

    private float GetMovementSpeed()
    {
        float moveSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;
        return moveSpeed;
    }


    protected float GetNormalizedTime(Animator animator, string tag)
    {
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0); // ���� ���� ���� �ִϸ��̼� ����
        AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0); // ������ ���� ������ �ִϸ��̼� ����
       
        // �ִϸ��̼��� ��ȯ �� && ���� �ִϸ��̼� �±� üũ
        if (animator.IsInTransition(0) && nextInfo.IsTag(tag))
        {
            return nextInfo.normalizedTime;
        }
        // �ִϸ��̼��� ��ȯ �� �ƴ� && ���� �ִϸ��̼� �±� üũ
        else if (!animator.IsInTransition(0) && currentInfo.IsTag(tag))
        {
            return currentInfo.normalizedTime;
        }
        else
        {
            return 0f;
        }
    }
}
