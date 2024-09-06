using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    public EnemyController e_controller;

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
        else if (col.gameObject.CompareTag("Bullet"))
        {
            DieFall();
        }
    }

    internal void DieFall()
    {
        StartCoroutine(DelyDieFall());
    }
    internal void Die()
    {
        StartCoroutine(DelayDie());
    }

    public IEnumerator DelyDieFall()
    {
        rb.AddForce(Vector2.up * 60, ForceMode2D.Impulse);
        e_controller.ChangeState(EnemyState.diefall);
        ChangeValueDie();

        yield return new WaitForSeconds(.8f);
        Destroy(gameObject);
    }

    private IEnumerator DelayDie()
    {
        rb.simulated = false;
        e_controller.ChangeState(EnemyState.die);
        ChangeValueDie();

        yield return new WaitForSeconds(.8f);
        Destroy(gameObject);
    }

    private void ChangeValueDie()
    {
        AudioManager.instance.Play(AudioManager.instance.listClip[3]);
        int layerDead = LayerMask.NameToLayer("Dead");
        gameObject.layer = layerDead;
        rb.velocity = Vector2.zero;
    }
}
