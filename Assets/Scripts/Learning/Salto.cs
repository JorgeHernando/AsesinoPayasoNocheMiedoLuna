using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{

    Rigidbody2D rb2d;
    public float saltoDistancia;
    private float direction;
    public float speed;
    private bool enElaire;
    #region ModoPro
    RaycastHit2D hit;
    public Vector3 v3;
    public LayerMask layer;
    public float distance;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        

        
    }

    // Update is called once per frame
    void Update()
    {
        Detector_Plataforma();
        //enElaire = bola.gameObject.GetComponent<AnalizarSuelo>().suelo;
        if (Input.GetKeyDown("space") && enElaire == true)
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

    bool CheckCollision
    {
        get
        {
            hit = Physics2D.Raycast(transform.position + v3, transform.up * -1, distance, layer);
            return hit.collider != null;
        }
    }
    
    public void Detector_Plataforma()
    {
        if (CheckCollision)
        {
            transform.parent = hit.collider.transform;
        }
        else
        {
            transform.parent = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position + v3, transform.up * -1 * distance);
    }




}
