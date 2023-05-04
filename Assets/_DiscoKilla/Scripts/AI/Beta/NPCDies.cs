using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDies : MonoBehaviour
{
    [SerializeField]
    private GameObject DeadBodyPrefab;

    public void KillNPC()
    {
        Instantiate(DeadBodyPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
