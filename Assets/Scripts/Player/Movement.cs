using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private InputPlayer input;

    [SerializeField] private GroundCheck groundCheck;

    private Rigidbody2D rb;

    private PlayerController p_controller;

    [SerializeField] private DataPlayer data;


    private float yInit;

    private Coroutine coroutineSetDie;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<InputPlayer>();
        p_controller = GetComponent<PlayerController>();
    }

    void Update()
    {
        CheckInputJump();
    }

    void FixedUpdate()
    {
        if(p_controller.state != PlayerState.DIE)
        {
            Move();
            Jump();
        }
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
    public void DelaySetDie()
    {
        if(coroutineSetDie != null)
        {
            StopCoroutine(coroutineSetDie);
        }
        coroutineSetDie = StartCoroutine(SetDie());
    }

    public IEnumerator SetDie()
    {
        rb.simulated = false;
        int layerDead = LayerMask.NameToLayer("Dead");
        gameObject.layer = layerDead;
        yield return new WaitForSeconds(.8f);
        rb.simulated = true;
        rb.AddForce(Vector2.up * 13, ForceMode2D.Impulse);
        yield return new WaitForSeconds(.8f);
        GameManager.instance.ChangeState(GameState.GAMEOVER);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.GetContact(0).normal == Vector2.down) 
            input.canJump = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("die");
        }
    }
}
