using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    private int health;

    public event Action<int, int> OnHealthChange; // ü�� ��ȭ�� �� ȣ��� �׼�
    public event Action OnDie; // �׾��� �� ȣ��� �׼�

    public bool IsDie = false;

    

    void Start()
    {
        InitialHealth();
    
    }

    public void TakeDamage(int damage)
    {
        if (health == 0) return;

        health = Mathf.Max(health-damage, 0);

        // ü�� ��ȭ �׼� ȣ��
        OnHealthChange?.Invoke(health, maxHealth);

        // �������� �԰� �ǰ� 0�� �Ǹ� �׼� ȣ��
        if (health == 0) // ����
        {
            IsDie = true;
            
            OnDie?.Invoke();
        }
    }

    // ü��, isDie �ʱ�ȭ �޼���
    public void InitialHealth()
    {
        health = maxHealth;
        IsDie = false;
    }
}
