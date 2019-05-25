using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHolder : MonoBehaviour
{
    public FlameMeteor meteor_prefab;
    public float rotationRate = .25f;
    public int meteorCount = 2;
    public float distance = 3f;

    private List<FlameMeteor> meteors = new List<FlameMeteor>();

    public float rotation = 0;
    float deltaRad = 0;

    void Start()
    {
        CreateMeteors();
    }

    void Update()
    {
        rotation += Mathf.PI * 2 * rotationRate * Time.deltaTime;
        if (rotation > Mathf.PI * 2)
            rotation -= Mathf.PI * 2;
        int i = 0;
        meteors.ForEach(m =>
        {
            Vector3 localPosition = new Vector3(Mathf.Cos(rotation + i * deltaRad), 0, Mathf.Sin(rotation + i * deltaRad)) * distance;
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

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, 0.5f);
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(transform.position, 0.25f);
    //}
}
