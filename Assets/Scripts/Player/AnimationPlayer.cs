using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    private Animator animator;

    private string curAnimation;

    [SerializeField] private GroundCheck groundCheck;

    [SerializeField] private InputPlayer input;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Play(string name)
    {
        if (curAnimation != name)
        {
            animator.Play(name);
        }
    }

    void Update()
    {
        if (!groundCheck.IsGrounded)
        {
            Play("Jump");
            return;
        }

        if (input.Horizontal == 0)
        {
            Play("Idle");
            return;
        }

        Play("Run");
    }
}
