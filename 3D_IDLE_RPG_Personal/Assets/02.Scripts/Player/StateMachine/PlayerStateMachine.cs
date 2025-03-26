using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    // �÷��̾����Ʈ�ӽſ��� �ؾ�������..???
    // �����͸� �̿��� ���º��� �����ϰ� �����ϴ� ����

    public Player Player { get; }
    public Health Target { get; private set; }
    public float MovementSpeed { get; set; }

    public float RotationDamping { get; private set; }

    public float MovementSpeedModifier { get; set; } = 1f;


    public float JumpForce { get; set; }

    public bool isAttacking { get; set; }
    public int ComboIndex { get; set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerWalkState WalkState { get; private set; }

    public PlayerRunState RunState { get; private set; }

    public PlayerComboAttackState ComboAttackState { get; private set; }
    
    
    public PlayerStateMachine(Player player)
    {
        this.Player = player;
        

        MovementSpeed = player.Data.GroundData.BaseSpeed;
        RotationDamping = player.Data.GroundData.BaseRotationDamping;
        // Target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Health>();
        //Target = 
        EnemyRespawnManager.Instance.OnEnemySpawn += SetTarget;
        IdleState = new PlayerIdleState(this);
        WalkState = new PlayerWalkState(this);
        RunState = new PlayerRunState(this);

        ComboAttackState = new PlayerComboAttackState(this);
    }

    // Ÿ�� ����
    public void SetTarget(Health enemy)
    {
        Target = enemy;
    }


    // �̺�Ʈ ���� ����
    public void OnDestroy()
    {
        EnemyRespawnManager.Instance.OnEnemySpawn -= SetTarget;
    }

    protected void StartAnimation(int animationHash)
    {

    }
    protected void StopAnimation(int animationHash)
    {

    }

}
