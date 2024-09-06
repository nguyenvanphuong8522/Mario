using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _force;
    private Vector2 _directBounce = Vector2.one;
    public Vector2 Direction;
        

    private float speed = 40;

    [SerializeField] private GameObject _prefabExplore;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

    }

    private void SpawnEffectExplore()
    {
        Instantiate(_prefabExplore, transform.position, Quaternion.identity);
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
        SpawnEffectExplore();
        Destroy(gameObject);
    }

    public void AddForceBouce()
    {
        _rb.velocity = Vector2.zero;
        if (Direction.x < 0)
        {
            _directBounce.x *= -1;
            Direction.x = 0.5f;
        }
        _rb.AddForce(_directBounce.normalized * _force);
    }
}


