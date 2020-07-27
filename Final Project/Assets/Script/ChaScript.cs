using UnityEngine;
using System.Collections;

public class ChaScript : MonoBehaviour
{
    private Animator anim;
    private float health;
    private float currentHealth;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        Forward();
        Backwards();

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            Left();
            Right();
        }


        if (Input.GetKey(KeyCode.Mouse0) && !Input.GetKey(KeyCode.W) &&
                !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }


    }

    //Handles Forward Animations
    void Forward()
    {
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("Walk", true);
            this.GetComponent<PlayerController>().speed = 5f; ;
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.LeftShift)
                )
        {
            anim.SetBool("Run", true);
            this.GetComponent<PlayerController>().speed = 9f; ;
        }
        else
        {
            anim.SetBool("Run", false);
            this.GetComponent<PlayerController>().speed = 5f; ;
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Mouse0))
        {
            anim.SetBool("WalkFire", true);
        }
        else
        {
            anim.SetBool("WalkFire", false);
        }

    }

    //Handles Left Motion Animations
    void Left()
    {
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("RunLeft", true);
        }
        else
        {
            anim.SetBool("RunLeft", false);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Mouse0))
        {
            anim.SetBool("LeftAttack", true);
        }
        else
        {
            anim.SetBool("LeftAttack", false);
        }
    }

    //Handles Right Motion Animations
    void Right()
    {
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("RunRight", true);
        }
        else
        {
            anim.SetBool("RunRight", false);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Mouse0))
        {
            anim.SetBool("RightAttack", true);
        }
        else
        {
            anim.SetBool("RightAttack", false);
        }
    }

    //Handles Backwards MotionAnimations
    void Backwards()
    {
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("RunBack", true);
        }
        else
        {
            anim.SetBool("RunBack", false);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Mouse0))
        {
            anim.SetBool("BackAttack", true);
        }
        else
        {
            anim.SetBool("BackAttack", false);
        }
    }

}



