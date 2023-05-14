using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Slime : MonoBehaviour
{
    public static event Action OnSlimeDeath;

    public void DestroyMe()
    {
        Debug.Log("Patata");
        OnSlimeDeath?.Invoke();
        Destroy(gameObject);
    }
}
