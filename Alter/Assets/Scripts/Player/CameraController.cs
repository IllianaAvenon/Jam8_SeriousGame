using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Tracking;

    private Vector3 difference;
    // Use this for initialization
    void Start()
    {
        transform.position = Tracking.transform.position - 10.0f * transform.forward;
        difference = transform.position - Tracking.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = difference + Tracking.transform.position;
    }
}