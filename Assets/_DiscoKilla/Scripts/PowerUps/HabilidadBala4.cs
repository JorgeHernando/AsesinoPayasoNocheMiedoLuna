using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadBala4 : MonoBehaviour
{
    private int PowerUpTimer = 3;
    private SpriteRenderer sprite;
    private bool hasActivated;
    private void Start()
    {
        hasActivated = false;
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MoveAndShoot>())
        {
            Debug.Log("SpeedyBoost");
            sprite.enabled = false;
            StartCoroutine(PowerUpSequence(collision.gameObject.GetComponent<MoveAndShoot>()));
        }
    }
    public IEnumerator PowerUpSequence(MoveAndShoot player)
    {
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
