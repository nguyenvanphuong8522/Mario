using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TurtleState
{
    idle,
    run,
    die,
    shell,
    diefall
}

public class TurtleController : MonoBehaviour
{
    public TurtleState curState;

    public bool isInShell;

    private EnemyMovement movement;

    private EnemyAnimation animationSprite;

    private Coroutine coroutineWaitToRun;


    private void Awake()
    {
        movement = GetComponent<EnemyMovement>();
        animationSprite = GetComponentInChildren<EnemyAnimation>();
    }

    private void Start()
    {
        curState = TurtleState.run;
    }

    public void ChangeState(TurtleState state)
    {
        if (curState != state)
        {
            curState = state;
            animationSprite.Play(state.ToString());
            switch (state)
            {
                case TurtleState.run:
                    StopWaitToRun();
                    gameObject.tag = "Enemy";
                    movement.SetSpeed(2);
                    break;
                case TurtleState.die:
                    movement.SetSpeed(0);
                    break;
                case TurtleState.diefall:
                    movement.SetSpeed(0);
                    break;
                case TurtleState.idle:
                    movement.SetSpeed(0);
                    StartWaitToRun();
                    break;
                case TurtleState.shell:
                    movement.SetSpeed(10f);
                    StartWaitToRun();
                    break;
                default:
                    break;
            }
        }
    }

    internal void StartWaitToRun()
    {
        StopWaitToRun();
        coroutineWaitToRun = StartCoroutine(IdleIEnumerator());
    }

    private void StopWaitToRun()
    {
        if (coroutineWaitToRun != null)
        {
            StopCoroutine(coroutineWaitToRun);
        }
    }

    private IEnumerator IdleIEnumerator()
    {
        yield return new WaitForSeconds(4f);
        ChangeState(TurtleState.run);
    }
}
