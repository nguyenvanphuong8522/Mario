using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSizeUp : PowerUpBase
{
    private void OnEnable()
    {
        StartCoroutine(StartMove());
    }

    public override void ApplyPowerUp()
    {
        Destroy(gameObject);
    }

    public IEnumerator StartMove()
    {
        yield return new WaitForSeconds(1);
        GetComponent<EnemyMovement>().SetSpeed(2);
    }
}
