using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 0f; // 속도 초기화
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.IdleParameterHash);
    }

    public override void Exit()
    {

        base.Exit();
        StopAnimation((stateMachine.Player.AnimationData.IdleParameterHash));
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void PhysicsUpate()
    {
        base.PhysicsUpate();    
    }

    public override void Update()
    {
        base.Update();
    }
}
