using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoLoadLevel : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> levels;

    private GameObject curLevel;

    public void SpawnLevel(int index)
    {
        if (curLevel == null)
        {
            curLevel = Instantiate(levels[index]);
            return;
        }

        Destroy(curLevel);
        curLevel = Instantiate(levels[index]);

    }
}
