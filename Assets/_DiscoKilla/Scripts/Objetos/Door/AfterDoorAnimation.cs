using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterDoorAnimation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer toDeactivate;
    [SerializeField] private SpriteRenderer toActivate;
    private bool isActive;

    private void Start()
    {
        isActive = false;
    }

    public void ActivateFinalDoor()
    {
        if (!isActive)
        {
            toDeactivate.enabled = false;
            toActivate.enabled = true;
        }
        else
        {
            toDeactivate.enabled = true;
            toActivate.enabled = false;
        }
    }
}