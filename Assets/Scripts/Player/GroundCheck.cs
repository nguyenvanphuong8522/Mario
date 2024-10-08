using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool isGrouned;
    public bool IsGrounded
    {
        get => isGrouned;
        set
        {
            isGrouned = value;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("Box"))
        {
            isGrouned = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("Box"))
        {
            isGrouned = false;
        }
    }
}
