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

    [Header("Mode_LetsGetCrazy")]
    public bool LetsGetCrazy = false;
    public float LGC_ciclesPerSecond = .5f;
    private float LGC_currentRadius;
    private float degree;

    [Header("Input")]
    public float scrollSpeed = 1f;

    [Header("Holder")]
    public int maxMeteors = 8;
    public float ciclesPerSecond = 2f;
    public float meteorOrbitRadius = 2f;
    public float getMeteorOrbitRadius
    {
        get { return LetsGetCrazy ? LGC_currentRadius : meteorOrbitRadius; }
    }

    [Header("Meteor")]
    public float meteorEmitionRate = 4f;
    [HideInInspector] public float meteorEmitionDeltaTime = 0;
    public float meteorMovementRespondRate = .125f;

    [Header("Particle")]
    public float particleMaxLifeTime = 2f;

    private void Update()
    {
        {
            meteorEmitionDeltaTime = 1 / meteorEmitionRate;
        }
        {
            float scrollValue = Input.GetAxis("Mouse ScrollWheel");
            if (scrollValue != 0)
            {
                meteorOrbitRadius += scrollValue * scrollSpeed;
            }
        }
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                LetsGetCrazy = !LetsGetCrazy;
                degree = 0;
                if (LetsGetCrazy)
                    LGC_currentRadius = meteorOrbitRadius;
                else
                    meteorOrbitRadius = LGC_currentRadius;
            }
            if (LetsGetCrazy)
            {
                degree += 2 * Mathf.PI * LGC_ciclesPerSecond * Time.deltaTime;
                LGC_currentRadius = meteorOrbitRadius * Mathf.Cos(degree);
            }
        }
    }
}
