using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class HealthPlayer : MonoBehaviour
{
    private PlayerController controller;
    public int health { get; set; }

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    public void TakeDame()
    {
        health--;
        if(health <= 0 )
        {
            controller.ChangeState(PlayerState.DIE);

        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Enemy"))
        {
            if(col.GetContact(0).normal != Vector2.up)
            TakeDame();
        }
    }


}
