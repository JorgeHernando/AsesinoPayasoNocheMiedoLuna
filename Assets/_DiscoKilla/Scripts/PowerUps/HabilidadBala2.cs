using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadBala2 : MonoBehaviour
{
    private int PowerUpTimer = 4;
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MoveAndShoot>())
        {
            Debug.Log("PowerBala");
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
        player.canDie = false;
    }
    private void DeactivatePowerUp(MoveAndShoot player)
    {
        player.canDie = true;
    }
}
