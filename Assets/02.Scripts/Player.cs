using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int attack;
    public int shield;
    public int hp;
    public int critical;

    void Awake()
    {
        Singleton.Player = this;
    }
}
