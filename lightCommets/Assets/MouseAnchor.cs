using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAnchor : MonoBehaviour
{
    public float respondRate = 0.125f;
    private MouseDetector detector;
    void Start()
    {
        detector = MouseDetector.instance;
        transform.position = detector.mousePosition;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, detector.mousePosition, respondRate);
    }
}
