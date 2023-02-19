using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject body;

    void DestroyThis()
    {
        body.SetActive(false);
    }
}
