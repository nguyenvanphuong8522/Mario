using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSelectLevel : BasePopup
{
    [SerializeField] private List<Button> listOfBtn;

    protected override void Awake()
    {
        base.Awake();

    }
    private void Start()
    {
        SetUp();
    }

    private void SetUp()
    {
        foreach (var btn in listOfBtn)
        {
            int index = listOfBtn.IndexOf(btn);
            btn.onClick.AddListener(() =>
            {
                GameManager.instance.levelManager.SpawnLevel(index);
                UiManager.instance.panelMenu.Hide();
                Hide();
            });
        }
    }
}
