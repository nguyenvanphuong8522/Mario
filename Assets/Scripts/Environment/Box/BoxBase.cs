using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BoxBase: MonoBehaviour
{
    public abstract void Respond();

    protected virtual void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Bullet")))
        {
            if(col.GetContact(0).normal == Vector2.down)
            if (transform.parent.GetComponent<CompositeCollider2D>() == null)
            {
                transform.parent.AddComponent<CompositeCollider2D>();
                transform.parent.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if ((col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Bullet")))
        {
            if (transform.parent.GetComponent<CompositeCollider2D>() != null)
            {
                Destroy(transform.parent.GetComponent<CompositeCollider2D>());
                Destroy(transform.parent.GetComponent<Rigidbody2D>());
            }
        }
    }
    public void KillEnemy()
    {
        List<Collider2D> results = new List<Collider2D>();
        GetComponent<BoxCollider2D>().OverlapCollider(new ContactFilter2D(), results);
        foreach (Collider2D col in results)
        {
            if (col.gameObject.CompareTag("Enemy"))
            {
                col.GetComponent<EnemyHealth>().Die(0.8f, true, EnemyState.diefall);
            }
        }
    }
}
