using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    public PowerUpType type;
    public abstract void ApplyPowerUp();
}
