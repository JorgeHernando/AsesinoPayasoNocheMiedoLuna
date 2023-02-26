using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour
{
    Vector2 movement;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movement = new Vector2(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = movement * 2;
    }
}
