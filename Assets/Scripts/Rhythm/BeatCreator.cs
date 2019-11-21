using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatCreator : MonoBehaviour
{
    //-- Main Variables --//
    public AudioSource boss2;
    public List<float> beatTime = new List<float>();
    public GameObject beatPrefab;

    public float songTime;
    public float log;

    public bool replay;
    //--------------------//


    //--Vector 3 Instantiantion Variables for location --//
    Vector3 pos1 = new Vector3(2.53f, -1.52f, 0f);
    Vector3 pos2 = new Vector3(2.53f, -2.45f, 0f);
    Vector3 pos3 = new Vector3(2.53f, -3.38f, 0f);
    Vector3 pos4 = new Vector3(2.53f, -4.31f, 0f);
    //---------------------------------------------------//

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
        Instantiate(beatPrefab, pos1, Quaternion.identity);
        Instantiate(beatPrefab, pos2, Quaternion.identity);
        Instantiate(beatPrefab, pos3, Quaternion.identity);
        Instantiate(beatPrefab, pos4, Quaternion.identity);


        /*-- Explanation for the rest:
         What's done above is a brute force method to test instantiation in different distances.

         TO-DO:
         1. Iterate through Rhythm Button game objects
         2. Instantiate beatPreFab at each one WHILE keeping in mind the FLOAT TIMES in BEAT TIME

         Meaning it might need some restructuring to get each different logged beat to instantiate at the different locations

         3. Snap to each button and be able to move UP & DOWN using either WASD or ARROW KEYS
        */
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
