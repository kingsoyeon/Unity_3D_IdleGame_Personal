using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComboAttackState : PlayerAttackState
{
    private bool alreadyAppliedCombo; // �̹� ������ ����Ǿ�����
    private bool alreadyAppliyForce;

    PlayerAttackInfoData attackInfoData;

    public PlayerComboAttackState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.ComboAttackParameterHash);

        // ó�� ���¿� ������ �ʱ�ȭ
        alreadyAppliedCombo = false;
        alreadyAppliyForce = false;

        int comboindex = stateMachine.ComboIndex;
        attackInfoData = stateMachine.Player.Data.AttackData.GetAttackInfoData(comboindex);
        stateMachine.Player.animator.SetInteger("Combo", comboindex);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.ComboAttackParameterHash);

        //  �޺��� ������� �ʰ� �ִٸ� �ʱ�ȭ
        if (!alreadyAppliedCombo) { stateMachine.ComboIndex = 0; }
    }

    public override void Update()
    {
        base.Update();

        float normalizedTime = GetNormalizedTime(stateMachine.Player.animator, "Attack");
        if (normalizedTime < 1f) // �ִϸ��̼��� �� ������ 1f, �� �ִϸ��̼��� ������ �ʾҴٸ�
        {
            if (normalizedTime >= attackInfoData.ComboTransitionTime) // �޺� ���ɽð��� �����ٸ�
            {
                // �޺� �õ��Ѵ�
                TryComboAttack();
            }

            if (normalizedTime >= attackInfoData.ForceTransitionTime)
            {
                // ���� �õ��Ѵ�
            }
        }
        else // �ִϸ��̼��� �����ٸ�
        {
            if (alreadyAppliedCombo) // �޺��� �������̶��
            {
                // ���� �޺� ����
                stateMachine.ComboIndex = attackInfoData.ComboStateIndex;
                stateMachine.ChangeState(stateMachine.ComboAttackState);

            }
            else // �޺��� ���� �� �ƴٸ�
            {
                // ����
                stateMachine.ChangeState(stateMachine.IdleState);
            }
        }
    }

    void TryComboAttack()
    {
        if (alreadyAppliedCombo) return; // �޺��� �̹� ���� ���� ��
        
        if (attackInfoData.ComboStateIndex == -1) return; // ������ �޺����� �� ������ ��

        if (!stateMachine.isAttacking) return; // ������ �ϰ� ���� ��

        // �� ��쿡 �ش���� ������
        alreadyAppliedCombo = true;
    }
}
