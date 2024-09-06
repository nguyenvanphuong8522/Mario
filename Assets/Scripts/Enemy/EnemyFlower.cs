using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlower : EnemyMovement
{
    protected override void Start()
    {
        Direction = Vector2.up;
        StartCoroutine(DelayMove());
    }
    protected override void Move()
    {
        rb.velocity = new Vector2(0, Direction.y * speed);
    }
    protected override void ChangeDirection()
    {
        
    }

    private IEnumerator DelayMove()
    {
        while(true)
        {
            if (rb.transform.localPosition.y > 5.5f)
            {
                Direction = Vector2.down;
                SetSpeed(0);
                yield return new WaitForSeconds(2);
                SetSpeed(1);
            }
            else if (rb.transform.localPosition.y < 3)
            {
                Direction = Vector2.up;
                SetSpeed(0);
                yield return new WaitForSeconds(2);
                SetSpeed(1);
            }
            yield return null;
        }
    }

}
