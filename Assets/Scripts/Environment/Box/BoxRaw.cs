using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxRaw : BoxBase
{
    [SerializeField] private Animator animator;
    public override void Respond()
    {
        animator.Play("respond", 0, 0);
        KillEnemy();
    }
    protected override void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") && col.transform.position.y > transform.position.y)
        {
            if (GetComponentInParent<CompositeCollider2D>() == null)
            {
                transform.parent.AddComponent<CompositeCollider2D>();
                transform.parent.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
        }
    }

    public void Break()
    {
        KillEnemy();
        Destroy(gameObject);
        PowerUpSpawner.instance.SpawnEffectBreak(transform.position);
    }
}
