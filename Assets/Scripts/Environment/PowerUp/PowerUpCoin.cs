using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoin : PowerUpBase
{
    private void OnEnable()
    {
        ApplyPowerUp();
        Destroy(gameObject, 1);
    }
    public override void ApplyPowerUp()
    {
        GameManager.instance.UpdateCoinPlayer(1);
        AudioManager.instance.Play(AudioManager.instance.listClip[0]);
    }
}
