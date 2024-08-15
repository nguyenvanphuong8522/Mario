using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMenu : BasePopup
{
    public override void Hide()
    {
        Play();
        base.Hide();
    }
    private void Play()
    {
        GameManager.instance.levelManager.SpawnLevel(0);
    }
}
