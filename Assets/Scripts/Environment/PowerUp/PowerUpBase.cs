using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    protected abstract void ApplyPowerUp();

    protected void OnCollisionEnter2D(Collision2D col)
    { 
        if(col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
