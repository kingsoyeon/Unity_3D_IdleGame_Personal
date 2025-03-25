using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIInventory : MonoBehaviour, IUI
{
    void Start()
    {
        
    }
    public void Hide() // ´Ý±â
    {

        gameObject.SetActive(true);
    }

    public void Show() // ¿­±â
    {

        gameObject.SetActive(false);
    }

    public void Toggle() // ¿­°í ´Ý±â
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
    
}
