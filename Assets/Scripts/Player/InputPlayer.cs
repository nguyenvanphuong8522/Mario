using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    public bool JumpInputClick { get; private set; }
    public float Horizontal { get; private set; }
    public bool canJump { get; set; }

    private bool canControl;

    private void Update()
    {
        if (!canControl) return;
        Horizontal = Input.GetAxis("Horizontal");

        JumpInputClick = Input.GetKeyDown(KeyCode.UpArrow);

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            canJump = false;
        }

    }

    public void DisableControl()
    {
        canControl = false;
        Horizontal = 0;
        JumpInputClick = false;
        canJump = false;
    }

    public void EnableControl()
    {
        canControl = true;

    }
}
