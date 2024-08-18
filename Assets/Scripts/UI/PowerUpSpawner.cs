using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
    COIN,
    SIZE,
    SHOOT
}

public class PowerUpSpawner : MonoBehaviour
{

    public static PowerUpSpawner instance;

    public PowerUpBase[] powerUps;

    private void Awake()
    {
        instance = this;
    }

    public PowerUpBase GetPowerUp(PowerUpType type, Vector3 pos)
    {
        int index = 0;
        switch (type)
        {
            case PowerUpType.COIN:
                break;
            case PowerUpType.SIZE:
                index = 1;
                break;
            case PowerUpType.SHOOT:
                index = 2;
                break;
            default:
                break;
        }
        return Instantiate(powerUps[index], pos, Quaternion.identity);
    }
}
