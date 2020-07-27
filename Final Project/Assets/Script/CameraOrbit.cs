using UnityEngine;
using System.Collections;

public class CameraOrbit : MonoBehaviour
{

    public Transform target;
    public Camera mainCam;
    public GameObject player;
    Vector3 pos, tempPos, startPos;
    public Canvas canvas;
    public GameObject tree;
    bool start;
    AudioSource audio;
    public AudioClip clippy;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        pos = new Vector3(-0.74f, 1.91f, 0f);
        tempPos = new Vector3(0.27f,1.91f,0);
        startPos = transform.position;
        startPos.x -= 3;
    }

    void Update()
    {


        player.transform.Find("CameraSpot").transform.localPosition = tempPos;
        transform.LookAt(target);
        transform.tag = "MainCamera";
        transform.Translate(Vector3.right * Time.deltaTime * 1.6f);
        StartCoroutine(Wait());

        if (!player.GetComponent<PlayerHealth>().dead)
        {
            if (start)
            {
                target.transform.localPosition = pos;
                Destroy(this.gameObject);
                tree.GetComponent<SpawnMonster>().enabled = true;
                mainCam.GetComponent<PlayerFollow>().enabled = true;
                canvas.GetComponent<Canvas>().enabled = true;
                player.GetComponent<PlayerController>().enabled = true;
            }
        }
    }
        

    private IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(9f);

        start = true;


    }
}

