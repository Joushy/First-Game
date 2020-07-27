using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{

    public GameObject greenGhost;
    public GameObject purpleGhost;
    public GameObject orangeGhost;
    public GameObject whiteGhost;

    public GameObject greenBat;
    public GameObject redBat;
    public GameObject violetBat;
    public GameObject yellowBat;

    public GameObject redRabbit;
    public GameObject greenRabbit;
    public GameObject cyanRabbit;
    public GameObject yellowRabbit;


    private GameObject monster;
    public Camera cam;
    public GameObject player;
    private float xValue, yValue;
    private int count, type, beast, rise, n;
    private bool wait;


    // Use this for initialization
    void Start()
    {
        int n = 10;
        Spawn(n);
        wait = false;
    }

    private void Update()
    {
        if (player.GetComponent<PlayerHealth>().health !=0)
        {
            Debug.Log("1");
            if (!wait)
                StartCoroutine(Stall());
        }
    }


    void randomNums()
    {
        float num = Random.Range(40f , 70f);
        if (Random.value >= .5)
            xValue = num;
        else
            xValue = -num;
        float num2 = Random.Range(40f, 70f);
        if (Random.value >= .5)
            yValue = num2;
        else
            yValue = -num2;
    }

    private GameObject PickMonster()
    {
        type = Random.Range(0, 12);
        Mathf.RoundToInt(type);

        switch (type)
        {
            case 0:
                monster = greenGhost;
                beast = 0;
                break;
            case 1:
                monster = orangeGhost;
                beast = 0;
                break;
            case 2:
                monster = purpleGhost;
                beast = 0;
                break;
            case 3:
                monster = whiteGhost;
                beast = 0;
                break;
            case 4:
                monster = greenBat;
                beast = 1;
                break;
            case 5:
                monster = redBat;
                beast = 1;
                break;
            case 6:
                monster = violetBat;
                beast = 1;
                break;
            case 7:
                monster = yellowBat;
                beast = 1;
                break;
            case 8:
                monster = redRabbit;
                beast = 2;
                break;
            case 9:
                monster = greenRabbit;
                beast = 2;
                break;
            case 10:
                monster = cyanRabbit;
                beast = 2;
                break;
            case 11:
                monster = yellowRabbit;
                beast = 2;
                break;
            default:
                break;
        }

        return monster;
    }

    private void Spawn(int n) 
    {
        while (count < n)
        {

            randomNums();
            monster = PickMonster();

            Vector3 pos = new Vector3(player.transform.localPosition.x + (Random.insideUnitCircle).x * xValue, player.transform.position.y + rise
                , player.transform.localPosition.z + (Random.insideUnitCircle).y * yValue);

            Instantiate(monster, pos, Quaternion.identity);
            count++;
        }
        count = 0;
    }

    private IEnumerator Stall()
    {
        Debug.Log("2");
        wait = true;
        yield return new WaitForSecondsRealtime(7);
        Spawn(n+4);
        wait = false;
    }
}

