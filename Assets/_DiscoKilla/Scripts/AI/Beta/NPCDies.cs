using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDies : MonoBehaviour
{
    [SerializeField]
    private GameObject DeadBodyPrefab;
    private Cinemachine.CinemachineImpulseSource _cameraShake;

    public void KillNPC()
    {
        _cameraShake = GetComponent<Cinemachine.CinemachineImpulseSource>();
        Instantiate(DeadBodyPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
