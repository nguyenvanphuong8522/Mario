using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [SerializeField] private BasePopup panelStarted;
    [SerializeField] private BasePopup panelGameOver;
    [SerializeField] private BasePopup panelMenu;

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
                panelMenu.Show();
                break;
            case GameState.GAMEOVER:
                panelGameOver.Show();
                break;
        }
    }


}
