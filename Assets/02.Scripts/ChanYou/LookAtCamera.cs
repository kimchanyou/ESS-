using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform CamTr;
    private Transform CanvasTr;
    void Start()
    {
        CamTr = Camera.main.transform;
        CanvasTr = GetComponent<Transform>();
    }

    void Update()
    {
        CanvasTr.LookAt(CamTr);
    }
}
