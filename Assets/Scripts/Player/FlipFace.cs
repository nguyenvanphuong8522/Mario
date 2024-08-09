using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class FlipFace : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbPlayer;

    void Update()
    {
        Flip();
    }
    public void Flip()
    {
        float hor = rbPlayer.velocity.x;
        if (hor == 0) return;

        Vector3 curScale = transform.localScale;
        float x = Mathf.Abs(curScale.x);

        curScale.x = hor < 0 ? -x : x;
        transform.localScale = curScale;
    }
}
