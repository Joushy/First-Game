using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour {
    public Camera cam;

    public void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate () {
        transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward,
    cam.transform.rotation * Vector3.up);
    }
}
