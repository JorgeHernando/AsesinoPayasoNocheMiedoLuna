using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float saltoDistancia;
    private float direction;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log(saltoDistancia);
            rb2d.AddForce(Vector2.up * saltoDistancia, ForceMode2D.Impulse);
        }


        direction = Input.GetAxis("Horizontal");
        if (direction > 0)
        {
            rb2d.velocity =new Vector2(direction*speed, rb2d.velocity.y);
        }

        if (direction < 0)
        {
            rb2d.velocity = new Vector2(direction * speed, rb2d.velocity.y);
        }
    }


}
