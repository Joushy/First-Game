using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {

    public Transform PlayerTransform;

    private Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    public bool LookAtPlayer = false;
    public bool RotateAroundPlayer = true;
    public float RotationsSpeed = 5.0f;

    public float speedH = 2.0f;

    public AudioSource audio;
    public AudioClip clippy;

    // Use this for initialization

    void Start () {


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        cameraOffset = transform.position - PlayerTransform.position;
        audio = GetComponent<AudioSource>();
        audio.PlayOneShot(clippy);
    }

	
	// LateUpdate is called after Update methods
	void LateUpdate () {

        if (RotateAroundPlayer)
        {
            Quaternion camH = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationsSpeed, this.transform.up);
            Quaternion camV = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * RotationsSpeed, -1 * this.transform.right);

            cameraOffset = camV*camH*cameraOffset;
        }

        Vector3 newPos = PlayerTransform.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        if (LookAtPlayer || RotateAroundPlayer)
            transform.LookAt(PlayerTransform);
	}
}
