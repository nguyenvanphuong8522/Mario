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

    [SerializeField] private EnemyMovement e_movement;
    [SerializeField] private EnemyAnimation e_Animation;

    private void Start()
    {
        curState = EnemyState.run;
    }

    public void ChangeState(EnemyState state)
    {
        if(curState != state)
        {
            curState = state;
            e_Animation.Play(state);
            switch (state)
            {
                case EnemyState.run:
                    e_movement.SetSpeed(2);
                    break;
                case EnemyState.die:
                    e_movement.SetSpeed(0);
                    break;
                case EnemyState.diefall:
                    e_movement.SetSpeed(0);
                    break;
                default:
                    e_movement.SetSpeed(0);
                    break;
            }
        }
    }
}
