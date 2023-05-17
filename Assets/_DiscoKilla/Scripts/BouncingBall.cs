using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    public float moveSpeed = 5f; // The speed at which the ball moves
    public float rotationSpeed = 100f; // The speed at which the ball rotates

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Move the ball forward in its current direction
        rb.velocity = transform.up * moveSpeed;

        // Rotate the ball around its center
        rb.AddTorque(rotationSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Bounce off walls and other objects
        Vector2 reflection = Vector2.Reflect(rb.velocity, collision.contacts[0].normal);
        rb.velocity = reflection;
    }
}