using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxReward : BoxBase
{
    [SerializeField] private Animator animator;

    public int remain = 1;

    public override void Respond()
    {
        if (remain <= 0) return;

        animator.Play("respond", 0, 0);
        SpawnCoin();
        KillEnemy();

    }



    public void SpawnCoin()
    {
        PowerUpSpawner.instance.GetPowerUp(PowerUpType.COIN, transform.position + Vector3.up);
        if (--remain <= 0)
        {
            animator.Play("empty");
        }
    }


}
