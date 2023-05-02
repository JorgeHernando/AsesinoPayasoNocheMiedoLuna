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

    public float collOffset = 0.02f;
    public ContactFilter2D cF;
    public List<RaycastHit2D> cColl = new List<RaycastHit2D>();

    [SerializeField]
    private int RunMultiplier;

    private bool canKill;
    private bool isKilling;

    private Animator animator;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        canKill = false;
        states = States.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        if (moveInput != Vector2.zero)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb2d.velocity = moveInput * RunMultiplier;
            }
            else
            {
                //rb2d.velocity = moveInput * moveSpeed;
                animator.SetFloat("movementX", moveInput.x);
                animator.SetFloat("movementY", moveInput.y);
                animator.SetBool("isMoving", true);
                bool success = TryMove(moveInput);

                if (!success)
                {
                    success = TryMove(new Vector2(moveInput.x, 0));

                    if (!success) success = TryMove(new Vector2(0, moveInput.y));
                }

            }
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if (Input.GetMouseButtonDown(0) && canKill)
        {
            Debug.Log("Lo matas");
            isKilling = true;
        }
        else if (Input.GetMouseButtonDown(0))
            Debug.Log("No lo puedes matar");
    }

    private bool TryMove(Vector2 direction)
    {
        int count = rb2d.Cast(
               direction,
               cF,
               cColl,
               moveSpeed * Time.deltaTime + collOffset);

        if (count == 0)
        {
            rb2d.MovePosition(rb2d.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        }
        else return false;
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
