using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public EnemyAttackState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Enemy.AnimationData.AttackParameterHash);
        StartAnimation(stateMachine.Enemy.AnimationData.BaseAttackParameterHash);

    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Enemy.AnimationData.AttackParameterHash);
        StartAnimation(stateMachine.Enemy.AnimationData.BaseAttackParameterHash);
    }

    public override void Update()
    {
        base.Update();
        stateMachine.Enemy.Weapon.SetAttack(stateMachine.Enemy.Data.Damage);

        //float normalizedTime = GetNormalizedTime(stateMachine.Enemy.animator, "Attack");
        //if (normalizedTime < 1f) // 애니메이션이 다 끝나면 1f, 즉 애니메이션이 끝나지 않았다면
        //{

        //    if (normalizedTime >= stateMachine.Enemy.Data.ForceTransitionTime)
        //    {
        //        // 댐핑 시도한다
        //    }
        //}
        //else // 애니메이션이 끝났다면
        //{// 추적가능한 범위에 있는지 먼저 확인 (플레이어가 도망가는 경우)
        // // 공격은 ChageState에서 범위 확인 한 뒤에 구현될 것
        //    if (isInChasingRange())
        //    {
        //        stateMachine.ChangeState(stateMachine.ChaseState);
        //        return;
        //    }
        //    else
        //    {
        //        stateMachine.ChangeState(stateMachine.IdleState);
        //    }
        //}
    }
}
