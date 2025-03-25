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
    public void Hide() // �ݱ�
    {

        gameObject.SetActive(true);
    }

    public void Show() // ����
    {

        gameObject.SetActive(false);
    }

    public void Toggle() // ���� �ݱ�
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
    
}
