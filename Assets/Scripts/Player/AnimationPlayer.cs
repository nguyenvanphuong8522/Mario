using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    private PlayerController p_Controller;

    private Animator animator;

    private string curAnimation;

    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        p_Controller = GetComponentInParent<PlayerController>();
    }

    private void OnEnable()
    {
        p_Controller.OnStateChange += ChangeState;
    }

    private void OnDisable()
    {
        p_Controller.OnStateChange -= ChangeState;
    }

    private void Play(string name)
    {
        if (curAnimation != name)
        {
            animator.Play(name);
        }
    }

    private void ChangeState(PlayerState state)
    {
        switch (state)
        {
            case PlayerState.IDLE:
                Play("Idle");
                break;
            case PlayerState.RUN:
                Play("Run");
                break;
            case PlayerState.JUMP:
                Play("Jump");
                break; 
            case PlayerState.DIE:
                Play("Die");
                break;
            default:
                break;
        }
    }
}
