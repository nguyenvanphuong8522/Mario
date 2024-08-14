using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxReward : MonoBehaviour, IBoxRespond
{
    [SerializeField] private Animator animator;
    public void Respond()
    {
        animator.Play("respond", 0, 0);
    }
}
