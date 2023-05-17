using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Slime : MonoBehaviour
{
    public static event Action OnSlimeDeath;

    private Rigidbody2D rb;

    [SerializeField] private float appliedTorqueForce = 10f;
    [SerializeField] private float baseTorqueForce = 40f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (appliedTorqueForce == 0)
            appliedTorqueForce = 10;
        if (baseTorqueForce == 0)
            baseTorqueForce = 2;
    }

    public void DestroyMe()
    {
        Debug.Log("Patata");
        OnSlimeDeath?.Invoke();
        Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        // Rotate the ball around its center
        rb.AddTorque(baseTorqueForce, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("A Rotar");
       // rb.AddTorque(appliedTorqueForce, ForceMode2D.Impulse); // Apply a torque force to the circle object
    }
}