using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalizarSuelo : MonoBehaviour
{
    public bool suelo;
    private void Start()
    {
        suelo = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            suelo = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            suelo = false;
        }
    }
}
