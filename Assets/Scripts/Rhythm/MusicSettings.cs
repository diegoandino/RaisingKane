using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public AudioSource Music;

    public bool startPlaying = false;

    public RhythmSpeed RSpeed;

    public static GameManger instance;

    public float StartOffset;

    public float songSpeed;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Music.pitch = songSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                RSpeed.hasStarted = true;

                Music.PlayDelayed(StartOffset/songSpeed);
            }
        }
    }

    public void NoteHit()
    {
        //Debug.Log("Hit");
    }

    public void NoteMiss()
    {
        //Debug.Log("Miss");
    }
}
