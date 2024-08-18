using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelStarted : BasePopup
{
    [SerializeField] private TextMeshProUGUI txtCoin;

    public void UpdateTxtCoin(string value)
    {
        txtCoin.SetText(value);
    }
}
