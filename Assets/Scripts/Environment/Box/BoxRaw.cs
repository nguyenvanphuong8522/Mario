using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxRaw : MonoBehaviour, IBoxRespond
{
    [SerializeField] private Animator animator;
    public GameObject prefabCoin;

    public void Respond()
    {
        animator.Play("respond", 0, 0);
        SpawnCoin();
        KillEnemy();
    }

    public void KillEnemy()
    {
        List<Collider2D> results = new List<Collider2D>();
        GetComponent<BoxCollider2D>().OverlapCollider(new ContactFilter2D(), results);
        foreach(Collider2D col in results)
        {
            if(col.gameObject.CompareTag("Enemy")) {
                col.GetComponent<EnemyController>().Die();
            }
        }
    }

    public void SpawnCoin()
    {
        Instantiate(prefabCoin, transform.position + Vector3.up, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player") && col.transform.position.y > transform.position.y) {
            if (GetComponentInParent<CompositeCollider2D>() == null)
            {
                transform.parent.AddComponent<CompositeCollider2D>();
                transform.parent.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
        }
    }
}
