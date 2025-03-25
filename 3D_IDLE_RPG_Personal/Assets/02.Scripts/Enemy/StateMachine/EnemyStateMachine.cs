using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    public Enemy Enemy { get; }

    public float MovementSpeed { get; set; }

    public float RotationDamping { get; private set; }

    public float MovementSpeedModifier { get; set; } = 1f;


    public Health target { get; private set; } // enemy의 target = 플레이어
    public EnemyIdleState IdleState { get; }
    public EnemyChaseState ChaseState { get;  }

    public EnemyAttackState AttackState { get; }

    public EnemyStateMachine(Enemy enemy)
    {
        this.Enemy = enemy;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();

        ChaseState = new EnemyChaseState(this);
       AttackState = new EnemyAttackState(this);
        IdleState = new EnemyIdleState(this);

        MovementSpeed = Enemy.Data.GroundData.BaseSpeed;
        RotationDamping = Enemy.Data.GroundData.BaseRotationDamping;
    }
}
