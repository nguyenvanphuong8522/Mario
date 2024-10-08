using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour, IMovable
{
    private InputPlayer input;

    [SerializeField] private GroundCheck groundCheck;

    internal Rigidbody2D rb;

    private PlayerController p_controller;

    [SerializeField] private DataPlayer data;

    private float yInit;

    private Coroutine coroutineSetDie;

    public Vector2 Direction { get; set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<InputPlayer>();
        p_controller = GetComponent<PlayerController>();
        Direction = Vector2.zero;
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
        Direction = new Vector2(input.Horizontal * data.speedMove, rb.velocity.y);
        rb.velocity = Direction;
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
        AudioManager.instance.Play(AudioManager.instance.listClip[2]);
        rb.simulated = false;
        int layerDead = LayerMask.NameToLayer("Dead");
        gameObject.layer = layerDead;
        yield return new WaitForSeconds(.2f);
        rb.simulated = true;
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * 13, ForceMode2D.Impulse);
        yield return new WaitForSeconds(.8f);
        GameManager.instance.ChangeState(GameState.GAMEOVER);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.GetContact(0).normal == Vector2.down)
        {
            input.canJump = false;
        }
    }
}
