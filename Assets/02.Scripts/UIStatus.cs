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

    void Start()
    {
        if (Player.Instance != null)
        {
            attackText.text = Player.Instance.attack.ToString();
            shieldText.text = Player.Instance.shield.ToString();
            hpText.text = Player.Instance.hp.ToString();
            criticalText.text = Player.Instance.critical.ToString();
        }
    }
}
