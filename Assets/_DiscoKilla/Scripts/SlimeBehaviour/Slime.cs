using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Slime : MonoBehaviour
{
    public static event Action OnSlimeDeath;

    public void DestroyMe()
    {
        OnSlimeDeath?.Invoke();
        Destroy(gameObject);
    }
}
