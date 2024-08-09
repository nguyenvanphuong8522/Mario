using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;

    private string curAnimation;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Play(string name)
    {
        if (curAnimation != name)
        {
            animator.Play(name);
        }
    }

    void Update()
    {

    }
}
