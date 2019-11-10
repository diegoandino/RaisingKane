/* Author: Rachel Hoffman
 * 
 * This program controls the speed of the projectiles.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the speed of the projectiles.
/// </summary>
public class BP2_RhythmSpeed : MonoBehaviour
{
    public float BPM = 86;           //Tells how fast the rhythm is going. (BPM - Beats per minute)
    public bool hasStarted;     //If gameplay has started 


    // Start is called before the first frame update
    void Start()
    {
        BPM = BPM / 60f;        //I believe this is the tempo / by 60 seconds to make it a minute.
       
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        { 
            //Vector3(x,y,z)
            //The function to move NoteObjects from left to right
            transform.position -= new Vector3((BPM * Time.deltaTime)* BP2_MusicSettings.instance.songSpeed, 0f, 0f);
        }
    }
}
