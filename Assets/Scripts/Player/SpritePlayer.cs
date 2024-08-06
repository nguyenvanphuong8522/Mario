using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SpritePlayer : MonoBehaviour
{
    public InputPlayer inputPlayer;
    void Update()
    {
        FlipFace();
    }
    public void FlipFace()
    {
        float hor = inputPlayer.Horizontal;
        if (hor == 0) return;

        Vector3 curScale = transform.localScale;
        float x = Mathf.Abs(curScale.x);

        curScale.x = hor < 0 ? -x : x;
        transform.localScale = curScale;
    }
}
