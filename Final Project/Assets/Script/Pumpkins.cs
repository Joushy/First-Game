using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkins : MonoBehaviour {


    public GameObject[] enemies;
    public GameObject target;
    public GameObject gun;
    public bool harm = true;
    public AudioSource audio;
    public AudioClip clippy;
    public AudioClip clippy2;
    public AudioClip clippy3;
    public AudioClip clippy4;
    public bool inv = false;

    // Use this for initialization
    void Start () {
        GameObject.FindGameObjectsWithTag("Player"); ;
        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Player")
        {
            target = other.gameObject;

            if(transform.tag == "FiftyFifty")
            {
                yaMiteDye(other.gameObject);
            }

            if(transform.tag == "Health")
            {
                GainHealth();
            }
            if(transform.tag == "GunPlay")
            {
                Enhancement(target);
            }
            if (transform.tag == "Mega")
            {
                StartCoroutine(Invincible(target));
            }

        }
    }

    public void yaMiteDye(GameObject other)
    {
        enemies = (GameObject.FindGameObjectsWithTag("Enemy"));

        if(Random.value > .5)
        {
            for (int i = enemies.Length-1; i> enemies.Length / 2; i--)
            {
                Destroy(enemies[i]);
            }
            if (Random.value < .5)
                audio.PlayOneShot(clippy3);
            else
                audio.PlayOneShot(clippy4);
        }
        else
        {
            float health = other.GetComponent<PlayerHealth>().health;
            float maxhealth = other.GetComponent<PlayerHealth>().maxHealth;
            other.GetComponent<PlayerHealth>().TakeDamage(health / 2);
            other.GetComponent<PlayerHealth>().maxHealth = (maxhealth-10);

            if (Random.value < .5)
                audio.PlayOneShot(clippy);
            else
                audio.PlayOneShot(clippy2);

        }

        StartCoroutine(Kill());
    }

    public void GainHealth() {

        target.GetComponent<PlayerHealth>().AddHealth(30);
        if (Random.value < .5)
            audio.PlayOneShot(clippy);
        else
            audio.PlayOneShot(clippy2);
        StartCoroutine(Kill());
    }

    public void Enhancement(GameObject tar)
    {
        gun = tar.transform.Find("Char1__Model").transform.Find("modelGun").gameObject;

        if (Random.value < .5)
            audio.PlayOneShot(clippy);
        else
            audio.PlayOneShot(clippy2);

        StartCoroutine(Kill());

        gun.GetComponent<RayCastGun>().damage *= 2;
        gun.GetComponent<RayCastGun>().clipSize = gun.GetComponent<RayCastGun>().powerClip;
        gun.GetComponent<RayCastGun>().InstaReload();
    }

    private IEnumerator Invincible(GameObject tar)
    {
        tar.GetComponent<PlayerHealth>().toggleIt();
        audio.PlayOneShot(clippy);

        yield return new WaitForSeconds(7f);
        tar.GetComponent<PlayerHealth>().toggleIt();
        StartCoroutine(Kill());

    }

    private IEnumerator Kill()
    {
        yield return new WaitForSeconds(.7f);
        Destroy(this.gameObject);
    }
}
