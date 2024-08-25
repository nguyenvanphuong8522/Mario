using System.Collections;
using UnityEngine;
using System;

public enum EnemyState
{
    idle,
    run,
    die,
    diefall
}

public class EnemyController : MonoBehaviour
{
    public event Action<EnemyState> OnStateChange = delegate { };

    private EnemyState curState;

    [SerializeField] private EnemyMovement movement;

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

    internal void DieFall()
    {
        StartCoroutine(SetDieFall());
    }
    internal void Die()
    {
        StartCoroutine(DelayDestroy());
    }

    public IEnumerator SetDieFall()
    {
        movement.rb.AddForce(Vector2.up * 60, ForceMode2D.Impulse);
        ChangeState(EnemyState.diefall);
        ChangeValueDie();
        
        yield return new WaitForSeconds(.8f);
        Destroy(gameObject);
    }

    private IEnumerator DelayDestroy()
    {
        GetComponent<Rigidbody2D>().simulated = false;
        ChangeState(EnemyState.die);
        ChangeValueDie();

        yield return new WaitForSeconds(.8f);
        Destroy(gameObject);
    }

    private void ChangeValueDie()
    {
        AudioManager.instance.Play(AudioManager.instance.listClip[3]);
        int layerDead = LayerMask.NameToLayer("Dead");
        gameObject.layer = layerDead;
        movement.rb.velocity = Vector2.zero;
    }
}
