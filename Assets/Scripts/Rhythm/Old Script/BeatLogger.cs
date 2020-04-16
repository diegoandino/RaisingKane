using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatLogger : MonoBehaviour
{

    public AudioSource boss2;
    public float songTime;

    // Start is called before the first frame update
    void Start()
    {
        boss2 = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // logging song time on beat, stops music
        if(Input.GetKeyDown(KeyCode.N))
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
        }
    }
}
