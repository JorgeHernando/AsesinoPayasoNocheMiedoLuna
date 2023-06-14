using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HabilidadBala4 : MonoBehaviour
{
    public static event Action OnPowerPickup;

    private int PowerUpTimer = 3;
    private SpriteRenderer sprite;
    private bool hasActivated;
    private AudioSource SFXPowers;
    private void Start()
    {
        hasActivated = false;
        sprite = GetComponent<SpriteRenderer>();
        SFXPowers = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MoveAndShoot>())
        {
            Debug.Log("SpeedyBoost");
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
        if (hasActivated == false)
        {
            player.speed = player.speed * 2;
            hasActivated = true;
        }
    }
    private void DeactivatePowerUp(MoveAndShoot player)
    {
        player.speed = player.speed / 2;
    }
}
