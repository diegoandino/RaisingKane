using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatCreatorSpeed : MonoBehaviour
{
    public float BPM = 86;           //Tells how fast the rhythm is going. (BPM - Beats per minute)
    public bool hasStarted;

    // Start is called before the first frame update
    void Start()
    {
        BPM = BPM / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        {
            //Vector3(x,y,z)
            //The function to move NoteObjects from left to right
            transform.position -= new Vector3((BPM * Time.deltaTime) * BeatMover.instance.songSpeed, 0f, 0f);
        }
    }
}
