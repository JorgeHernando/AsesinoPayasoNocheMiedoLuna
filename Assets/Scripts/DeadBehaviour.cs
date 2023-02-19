using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;

    public bool canBeDrag = false;
    Vector3 playerPosition;
    [SerializeField]
    private float dragSpeed = 5f;

    private void Start()
    {
        canBeDrag = false;
    }
    private void FixedUpdate()
    {
        if (canBeDrag)
        {
            Debug.Log("entra");
            //transform.position = playerPosition + offset;
            Vector2 targetDirection = (playerPosition - transform.position).normalized;
            rb.velocity = new Vector2(targetDirection.x, targetDirection.y) * dragSpeed;
            //transform.position = playerPosition + offset;
        }
    }

    public void SetTarget(Vector3 position)
    {
        playerPosition = position;
        canBeDrag = true;
        //offset = transform.position - playerPosition;
    }
}
