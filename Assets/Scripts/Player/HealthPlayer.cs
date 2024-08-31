using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class HealthPlayer : MonoBehaviour
{
    private PlayerController p_controller;
    public int health { get; set; }

    private void Awake()
    {
        p_controller = GetComponent<PlayerController>();
    }

    public void TakeDame()
    {
        health--;
        if (health <= 0)
        {
            if (p_controller.powerUpsReceived.Contains(PowerUpType.SIZE))
            {
                p_controller.SizeDown();
                return;
            }
            if (p_controller.animationPlayer.GetWeight() <= 0)
                p_controller.ChangeState(PlayerState.DIE);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("PowerUp")) return;

        PowerUpBase basePowerUp = col.GetComponent<PowerUpBase>();
        if (basePowerUp != null)
        {
            switch (basePowerUp.type)
            {
                case PowerUpType.SIZE:
                    p_controller.SizeUp();
                    break;
                case PowerUpType.SHOOT:
                    break;
                default:
                    break;
            }
            basePowerUp.ApplyPowerUp();
        }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            if (col.GetContact(0).normal != Vector2.up)
                TakeDame();
        }

    }


}
