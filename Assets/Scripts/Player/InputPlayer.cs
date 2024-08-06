using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    private float horizontal;
    private bool jumpInput;

    public bool JumpInput
    {
        get => jumpInput;
    }
    public float Horizontal
    {
        get => horizontal;
    }


    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        jumpInput = Input.GetKeyDown(KeyCode.Space);
    }
}
