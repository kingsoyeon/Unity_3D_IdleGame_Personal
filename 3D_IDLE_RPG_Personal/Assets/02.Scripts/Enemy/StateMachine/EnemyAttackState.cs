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
        //if (normalizedTime < 1f) // �ִϸ��̼��� �� ������ 1f, �� �ִϸ��̼��� ������ �ʾҴٸ�
        //{

        //    if (normalizedTime >= stateMachine.Enemy.Data.ForceTransitionTime)
        //    {
        //        // ���� �õ��Ѵ�
        //    }
        //}
        //else // �ִϸ��̼��� �����ٸ�
        //{// ���������� ������ �ִ��� ���� Ȯ�� (�÷��̾ �������� ���)
        // // ������ ChageState���� ���� Ȯ�� �� �ڿ� ������ ��
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
