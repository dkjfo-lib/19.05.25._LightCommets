using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometDebris : MonoBehaviour
{
    private CometValuesHolder systemValues;
    public SpriteRenderer myRenderer;
    public CometParticle cometParticle_prefab;

    private float emisionPassedTime = 0;
    private Vector3 movementDirection;
    private float movementSpeed;
    private bool emitAtTheEnd;
    private bool end = false;
    private float scaleDegree = 0;

    private void Start()
    {
        systemValues = CometValuesHolder.instance;
    }

    public void  Set(Vector3 direction, float speed, bool endEmit)
    {
        movementDirection = direction;
        movementSpeed = speed;
        emitAtTheEnd = endEmit;
    }

    void Update()
    {
        if (!end)
        {
            UpdateMovement();
            UpdateEmit();
        }
        else
        {
            UpdateScale();
        }
    }

    void UpdateEmit()
    {
        emisionPassedTime += Time.deltaTime;
        if (emisionPassedTime > systemValues.debrisDeltaEmissionTime)
        {
            Instantiate(cometParticle_prefab, transform.position, cometParticle_prefab.transform.rotation);
            emisionPassedTime = 0;
        }
    }

    void UpdateMovement()
    {
        transform.position += movementDirection * movementSpeed * Time.deltaTime;
        movementSpeed -= Time.deltaTime;
        if (movementSpeed < 0)
        {
            Die();
        }
    }

    void UpdateScale()
    {
        scaleDegree += 2 * Mathf.PI * systemValues.cometScaleCiclesPerSecond * Time.deltaTime;
        transform.localScale = Vector3.one * (Mathf.Sin(scaleDegree));
        if (scaleDegree > Mathf.PI)
        {
            Destroy(gameObject);
        }
        else
        {
            myRenderer.color = systemValues.CometGetColor(scaleDegree);
        }
    }

    void Die()
    {
        if (emitAtTheEnd)
        {
            systemValues.DebrisEmitDebris(this.transform);
        }
        end = true;
    }
}
