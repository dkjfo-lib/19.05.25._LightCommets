using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometParticle : MonoBehaviour
{
    private CometValuesHolder systemValues;
    public SpriteRenderer myRenderer;
    private float lifeTime = 0f;

    private void Start()
    {
        systemValues = CometValuesHolder.instance;
        lifeTime = systemValues.particleLifeTime;
    }

    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime > 0)
        {
            float lifePercent = lifeTime / systemValues.particleLifeTime;
            transform.localScale = Vector3.one * lifePercent;
            myRenderer.color = systemValues.ParticleGetColor(lifePercent);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
