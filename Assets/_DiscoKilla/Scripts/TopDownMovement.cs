using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public enum States
    {
        Normal,
        Caught
    };

    public States states;

    public float moveSpeed;
    private Rigidbody2D rb2d;
    private Vector2 moveInput;
    
    [SerializeField]
    private int RunMultiplier;

    private bool canKill;
    private bool isKilling;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        canKill = false;
        states = States.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb2d.velocity = moveInput * RunMultiplier;
        }
        else
            rb2d.velocity = moveInput * moveSpeed;

        if (Input.GetMouseButtonDown(0) && canKill)
        {
            Debug.Log("Lo matas");
            isKilling = true;
        }
        else if (Input.GetMouseButtonDown(0))
            Debug.Log("No lo puedes matar");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPCAlive") && isKilling)
        {
            collision.gameObject.GetComponent<NPCBehaviour>().KillNPC();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("NPCAlive"))
        {
            Debug.Log("Puede matar");
            canKill = true;
            //other.gameObject.GetComponent<NPCBehaviour>().Death();
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPCAlive"))
        {
            Debug.Log("No puede matar");
            canKill = false;
            isKilling = false;
        }
    }

    public void ToggleStateScared()
    {
        if (states == States.Normal)
        {
            states = States.Caught;
        }
    }

    public void ToggleStateNormal()
    {
        if (states == States.Caught)
        {
            states = States.Normal;
        }
    }
}
