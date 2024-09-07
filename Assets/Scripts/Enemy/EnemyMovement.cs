using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour, IMovable
{
    internal Rigidbody2D rb;

    public Vector2 Direction { get; set; }

    [SerializeField] protected float speed;


    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        Direction = Vector2.right;
    }

    protected virtual void FixedUpdate()
    {
        Move();
    }
    protected virtual void Move()
    {
        rb.velocity = new Vector2(Direction.x * speed, rb.velocity.y);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Swap") || col.CompareTag("Ground"))
        {
            ChangeDirection();
        }
    }

    protected virtual void ChangeDirection()
    {
        Direction *= -1;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void ResetVelocity()
    {
        rb.velocity = Vector2.zero;
    }
}
