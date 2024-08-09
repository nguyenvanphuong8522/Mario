using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private InputPlayer input;

    [SerializeField] private GroundCheck groundCheck;

    private Rigidbody2D rb;

    [SerializeField] private DataPlayer data;


    private float yInit;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<InputPlayer>();
    }

    void Update()
    {
        CheckInputJump();
    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void CheckInputJump()
    {
        if (input.JumpInputClick && groundCheck.IsGrounded)
        {
            input.canJump = true;
            yInit = transform.position.y;
        }

        float curHight = transform.position.y - yInit;
        if (curHight > data.maxJump)
        {
            input.canJump = false;
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(input.Horizontal * data.speedMove, rb.velocity.y);
    }
    private void Jump()
    {
        if(input.canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, data.jumpForce);
        }
    }
}
