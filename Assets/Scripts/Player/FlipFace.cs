using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class FlipFace : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbPlayer;

    [SerializeField] private SpriteRenderer spriteRenderer;
    void Update()
    {
        Flip();
    }
    public void Flip()
    {
        float hor = rbPlayer.velocity.x;
        if (hor != 0)
        {
            if(hor <= 0)
            {
                spriteRenderer.flipX = true;
                return;
            }
            spriteRenderer.flipX = false;
        }
    }
}
