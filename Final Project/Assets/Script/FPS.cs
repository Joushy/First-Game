using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 smoothen;
    public float sensitivity;
    public float smooth;

    GameObject target;


	// Use this for initialization
	void Start () {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        target = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        var md = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smooth, sensitivity * smooth));
        smoothen.x = Mathf.Lerp(smoothen.x, md.x, 1f / smooth);
        smoothen.y = Mathf.Lerp(smoothen.y, md.y, 1f / smooth);
        mouseLook += smoothen;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        target.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, target.transform.up);


    }
}
