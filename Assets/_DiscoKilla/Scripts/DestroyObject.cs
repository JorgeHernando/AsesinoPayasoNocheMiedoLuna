using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private AudioSource deathSFX;

    private void Awake()
    {
        deathSFX = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ObjetoDestruible"))
        {
            //deathSFX.Play();
            Destroy(collision.gameObject);
        }
    }
}
