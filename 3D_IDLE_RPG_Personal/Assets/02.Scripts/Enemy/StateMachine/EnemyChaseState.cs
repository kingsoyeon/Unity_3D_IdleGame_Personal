using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player walk state�� Ȱ���Ѵ�

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

        //  // ���� �������� ����ٸ�
        if (!isInChasingRange())
        {
            // idle state�� ����
            stateMachine.ChangeState(stateMachine.IdleState);
            return;
        }
        // ���� ���� �ȿ� ���´ٸ�
        else if (isInAttackRange())
        {
            // attack state�� ����
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
