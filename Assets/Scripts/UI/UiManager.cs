using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public PanelStarted panelStarted;

    [SerializeField] private BasePopup panelGameOver;
    public BasePopup panelMenu;

    public BasePopup panelSelectLevel;

    private void OnEnable()
    {
        GameManager.instance.OnStateChanged += ChangeState;
    }

    private void OnDisable()
    {
        GameManager.instance.OnStateChanged -= ChangeState;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void ChangeState(GameState state)
    {
        switch(state)
        {
            case GameState.MENU:
                panelStarted.Hide();
                panelMenu.Show();
                break;
            case GameState.STARTED:
                panelStarted.Show();
                break;
            case GameState.GAMEOVER:
                panelGameOver.Show();
                break;
        }
    }

    public void UpdateTxtCoin(string value)
    {
        panelStarted.UpdateTxtCoin($"Coin: {value}");
    }
}
