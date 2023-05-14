using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairAction : MonoBehaviour
{
    [Header("Climb")]
    [SerializeField] private float climbSpeed;
    private Rigidbody2D rb2D;
    private BoxCollider2D box2D;
    private Animator animator;
    private float initialGravity;
    private bool climbing;

    private Vector2 direction;
    private MoveAndShoot movement;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        box2D = GetComponent<BoxCollider2D>();
        movement = GetComponent<MoveAndShoot>();
        initialGravity = rb2D.gravityScale;
    }
    private void Update()
    {
        direction.y = Input.GetAxisRaw("Vertical");
        /*if(Mathf.Abs(rb2D.velocity.y) > Mathf.Epsilon)
        {
            animator.SetFloat("VelocidadY", Mathf.Sign(rb2D.velocity.y));
        }
        else
        {
            animator.SetFloat("Velocidady", 0);
        }*/
    }

    private void FixedUpdate()
    {
        Climb();
    }

    private void Climb()
    {
        if ((direction.y != 0 || climbing) && (box2D.IsTouchingLayers(LayerMask.GetMask("Stairs"))))
        {
            Vector2 upSpeed = new Vector2(rb2D.velocity.x, direction.y * climbSpeed);
            rb2D.velocity = upSpeed;
            rb2D.gravityScale = 0;
            climbing = true;
        }
        else
        {
            rb2D.gravityScale = initialGravity;
            climbing = false;
        }
        if (movement.CheckCollision)
            climbing = false;
        //animator.SetBool("isClimbing", climbing);
    }

}