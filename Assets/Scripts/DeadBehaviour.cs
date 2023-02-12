using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;

    public bool canBeDrag;
    Vector3 playerPosition;
    [SerializeField]
    private float dragSpeed = 5f;

    private void Start()
    {
        //canBeDrag = false;
    }
    private void FixedUpdate()
    {
        if (canBeDrag)
        {
            Vector2 playerDirection = (playerPosition - transform.position).normalized;
            rb.velocity = new Vector2(playerDirection.x, playerDirection.y) * dragSpeed;
        }
    }

    public void SetTarget(Vector3 position)
    {
        playerPosition = position;
        canBeDrag = true;
    }
}
