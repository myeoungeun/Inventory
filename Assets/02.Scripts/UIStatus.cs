using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIStatus : MonoBehaviour
{
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI shieldText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI criticalText;
    void Awake()
    {
    }

    void Start()
    {
        if (Singleton.Player != null)
        {
            attackText.text = Singleton.Player.attack.ToString();
            shieldText.text = Singleton.Player.shield.ToString();
            hpText.text = Singleton.Player.hp.ToString();
            criticalText.text = Singleton.Player.critical.ToString();
        }
    }
}
