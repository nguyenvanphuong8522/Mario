using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvincible : PowerUpBase
{
    public override void ApplyPowerUp()
    {
        Destroy(gameObject);
    }
}
