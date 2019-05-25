using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorValues : MonoBehaviour
{
    public static MeteorValues instance;
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

    [Header("Meteor")]
    public float meteorEmitionRate = 4f;
    [HideInInspector] public float meteorEmitionDeltaTime = 0;
    public float meteorRespondRate = .125f;

    [Header("Particle")]
    public float particleMaxLifeTime = 2f;

    private void Update()
    {
        meteorEmitionDeltaTime = 1 / meteorEmitionRate;
    }
}
