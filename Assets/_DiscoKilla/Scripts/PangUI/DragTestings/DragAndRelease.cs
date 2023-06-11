using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndRelease : MonoBehaviour
{
    public float forceMultiplier = 500f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isDragging = false;
    public bool isGrounded = false;
    private Vector2 startPos;
    private Vector2 endPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.1f, groundLayer);
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector2.Distance(mousePos, transform.position) < 1f)
            {
                isDragging = true;
                startPos = mousePos;
                rb.isKinematic = true;
            }
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePos.x, mousePos.y);
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 force = (endPos - startPos) * forceMultiplier;
            rb.isKinematic = false;
            rb.AddForce(force);
            isDragging = false;
        }
    }
}