using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDetector : MonoBehaviour
{
    public static MouseDetector instance;
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

    public new Camera camera;
    public Vector3 mousePosition;
    public bool updatePosition = true;

    void Start()
    {
        mousePosition = Vector3.zero;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            updatePosition = !updatePosition;
        }
        if (!updatePosition)
        {
            return;
        }
        GetMousePosition();
    }

    void GetMousePosition()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            mousePosition = hit.point;
            mousePosition.y = 2;
        }
    }
}
