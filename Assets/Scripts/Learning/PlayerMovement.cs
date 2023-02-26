using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //int = cuando quieres hacer una acción sin ser preciso
    //float = cuando quieres hacer una acción precisa
    //public class = es cuando quieres que algo sea accesible desde otros sitios / una variable general
    //bool = Algo que puede ser verdadero o falso
    int vida;
    bool estaVivo;
    Rigidbody2D rb2D;
    SpriteRenderer sprite;

    Vector2 moveInput;
    public GameObject PantallaMuerte;

    // Es Donde Se Da Un Contenido En Específico A Cada Variable Global
    void Start()
    {
        estaVivo = true;
        vida = 1;
        rb2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Memoriza para moverse en 2D básico
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            rb2D.velocity = moveInput * 3;
        if (Input.GetKey(KeyCode.W))
            rb2D.velocity = moveInput * 3;

        ChequearVida();
    }

    void ChequearVida()
    {
        if (estaVivo == true)
        {
            Debug.Log("Vivo" + vida);
        }
        else
            PantallaMuerte.SetActive(true);
    }

    void QuitarVida()
    {
        vida = vida - 1;
        if (vida == 0)
        // Debug.Log("") Es Un Comentario Para El Programador
        {
            estaVivo = false;
            Debug.Log("GameOver");
        }
    }

    void DaVida()
    {
        vida = vida + 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            QuitarVida();
        }

        if (collision.gameObject.CompareTag("Potion"))
        {
            DaVida();
        }
    }
}
