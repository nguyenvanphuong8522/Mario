using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleHealth : EnemyHealth
{
    private TurtleController controller;

    private EnemyMovement movement;

    protected override void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<TurtleController>();
        movement = GetComponent<EnemyMovement>();
    }

    protected override void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Vector2 direct = col.GetContact(0).normal;

            if (controller.curState == TurtleState.idle)
            {
                movement.Direction = 
                col.transform.position.x > transform.position.x ? Vector2.left : Vector2.right;
                controller.ChangeState(TurtleState.shell);
                return;
            }
            if (direct == Vector2.down)
            {
                if (controller.curState == TurtleState.run)
                {
                    controller.ChangeState(TurtleState.idle);
                }
                else if (controller.curState == TurtleState.shell)
                {
                    controller.ChangeState(TurtleState.run);
                }
                return;
            }

            if (col.gameObject.GetComponent<PlayerController>().IsInvincible())
            {
                Die(0.8f, true, TurtleState.diefall);
            }
        }
        
        if (col.gameObject.CompareTag("Bullet"))
        {
            Die(0.8f, true, TurtleState.diefall);
        }
    }
    public void Die(float duration, bool simulate = false, TurtleState state = TurtleState.die)
    {
        StartCoroutine(DelayDie(state, simulate, duration));
    }

    protected IEnumerator DelayDie(TurtleState state, bool simulate, float duration)
    {
        rb.simulated = simulate;
        controller.ChangeState(state);
        ChangeValueDie();
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Player")) return;
        if (controller.curState == TurtleState.shell)
        {
            gameObject.tag = "Enemy";
        }
        else if (controller.curState == TurtleState.idle)
        {
            gameObject.tag = "Untagged";
        }
    }
}
