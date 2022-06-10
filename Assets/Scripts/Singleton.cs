using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T: Singleton<T>
{
    private static volatile T instance = null;

    public static T Instance { get { return instance; } }
    
    private void Awake()
    {
        if (instance != null && instance != FindObjectOfType(typeof(T)) as T)
        {
            Destroy((FindObjectOfType(typeof(T)) as T).gameObject);
        }
        else
        {
            instance = FindObjectOfType(typeof(T)) as T;
        }
    }
}
