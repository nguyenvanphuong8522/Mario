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

    public void Play(string name, int layer = -1)
    {
        if (curAnimation != name)
        {
            animator.Play(name, layer);
        }
    }

    public void SetWeightLayerSecond(int value)
    {
        animator.SetLayerWeight(1, value);
    }

    public float GetWeight()
    {
        return animator.GetLayerWeight(1);
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
            case PlayerState.FREEZE:
                //Play("sizeUp");
                break; 
            case PlayerState.DIE:
                Play("Die");
                break;
            default:
                break;
        }
    }
}
