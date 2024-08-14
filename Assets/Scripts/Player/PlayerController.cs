using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    NORMAL,
    DIE
}
public class PlayerController : MonoBehaviour
{
    public event Action<PlayerState> OnStateChange = delegate { };
    public PlayerState state;

    public void ChangeState(PlayerState state)
    {
        this.state = state;
        OnStateChange(state);
    }
}
