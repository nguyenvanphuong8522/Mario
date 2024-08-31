using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Bullet"))
        {
            if(GetComponent<CompositeCollider2D>() != null)
            {
                Destroy(GetComponent<CompositeCollider2D>());
                Destroy(GetComponent<Rigidbody2D>());
            }
        }
    }
}
