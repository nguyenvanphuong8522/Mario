using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    protected Rigidbody2D rb;

    private EnemyController e_controller;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        e_controller = GetComponent<EnemyController>();
    }

    protected virtual void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Vector2 normal = col.GetContact(0).normal;
            if (normal == Vector2.down)
            {
                Die(0.8f);
                return;
            }

            if (col.gameObject.GetComponent<PlayerController>().IsInvincible())
            {
                Die(0.8f,true, EnemyState.diefall);
            }
        }
        else if (col.gameObject.CompareTag("Bullet"))
        {
            Die(0.8f,true, EnemyState.diefall);
        }
    }

    public void Die(float duration, bool simulate = false, EnemyState state = EnemyState.die)
    {
        StartCoroutine(DelayDie(state, simulate, duration));
    }

    protected virtual IEnumerator DelayDie(EnemyState state, bool simulate, float duration)
    {
        rb.simulated = simulate;
        e_controller.ChangeState(state);
        ChangeValueDie();
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }

    protected void ChangeValueDie()
    {
        AudioManager.instance.Play(AudioManager.instance.listClip[3]);
        ChangeLayerDead();
    }

    protected void ChangeLayerDead()
    {
        int layerDead = LayerMask.NameToLayer("Dead");
        gameObject.layer = layerDead;
    }
}
