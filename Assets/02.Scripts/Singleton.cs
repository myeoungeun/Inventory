using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton _instance;
    private static Player _player; //전역변수처럼 공유되는 값

    public static Singleton Instance
    {
        get;
        private set;
    }

    public static Player Player
    {
        get;
        set;
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
