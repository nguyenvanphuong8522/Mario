using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _force;
    [SerializeField] private Vector2 _directBounce;
    public Vector2 Direction { set; get; }

    private float speed = 40;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

    }

    public void Movement()
    {
        _rb.AddForce(Direction * speed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.GetContact(0).normal == Vector2.up)
        {
            AddForceBouce();
            return;
        }
        Destroy(gameObject);
    }

    public void AddForceBouce()
    {
        _rb.velocity = Vector2.zero;
        if (Direction == new Vector2(-0.5f, -0.5f))
        {
            _directBounce = new Vector2(-_directBounce.x, _directBounce.y);
            Direction = new Vector2(0.5f, -0.5f);
        }
        _rb.AddForce(_directBounce.normalized * _force);

    }
}


