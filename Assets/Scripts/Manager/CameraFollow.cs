using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private PlayerController player;
    private float width;
    private void Start()
    {
        float height = 2f * Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
    }
    private void LateUpdate()
    {
        if (player == null) return;
        if (player.state == PlayerState.DIE) return;
        if (player.transform.position.x > transform.position.x)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, -10);
        }
        float x = Mathf.Clamp(player.transform.position.x, transform.position.x - width / 2 + 0.35f, Mathf.Infinity);
        player.transform.position = new Vector3(x, player.transform.position.y, 0);
    }

    public void SetUp(PlayerController player)
    {
        this.player = player;
    }
}
