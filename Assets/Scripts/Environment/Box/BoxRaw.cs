using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxRaw : BoxBase
{
    [SerializeField] private Animator animator;
    public override void Respond()
    {
        animator.Play("respond", 0, 0);
        KillEnemy();
    }
}
