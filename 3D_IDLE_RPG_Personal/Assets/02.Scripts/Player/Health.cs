using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    private int health;

    public event Action OnDie; // 죽었을 때 호출될 액션

    public bool IsDie = false;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (health == 0) return;

        health = Mathf.Max(health-damage, 0);

        // 데미지를 입고 피가 0이 되면 액션 호출
        if (health == 0) // 죽음
        {
            IsDie = true;
            
            OnDie?.Invoke(); 
        }
        Debug.Log(health);
    }


}
