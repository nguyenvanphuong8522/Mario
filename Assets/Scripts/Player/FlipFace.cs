using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class FlipFace : MonoBehaviour
{
    [SerializeField] private IMovable movement;

    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        movement = GetComponentInParent<IMovable>();
    }
    void Update()
    {
        Flip();
    }
    public void Flip()
    {
        float hor = movement.Direction.x;
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
