using System.Collections;
using UnityEngine;
using System;

public enum EnemyState
{
    idle,
    run,
    die
}

public class EnemyController : MonoBehaviour
{
    public event Action<EnemyState> OnStateChange = delegate { };

    private EnemyState curState;

    private void Start()
    {
        curState = EnemyState.run;
    }

    public void ChangeState(EnemyState state)
    {
        if(curState != state)
        {
            curState = state;
            OnStateChange(curState);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Vector2 direct = col.GetContact(0).normal;
            if (direct == Vector2.down)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 12, ForceMode2D.Impulse);
                Die();
            }
        }
    }

    internal void Die()
    {
        StartCoroutine(DelayDestroy());
    }

    private IEnumerator DelayDestroy()
    {
        int layerDead = LayerMask.NameToLayer("Dead");
        gameObject.layer = layerDead;
        ChangeState(EnemyState.die);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
