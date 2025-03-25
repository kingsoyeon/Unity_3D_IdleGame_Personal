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
        stateMachine = playerStateMachine; // 현재 플레이어 상태에 대한 정보를 얻고, 상태를 바꾸는 기능을 쉽게 사용하기 위함
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

            // attack state로 변경
            stateMachine.ChangeState(stateMachine.ComboAttackState);
            return;
        }
    }

    protected bool isInAttackRange()
    {
        if (stateMachine.Target.IsDie) return false; // 죽으면 그만 공격

        float enemyDistanceSqr = (stateMachine.Target.transform.position  - stateMachine.Player.transform.position).sqrMagnitude;
        return enemyDistanceSqr <= stateMachine.Player.Data.GroundData.AttackRange * stateMachine.Player.Data.GroundData.AttackRange;

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
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0); // 현재 진행 중인 애니메이션 상태
        AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0); // 다음에 진행 예정인 애니메이션 상태
       
        // 애니메이션이 전환 중 && 다음 애니메이션 태그 체크
        if (animator.IsInTransition(0) && nextInfo.IsTag(tag))
        {
            return nextInfo.normalizedTime;
        }
        // 애니메이션이 전환 중 아님 && 현재 애니메이션 태그 체크
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
