using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class RayCastGun : MonoBehaviour
{

    public float damage;
    public float range = 10f;
    public Transform Gun;
    private bool wait;
    public float fireRate;
    public float clipSize, powerClip;
    private bool empty;
    public float ammo;
    public Text ammoText;
    public AudioClip gunshot;
    public Toggle toggle;
    AudioSource audio;
    public Image ammoWheel;


    private void Start()
    {
        clipSize = 40;
        powerClip = clipSize*2;
        ammo = clipSize;
        ammoCount();
        
    }
    // Update is called once per frame
    void Update()
    {
        ammoCount();
        ammoWheel.fillAmount = ammo / powerClip;

        if (!empty)
        {
            if (Input.GetButton("Fire1"))
            {
                if (!wait)
                {
                    StartCoroutine(Fire());
                }
            }
        }
        else
        {
            StartCoroutine(reloadGun());
        }
    }

    private IEnumerator Fire()
    {
        wait = true;

        yield return new WaitForSeconds(fireRate);

        if (!empty)
        {
            if (Input.GetButton("Fire1"))
            {
                ammo -= 1;
                if (ammo == 0)
                {
                    empty = true;
                }

                //AudioSource.PlayClipAtPoint(gunshot, transform.position);
                RaycastHit hit;
                if (Physics.Raycast(Gun.transform.position, Gun.transform.forward, out hit, range))
                {

                    Monsters monster = hit.transform.GetComponent<Monsters>();
                    if (monster != null)
                    {
                        monster.TakeDamage(damage);
                    }


                }


            }
        }
        else
        {
            StartCoroutine(reloadGun());
        }
        wait = false;
        }


    void ammoCount()
    {
        ammoText.text = ammo.ToString();
    }

    private IEnumerator reloadGun()
    {

        yield return new WaitForSeconds(2f);
        ammo = clipSize;
        empty = false;
        ammoCount();
        ammoWheel.fillAmount = ammo / powerClip;
    }

    public void InstaReload()
    {
        ammo = clipSize;
        empty = false;
        ammoCount();
        ammoWheel.fillAmount = ammo / powerClip;
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(3.5f);
        clipSize = clipSize / 2;
        damage = damage / 2;

    }
}
