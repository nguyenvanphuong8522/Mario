using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    MENU,
    STARTED,
    PAUSE,
    GAMEOVER
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public event Action<GameState> OnStateChanged;

    public GameState curState = GameState.MENU;

    public LevelManager levelManager;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
        DontDestroyOnLoad(gameObject);
        levelManager = Instantiate(levelManager);
    
    }

    public void UpdateCoinPlayer(int value)
    {
        levelManager.player.IncreaseCoin(value);
    }

    public void ChangeState(GameState state)
    {
        curState = state;
        OnStateChanged(curState);
    }

}
