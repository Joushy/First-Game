using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimator : MonoBehaviour
{
    private float lastHealth;
    private Animator anim;
    private float damageDist = 2.1f;
    private float distance;
    private GameObject target;
    private bool wait;

    // Use this for initialization
    void Start()
    {
        anim = this.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        target = this.GetComponent<Monsters>().target;
        Monsters ghost = this.GetComponent<Monsters>();
        distance = Vector3.Distance(target.transform.position, this.transform.position);
        lastHealth = ghost.maxHealth;

        if (this.GetComponent<Rigidbody>().velocity != Vector3.zero)
        {
            anim.SetBool("Move", true);
        }
        else
        {
            anim.SetBool("Move", false);
        }
        if (ghost.health <= 0)
        {
            anim.SetBool("Dead", true);
        }
        else
        {
            anim.SetBool("Dead", false);
        }

        if (lastHealth > ghost.health)
        {
            anim.SetBool("Damaged", true);
        }
        else
        {
            anim.SetBool("Damaged", false);
        }

        if(distance < damageDist)
        {
            if(!wait)
                StartCoroutine(Attack());

        }
        else
        {
            anim.SetBool("Attack", false);
        }
        
    }
    private IEnumerator Attack()
    {
        wait = true;

        anim.SetBool("Attack", true);
        yield return new WaitForSecondsRealtime(1.25f);
        target.GetComponent<PlayerHealth>().TakeDamage(this.GetComponent<Monsters>().damage);
        wait = false;
    }
}
