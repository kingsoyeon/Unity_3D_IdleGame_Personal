using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player walk state를 활용한다

public class EnemyChaseState : EnemyBaseState
{ 
    public EnemyChaseState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = groundData.WalkSpeedModifier;
        base.Enter();
        StartAnimation(stateMachine.Enemy.AnimationData.GroundParameterHash);
        StartAnimation(stateMachine.Enemy.AnimationData.WalkParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Enemy.AnimationData.GroundParameterHash);
        StopAnimation(stateMachine.Enemy.AnimationData.WalkParameterHash);
    }
    public override void Update()
    {
       
        base.Update();

        //  // 추적 범위에서 벗어난다면
        if (!isInChasingRange())
        {
            // idle state로 변경
            stateMachine.ChangeState(stateMachine.IdleState);
            return;
        }
        // 공격 범위 안에 들어온다면
        else if (isInAttackRange())
        {
            // attack state로 변경
            stateMachine.ChangeState(stateMachine.AttackState);
            return;
        }
    }

    protected bool isInAttackRange()
    {
      
        float playerDistanceSqr = (stateMachine.target.transform.position - stateMachine.Enemy.transform.position).sqrMagnitude;
        return playerDistanceSqr <= stateMachine.Enemy.Data.AttackRange * stateMachine.Enemy.Data.AttackRange;
    }
}
