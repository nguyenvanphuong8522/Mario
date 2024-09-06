using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
    COIN,
    SIZE,
    SHOOT,
    INVINCIBLE
}

public class PowerUpSpawner : MonoBehaviour
{
    public static PowerUpSpawner instance;

    public PowerUpBase[] powerUps;

    public GameObject breakEffect;

    public GameObject bullet;


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
            case PowerUpType.INVINCIBLE:
                index = 3;
                break;
            default:
                break;
        }
        return Instantiate(powerUps[index], pos, Quaternion.identity);
    }

    public GameObject SpawnEffectBreak(Vector3 pos)
    {
        AudioManager.instance.Play(AudioManager.instance.listClip[4]);
        GameObject effect =  Instantiate(breakEffect, pos, Quaternion.identity);
        Destroy(effect, 2);
        return effect;
    }
    public GameObject SpawnBullet(Vector2 direction, Vector3 pos)
    {
         GameObject effect =  Instantiate(bullet, pos, Quaternion.identity);
        effect.GetComponent<BulletMovement>().Direction = direction;
        effect.GetComponent<BulletMovement>().Movement();
        return effect;
    }
}
