using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHolder : MonoBehaviour
{
    private MeteorValues values;
    public FlameMeteor meteor_prefab;
    public int meteorCount = 2;

    private List<FlameMeteor> meteors = new List<FlameMeteor>();

    public float rotation = 0;
    float deltaRad = 0;

    void Start()
    {
        values = MeteorValues.instance;
        CreateMeteors();
    }

    void Update()
    {
        UpdateInput();
        UpdateMeteorsPosition();
    }

    void UpdateInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AddMeteor();
        }
        if (Input.GetMouseButtonDown(1))
        {
            RemoveMeteor();
        }
    }

    void UpdateMeteorsPosition()
    {
        rotation += Mathf.PI * 2 * values.ciclesPerSecond * Time.deltaTime;
        if (rotation > Mathf.PI * 2)
            rotation -= Mathf.PI * 2;
        int i = 0;
        meteors.ForEach(m =>
        {
            Vector3 localPosition = new Vector3(Mathf.Cos(rotation + i * deltaRad), 0, Mathf.Sin(rotation + i * deltaRad)) * values.getMeteorOrbitRadius;
            m.UpdatePosition(localPosition + transform.position);
            i++;
        });
    }

    void CreateMeteors()
    {
        deltaRad = 360 / meteorCount * Mathf.Deg2Rad;
        for (int i = 0; i < meteorCount; i++)
        {
            meteors.Add(Instantiate(
                meteor_prefab,
                Vector3.zero,
                meteor_prefab.transform.rotation));
        }
    }

    void AddMeteor()
    {
        if (meteorCount == values.maxMeteors)
            return;

        meteors.Add(Instantiate(
            meteor_prefab,
            Vector3.zero,
            meteor_prefab.transform.rotation));

        meteorCount++;
        deltaRad = 360 / meteorCount * Mathf.Deg2Rad;
    }

    void RemoveMeteor()
    {
        if (meteorCount == 0)
            return;

        FlameMeteor temp = meteors[0];
        meteors.Remove(temp);
        CometValuesHolder.instance.InstantiateComet(temp.transform.position);
        Destroy(temp.gameObject);

        meteorCount--;
        deltaRad = 360 / meteorCount * Mathf.Deg2Rad;
    }
}
