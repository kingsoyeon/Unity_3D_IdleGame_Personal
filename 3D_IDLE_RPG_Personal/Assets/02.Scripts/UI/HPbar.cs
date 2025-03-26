using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour//IPoolable
{
    //public Health Health;
    //[SerializeField] private Image hpBar;

    public void Initialize(Action<GameObject> returnAction)
    {

    }

    //public void OnDespawn()
    //{
    //    Health.OnHealthChange -= UpdateHPBar;
    //}

    //public void OnSpawn()
    //{
    //    Health.OnHealthChange += UpdateHPBar;
    //}

    //void UpdateHPBar(int health, int maxHealth)
    //{
    //    hpBar.fillAmount = (float)health / maxHealth;
    //}
}
