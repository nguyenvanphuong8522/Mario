using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    internal Rigidbody2D rb;

    private Vector2 direction;

    [SerializeField] private float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        direction = Vector2.right;
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Swap") || col.CompareTag("Ground"))
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        direction *= -1;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
