using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameMeteor : MonoBehaviour
{
    public FlameParticle meteor_prefab;

    private MeteorValues values;
    private float passedTime = 0;

    void Start()
    {
        values = MeteorValues.instance;
    }

    void Update()
    {
        //transform.Rotate(Vector3.forward, 360 * rotationRate * Time.deltaTime);
        {
            passedTime += Time.deltaTime;
            if (passedTime > values.meteorEmitionDeltaTime)
            {
                Instantiate(meteor_prefab, transform.position, meteor_prefab.transform.rotation);
                passedTime = 0;
            }
        }
    }

    public void UpdatePosition(Vector3 targetWorldPosition)
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetWorldPosition, values.meteorRespondRate);
    }
}
