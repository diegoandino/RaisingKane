using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMover : MonoBehaviour
{

    public BeatCreatorSpeed RSpeed;
    public static BeatMover instance;
    //public AudioSource Music;
    public bool startPlaying = false;
    public float StartOffset;

    public float songSpeed;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //Music.pitch = songSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            //The confirm button to start the music and projectiles 
            if (Input.GetKeyDown(KeyCode.L))
            {
                startPlaying = true;
                RSpeed.hasStarted = true;
                //Music.PlayDelayed(StartOffset / songSpeed);
            }
        }
    }

}

