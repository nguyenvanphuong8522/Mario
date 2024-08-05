using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float horizontal;
    public Rigidbody2D rb;
    public float speedMove;
    public float jumpForce;
    private void Start()
    {
        rb.velocity = Vector3.zero;
    }
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        Vector2 direction = new Vector2(horizontal * speedMove, rb.velocity.y);
        rb.velocity = direction;
    }
    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
