using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    SETUP,
    STARTED,
    PAUSE,
    GAMEOVER
}
public class GameManager : MonoBehaviour
{
    public event Action<GameState> OnStateChanged;

    public GameState curState = GameState.SETUP;

    public void ChangeState(GameState state)
    {
        curState = state;
        OnStateChanged(curState);
    }

}
