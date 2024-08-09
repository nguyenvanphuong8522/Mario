using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemyAnimation anim;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Vector2 direct = col.GetContact(0).normal;
            if(direct == Vector2.down)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 12, ForceMode2D.Impulse);
                gameObject.GetComponent<Rigidbody2D>().simulated = false;
                anim.Play("die");
                StartCoroutine(DelayDestroy());
            }
        }
    }

    private IEnumerator DelayDestroy()
    {
        int layerDead = LayerMask.NameToLayer("Dead");
        gameObject.layer = layerDead;
        yield return new WaitForSeconds(1f);
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
