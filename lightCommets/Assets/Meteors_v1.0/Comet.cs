using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comet : MonoBehaviour
{
    private CometValuesHolder systemValues;
    public SpriteRenderer myRenderer;
    private float scaleDegree = 0;

    void Start()
    {
        systemValues = CometValuesHolder.instance;
        transform.localScale = Vector3.one;
    }

    void Update()
    {
        UpdateScale();
    }

    void UpdateScale()
    {
        scaleDegree += 2 * Mathf.PI * systemValues.cometScaleCiclesPerSecond * Time.deltaTime;
        transform.localScale = Vector3.one * (Mathf.Sin(scaleDegree) + 1);
        if (scaleDegree > Mathf.PI)
        {
            Destroy(gameObject);
        }
        else
        {
            if (scaleDegree > .75f * Mathf.PI)
            {
                systemValues.CometEmitDebris(this.transform);
            }
            myRenderer.color = systemValues.CometGetColor(scaleDegree);
        }
    }
}
