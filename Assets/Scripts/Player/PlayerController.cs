using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    IDLE,
    RUN,
    JUMP,
    DIE
}
public class PlayerController : MonoBehaviour
{
    public event Action<PlayerState> OnStateChange = delegate { };
    public PlayerState state;

    [SerializeField] private InputPlayer input;

    [SerializeField] private GroundCheck groundCheck;

    private Movement movement;

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    private void OnEnable()
    {
        state = PlayerState.IDLE;
        ChangeState(state);
    }

    public void ChangeState(PlayerState state)
    {
        this.state = state;
        OnStateChange(state);
        if(state == PlayerState.DIE)
        {
            movement.DelaySetDie();
        }
            
    }

    void Update()
    {
        if (state == PlayerState.DIE) return;
        if (!groundCheck.IsGrounded)
        {
            ChangeState(PlayerState.JUMP);
            return;
        }

        if (input.Horizontal == 0)
        {
            ChangeState(PlayerState.IDLE);
            return;
        }

        ChangeState(PlayerState.RUN);
    }
}
