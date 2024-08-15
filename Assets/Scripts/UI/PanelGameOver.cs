using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelGameOver : BasePopup
{
    public override void Hide()
    {
        GameManager.instance.ChangeState(GameState.MENU);
        base.Hide();
    }
}
