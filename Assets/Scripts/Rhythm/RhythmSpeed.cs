using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmSpeed : MonoBehaviour
{
    //Tells how fast the rhythm is going. (BPM - Beats per minute)
    public float BPM;

    //Tells when it can begin to move the beats.
    public bool hasStarted; 


    // Start is called before the first frame update
    void Start()
    {
        //I believe this is the tempo / by 60 seconds to make it a minute.
        BPM = BPM / 60f; 
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        { 
            //Vector3(x,y,z)
            transform.position -= new Vector3((BPM * Time.deltaTime)*GameManger.instance.songSpeed, 0f, 0f);
        }
    }
}
