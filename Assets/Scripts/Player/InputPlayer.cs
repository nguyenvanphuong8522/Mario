using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    public bool JumpInputClick { get; private set; }
    public float Horizontal { get; private set; }
    public bool canJump { get; set; }

    private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");

        JumpInputClick = Input.GetKeyDown(KeyCode.UpArrow);

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            canJump = false;
        }

    }
}
