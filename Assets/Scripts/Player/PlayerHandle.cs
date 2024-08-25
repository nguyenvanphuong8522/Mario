using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHandle : MonoBehaviour
{
    private List<Transform> boxesTransform = new List<Transform>();

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Box")) return;

        if (col.GetContact(0).normal == Vector2.down)
        {
            boxesTransform.Add(col.transform);
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Box")) return;

        if(boxesTransform.Count == 0) return;

        Transform min = boxesTransform[0];

        float x = transform.position.x;
        foreach (Transform t in boxesTransform)
        {
            float distanceMin = Mathf.Abs(min.position.x - x);
            float distanceCur = Mathf.Abs(t.position.x - x);

            if (distanceCur < distanceMin)
            {
                min = t;
            }
        }

        if(GetComponent<PlayerController>() != null)
        {
            if(GetComponent<PlayerController>().powerUpsReceived.Contains(PowerUpType.SIZE)) {
                if(min.GetComponent<BoxRaw>() != null)
                {
                    min.GetComponent<BoxRaw>().Break();
                    boxesTransform.Clear();
                    return;
                }
            }
        }
        min.GetComponent<BoxBase>().Respond();
        boxesTransform.Clear();
    }
}
