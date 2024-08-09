using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private Collider2D collider;

    [SerializeField] private BoxCollider2D boxCollider;

    [SerializeField] private Vector2 direction = Vector2.left;

    [SerializeField] private float speed;


    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        rb.velocity = new Vector2(direction.x, rb.velocity.y);
    }

    private void OnValidate()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Swap") || col.CompareTag("Ground") || col.CompareTag("Enemy"))
        {
            direction *= -1;
        }
    }

}
