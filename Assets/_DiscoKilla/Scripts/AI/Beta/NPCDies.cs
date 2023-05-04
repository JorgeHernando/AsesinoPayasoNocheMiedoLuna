using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDies : MonoBehaviour
{
    [SerializeField]
    private GameObject DeadBodyPrefab;
    private Cinemachine.CinemachineImpulseSource _cameraShake;

    private void Start()
    {
        _cameraShake = GetComponent<Cinemachine.CinemachineImpulseSource>();
    }

    public void KillNPC()
    {
        _cameraShake.GenerateImpulse();
        Instantiate(DeadBodyPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
