using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    private int health;

    public event Action<int, int> OnHealthChange; // 체력 변화할 때 호출될 액션
    public event Action OnDie; // 죽었을 때 호출될 액션

    public bool IsDie = false;

    

    void Start()
    {
        InitialHealth();
    
    }

    public void TakeDamage(int damage)
    {
        if (health == 0) return;

        health = Mathf.Max(health-damage, 0);

        // 체력 변화 액션 호출
        OnHealthChange?.Invoke(health, maxHealth);

        // 데미지를 입고 피가 0이 되면 액션 호출
        if (health == 0) // 죽음
        {
            IsDie = true;
            
            OnDie?.Invoke();
        }
    }

    // 체력, isDie 초기화 메서드
    public void InitialHealth()
    {
        health = maxHealth;
        IsDie = false;
    }
}
