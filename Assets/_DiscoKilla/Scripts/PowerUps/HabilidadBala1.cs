using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadBala1 : MonoBehaviour
{
    public static event Action OnPowerPickup;

    private int PowerUpTimer = 2;
    private SpriteRenderer sprite;
    private AudioSource SFXPowers;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        SFXPowers = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MoveAndShoot>())
        {
            Debug.Log("PowerBala");
            sprite.enabled = false;
            OnPowerPickup?.Invoke();
            StartCoroutine(PowerUpSequence(collision.gameObject.GetComponent<MoveAndShoot>()));
        }
    }
    public IEnumerator PowerUpSequence(MoveAndShoot player)
    {
        SFXPowers.Play();
        ActivatePowerUp(player);
        yield return new WaitForSeconds(PowerUpTimer);
        DeactivatePowerUp(player);
        Destroy(gameObject);

    }

    private void ActivatePowerUp(MoveAndShoot player)
    {
       player.isBulletPowered = true;
    }
    private void DeactivatePowerUp(MoveAndShoot player)
    {
        player.isBulletPowered = false;
    }
}
