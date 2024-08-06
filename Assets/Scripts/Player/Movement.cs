using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public InputPlayer inputPlayer;
    public GroundCheck groundCheck;
    public Rigidbody2D rb;

    public float speedMove;
    public float jumpForce;

    private void Update()
    {
        if (inputPlayer.JumpInput && groundCheck.IsGrounded)
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
        Vector2 direction = new Vector2(inputPlayer.Horizontal * speedMove, rb.velocity.y);
        rb.velocity = direction;
    }
    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
        groundCheck.IsGrounded = false;
    }
}
