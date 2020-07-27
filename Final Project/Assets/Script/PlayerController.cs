using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody rb;
    public Transform cam;

    public float speed = 5.0f;
    public float turnSmoothing = 15f;
    public float speedDampTime = 0.1f;
    public float force = -20;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    void FixedUpdate()
    {

        float lh = Input.GetAxisRaw("Horizontal");


            var newRotation = new Vector3(cam.eulerAngles.x, cam.eulerAngles.y, transform.eulerAngles.z);


            if (lh != 0f)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newRotation), speedDampTime * turnSmoothing * Time.deltaTime);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                rb.MoveRotation(transform.rotation);
            }

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
    


    private void Update()
    {

        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) && !(this.GetComponent<Animator>().GetBool("Run")))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) && !(this.GetComponent<Animator>().GetBool("Run")))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }


        if(transform.localPosition.y > .20)
        {
            rb.AddForce(1, force, 1);
        }
    }
}

