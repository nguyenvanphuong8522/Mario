using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private EnemyController e_Controller;

    private string curAnimation;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        e_Controller.OnStateChange += Play;
    }

    private void OnDisable()
    {
        e_Controller.OnStateChange -= Play;
    }

    public void Play(EnemyState state)
    {
        if (curAnimation != state.ToString())
        {
            curAnimation = state.ToString();
            animator.Play(curAnimation);
        }
    }   
}
