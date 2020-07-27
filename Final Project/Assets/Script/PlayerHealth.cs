using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    public float maxHealth = 100f;
    public float health;
    public Image hpbar;

    public Image megaBar;
    public float megaCharge;
    public float megaMax;

    public Vector3 megaSpawn;
    public GameObject mega;
    public bool spotTaken;
    public bool invinc = false;
    public bool dead;


	// Update is called once per frame
	void Start() {
        health = maxHealth;
	}

    public void TakeDamage(float damage)
    {
        if (!invinc)
        {
            health -= damage;

            hpbar.fillAmount = health / maxHealth;
            if (health <= 0f)
            {
                dead = true;
                transform.position = new Vector3(76.96f, .001f, 35.97f);
                SceneManager.LoadScene("Lost Screen");
            }
        }
    }

    public void AddCharge()
    {


        megaCharge += 1;
        megaBar.fillAmount = megaCharge / megaMax;
        if (megaCharge == megaMax && !spotTaken)
        {
            spotTaken = true;
            Instantiate(mega, megaSpawn, Quaternion.identity);
            megaCharge = 0;
        }


    }

    public void AddHealth(int i)
    {
        health += i;
    }
    
    public void Ruined()
    {
        maxHealth = maxHealth - 10;
        health = health / 2;
    }

    public void toggleIt()
    {
        if (invinc == true)
            invinc = false;
        else
            invinc = true;
    }
}
