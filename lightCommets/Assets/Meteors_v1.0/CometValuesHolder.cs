using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometValuesHolder : MonoBehaviour
{
    public static CometValuesHolder instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Instance already exists", this);
            Destroy(this.gameObject);
        }
    }

    [Header("Comet")]
    public Comet comet_prefab;
    public float cometScaleCiclesPerSecond = 1f;
    public int cometDebrisCount = 4;
    public float cometDebrisSpeed = 1.5f;
    public Color cometStartColor = Color.red;
    public Color cometEndColor = Color.red;

    [Header("Comet Debris")]
    public CometDebris cometDebris_prefab;
    public float debrisParticlesPerSecond = 4;
    [HideInInspector] public float debrisDeltaEmissionTime = 0;
    public int debrisDebrisCount = 4;
    public float debrisDebrisSpeed = 1f;

    [Header("Comet Particle")]
    public float particleLifeTime = 1f;
    public Color particleStartColor = Color.red;
    public Color particleEndColor = Color.white;

    void Update()
    {
        debrisDeltaEmissionTime = 1 / debrisParticlesPerSecond;
    }

    public void InstantiateComet(Vector3 position)
    {
        Instantiate(
            comet_prefab,
            position,
            comet_prefab.transform.rotation);
    }

    public void CometEmitDebris(Transform emitionPoint)
    {
        BrustEmitCometDebris(emitionPoint, cometDebrisCount, cometDebrisSpeed, true);
    }
    public void DebrisEmitDebris(Transform emitionPoint)
    {
        BrustEmitCometDebris(emitionPoint, debrisDebrisCount, debrisDebrisSpeed, false);
    }

    private void BrustEmitCometDebris(Transform emitionPoint, int debrisCount, float debrisSpeed, bool futureEmitAtTheEnd)
    {
        float deltaRad = 2 * Mathf.PI / debrisCount;
        for (int i = 0; i < debrisCount; i++)
        {
            Instantiate(
                cometDebris_prefab,
                emitionPoint.position,
                cometDebris_prefab.transform.rotation).Set(
                new Vector3(Mathf.Cos(deltaRad * i), 0, Mathf.Sin(deltaRad * i)),
                debrisSpeed,
                futureEmitAtTheEnd);
        }
    }

    public Color ParticleGetColor(float lifePercent)
    {
        return Color.Lerp(particleStartColor, particleEndColor, 1 - lifePercent);
    }
    public Color CometGetColor(float scaleDegree)
    {
        return Color.Lerp(cometStartColor, cometEndColor, scaleDegree / Mathf.PI);
    }
}
