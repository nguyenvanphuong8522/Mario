using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    int i;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            i++;
            StartCoroutine("Test");
        }
        else if(Input.GetMouseButtonDown(1))
        {
            StopCoroutine("Test");
        }
    }

    IEnumerator Test()
    {
        int val = i;
        for (;;)
        {
            yield return null;
        }
    }
}
