using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Monsters : MonoBehaviour
{

    public float health = 60f;
    public float maxHealth;
    public GameObject target;
    private float minDistance;
    private bool dead;
    public float damage = 12f;

    public Transform canvas;
    private Image healthBar;
    public NavMeshAgent agent;
    public GameObject tree;
    int count;
    bool played;
    public GameObject Healthdrop;
    public GameObject Megadrop;
    public GameObject Gundrop;
    public GameObject FiftyFifty;

    public AudioSource audio;
    public AudioClip clippy;

    public void Start()
    {
        transform.position = Vector3.up *2;
        target = GameObject.FindGameObjectWithTag("Player");
        canvas = transform.Find("EnemyCanvas");
        canvas.GetComponent<FaceCamera>().cam = Camera.main;
        agent.speed = 6;
        agent.acceleration = 6;
        agent.radius = 0.02f;
        count = 0;
        audio = GetComponent<AudioSource>();
    }

    public void Update()
    {
        //transform.Translate(0, 2, 0);
        healthBar = canvas.Find("Health").GetComponent<Image>();
        if (target != null)
        {
            transform.LookAt(target.transform);
            if (!dead)
            {

                agent.SetDestination(target.transform.position);
            }
            else
            {
                agent.speed = 0;

            }
        }


    }



    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / maxHealth;
        if (health <= 0f)
        {
            dead = true;
            StartCoroutine(Fade());

        }

    }

    private IEnumerator Fade()
    {

        if (!played)
        {

            if(Random.value <= .3f)
            {
                pickSound();
                played = true;
            }

        }
        this.transform.Rotate(0, 0, 5);
        yield return new WaitForSeconds(3f);
        DropItem();
        Destroy(gameObject);

        target.GetComponent<PlayerHealth>().AddCharge();


    }

    private void pickSound(){
        int num = Random.Range(0, 1);
        switch (num)
        {
            case 0: audio.PlayOneShot(clippy);
                break;
            default: audio.PlayOneShot(clippy);
                break;
        }
    }

    public void DropItem()
    {

        Vector3 thisPos = new Vector3(transform.localPosition.x, transform.localPosition.y + 1.1f, transform.localPosition.z);

        float ah = Random.value;

        if(ah < 2)
        {
            int num =Random.Range(0,3);

            switch (num)
            {
                case 0: Instantiate(Healthdrop, thisPos, Quaternion.identity);
                    Debug.Log("1");
                    break;
                case 1: Instantiate(Gundrop, thisPos, Quaternion.identity);
                    break;
                case 2: Instantiate(FiftyFifty, thisPos, Quaternion.identity);    
                    break;
                default: break;

        }
        }
    }
}
