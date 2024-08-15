using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 direction;

    [SerializeField] private float speed;

    [SerializeField] private EnemyController e_Controller;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        direction = Vector2.left;
    }

    private void OnEnable()
    {
        e_Controller.OnStateChange += ChangeState;
    }

    private void OnDisable()
    {
        e_Controller.OnStateChange -= ChangeState;
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
        else if (col.CompareTag("Enemy"))
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        direction *= -1;
    }

    public void ChangeState(EnemyState state)
    {
        switch (state)
        {
            case EnemyState.run:
                speed = 2;
                break;
            case EnemyState.die:
                speed = 0;
                break;
            default:
                speed = 0;
                break;
        }
    }
}
