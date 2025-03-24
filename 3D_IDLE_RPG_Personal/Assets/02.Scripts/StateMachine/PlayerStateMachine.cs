using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    // 플레이어스테이트머신에서 해야할일은..???
    // 데이터를 이용해 상태별로 조작하고 저장하는 역할

    public Player Player { get; }

    public PlayerIdleState IdleState { get; }
    // public PlayerState GroundState { get; }
    public PlayerStateMachine(Player player)
    {
        this.Player = player;

        MovementSpeed = player.Data.GroundData.BaseSpeed;
        RotationDamping = player.Data.GroundData.BaseRotationDamping;

        IdleState = new PlayerIdleState(this);
    }

    

    public float MovementSpeed { get; set; } 

    public float RotationDamping { get; private set; } 

    public float MovementSpeedModifier { get; set; } = 1f;

    
    public float JumpForce { get; set; }

    protected void StartAnimation(int animationHash)
    {

    }
    protected void StopAnimation(int animationHash)
    {

    }

}
