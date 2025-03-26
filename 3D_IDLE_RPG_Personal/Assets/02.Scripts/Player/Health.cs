using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    private int health;

    public event Action OnDie; // �׾��� �� ȣ��� �׼�

    public bool IsDie = false;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (health == 0) return;

        health = Mathf.Max(health-damage, 0);

        // �������� �԰� �ǰ� 0�� �Ǹ� �׼� ȣ��
        if (health == 0) // ����
        {
            IsDie = true;
            
            OnDie?.Invoke(); 
        }
        Debug.Log(health);
    }


}
