using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComboAttackState : PlayerAttackState
{
    private bool alreadyAppliedCombo; // 이미 공격이 진행되었는지
    private bool alreadyAppliyForce;

    PlayerAttackInfoData attackInfoData;

    public PlayerComboAttackState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.ComboAttackParameterHash);

        // 처음 상태에 들어오면 초기화
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

        //  콤보가 진행되지 않고 있다면 초기화
        if (!alreadyAppliedCombo) { stateMachine.ComboIndex = 0; }
    }

    public override void Update()
    {
        base.Update();

        float normalizedTime = GetNormalizedTime(stateMachine.Player.animator, "Attack");
        if (normalizedTime < 1f) // 애니메이션이 다 끝나면 1f, 즉 애니메이션이 끝나지 않았다면
        {
            if (normalizedTime >= attackInfoData.ComboTransitionTime) // 콤보 가능시간이 끝났다면
            {
                // 콤보 시도한다
                TryComboAttack();
            }

            if (normalizedTime >= attackInfoData.ForceTransitionTime)
            {
                // 댐핑 시도한다
            }
        }
        else // 애니메이션이 끝났다면
        {
            if (alreadyAppliedCombo) // 콤보가 진행중이라면
            {
                // 다음 콤보 실행
                stateMachine.ComboIndex = attackInfoData.ComboStateIndex;
                stateMachine.ChangeState(stateMachine.ComboAttackState);

            }
            else // 콤보가 진행 다 됐다면
            {
                // 종료
                stateMachine.ChangeState(stateMachine.IdleState);
            }
        }
    }

    void TryComboAttack()
    {
        if (alreadyAppliedCombo) return; // 콤보가 이미 진행 중일 때
        
        if (attackInfoData.ComboStateIndex == -1) return; // 마지막 콤보까지 다 끝났을 때

        if (!stateMachine.isAttacking) return; // 공격을 하고 있을 때

        // 위 경우에 해당되지 않으면
        alreadyAppliedCombo = true;
    }
}
