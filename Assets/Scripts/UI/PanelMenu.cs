using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMenu : BasePopup
{
    [SerializeField] private Button btnPlay;

    protected override void Awake()
    {
        base.Awake();
        btnPlay.onClick.AddListener(OnPlay);
    }
    private void OnPlay()
    {
        UiManager.instance.panelSelectLevel.Show();
    }
}
