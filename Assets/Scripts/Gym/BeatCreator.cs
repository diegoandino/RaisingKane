using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatCreator : MonoBehaviour
{


    public AudioSource boss2;
    public float songTime;
    public float log;
    public List<float> beatTime = new List<float>();
    public GameObject beatPrefab;
    public bool replay;



    // Start is called before the first frame update
    void Start()
    {
        boss2 = this.GetComponent<AudioSource>();
        replay = true;
    }

    // Update is called once per frame
    void Update()
    {
        logger();

        if (Input.GetKeyDown(KeyCode.L) && replay)
        {
            boss2.Stop();
            replay = false;
            Invoke("playSong", 5.295986f);
            foreach (float logged in beatTime)
            {
                Invoke("beatCreation", logged);
            }
        }


    }


    public void playSong()
    {
        boss2.Play();
    }
    public void beatCreation()
    {
        Instantiate(beatPrefab, new Vector3(2.53f, -2.46f, 0f), Quaternion.identity);
    }

    public void logger()
        {

        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log(boss2.time);
            songTime = boss2.time;
            boss2.Stop();
        }
        //resumes music at left off time
        if (Input.GetKeyDown(KeyCode.M))
        {
            boss2.time = songTime;
            boss2.Play();
        }
        //resets song and time log
        if (Input.GetKeyDown(KeyCode.B))
        {
            boss2.Stop();
            songTime = 0;
            boss2.time = songTime;
            boss2.Play();
        }
        // logs time without pausing
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log(boss2.time);
            songTime = boss2.time;
            log = songTime;
            beatTime.Add(log);
        }

    }
}
