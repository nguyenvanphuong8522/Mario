using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxReward : BoxBase
{
    [SerializeField] private Animator animator;
    [SerializeField] private PowerUpType type;

    public int remain = 1;

    public override void Respond()
    {
        if (remain <= 0) return;

        animator.Play("respond", 0, 0);
        SpawnPowerUp();
        KillEnemy();
    }

    public void SpawnPowerUp()
    {
        PowerUpSpawner.instance.GetPowerUp(type, transform.position + Vector3.up);
        if (--remain <= 0)
        {
            animator.Play("empty");
        }
    }
}
