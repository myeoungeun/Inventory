using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject();
                _instance = obj.AddComponent<T>();
            }
            return _instance;
        }
    }
    
    protected virtual void Awake()
    {
        if (_instance == null) // 생성을안해도 어느 씬이든 사용할수있게끔 
        {
            if (transform.parent == null)
            {
                DontDestroyOnLoad(gameObject);
                
            }
            _instance = GetComponent<T>();
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
