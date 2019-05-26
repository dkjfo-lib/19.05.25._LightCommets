using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameParticle : MonoBehaviour
{
    private MeteorValues values;
    private float lifeTime = 2f;

    void Start()
    {
        values = MeteorValues.instance;
        lifeTime = values.particleMaxLifeTime;
    }

    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime > 0)
        {
            float lifePercent = lifeTime / values.particleMaxLifeTime;
            transform.localScale = Vector3.one * lifePercent;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
