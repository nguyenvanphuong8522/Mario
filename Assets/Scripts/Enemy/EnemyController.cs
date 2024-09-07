using System.Collections;
using UnityEngine;
using System;

public enum EnemyState
{
    idle,
    run,
    die,
    diefall
}



public class EnemyController : MonoBehaviour
{
    private EnemyState curState;

    private EnemyMovement movement;

    private EnemyAnimation e_Animation;

    private void Awake()
    {
        movement = GetComponent<EnemyMovement>();
        e_Animation = transform.GetComponentInChildren<EnemyAnimation>();
    }

    private void Start()
    {
        curState = EnemyState.run;
    }

    public void ChangeState(EnemyState state)
    {
        if(curState != state)
        {
            curState = state;
            e_Animation.Play(state.ToString());
            switch (state)
            {
                case EnemyState.run:
                    movement.SetSpeed(2);
                    break;
                case EnemyState.die:
                    movement.SetSpeed(0);
                    movement.ResetVelocity();
                    break;
                case EnemyState.diefall:
                    movement.SetSpeed(0);
                    movement.ResetVelocity();
                    movement.rb.AddForce(Vector2.up * 60, ForceMode2D.Impulse);
                    break;
                default:
                    movement.SetSpeed(0);
                    break;
            }
        }
    }
}
