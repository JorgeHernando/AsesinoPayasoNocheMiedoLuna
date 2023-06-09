using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 offset;
    private Rigidbody2D rb;
    private Vector3 mousePos;
    private float mouseX;
    private float mouseY;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        if (dragging)
        {
            // Move object, taking into account original offset.
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint (Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp()
    {
        // Stop dragging.
        rb.AddForce(new Vector2(4f, 10f), ForceMode2D.Impulse);
        rb.velocity = offset * new Vector2(4f, 10f) * 5;
        dragging = false;
    }
}
