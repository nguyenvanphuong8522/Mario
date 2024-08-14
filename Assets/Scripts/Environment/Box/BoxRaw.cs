using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRaw : MonoBehaviour, IBoxRespond
{
    [SerializeField] private Animator animator;
    public GameObject prefabCoin;

    public void Respond()
    {
        animator.Play("respond", 0, 0);
        SpawnCoin();
    }

    public void SpawnCoin()
    {
        Instantiate(prefabCoin, transform.position + Vector3.up, Quaternion.identity);
    }
}
