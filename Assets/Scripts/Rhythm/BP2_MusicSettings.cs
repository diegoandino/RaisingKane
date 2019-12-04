/* Author: Rachel Hoffman
 * 
 * This programn is used to effect the music speed and also effects
 * the BP2RhythmSpeed class for the projectile speed.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the Music settings.
/// </summary>
public class BP2_MusicSettings : MonoBehaviour
{
    public AudioSource Music; //music file
    public AudioSource ghostMusic;// ghost song file
    public BP2_RhythmSpeed RSpeed;
    public static BP2_MusicSettings instance;
	public GameObject UI; 

    public bool startPlaying = false;
    public float StartOffset;       //The wait before a the song plays 

    /// <summary>
    /// NOTE: This also effects class BP2RhythmSpeed
    /// </summary>
    public float songSpeed;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //This slows or speeds up the song, while also effecting it's pitch
        Music.pitch = songSpeed;
        //print("music pitch is "+ Music.pitch);
        //slowing down start song as well
        ghostMusic.pitch = songSpeed;
		//print("ghost music pitch is " + ghostMusic.pitch);

		UI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            //The confirm button to start the music and projectiles 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                startPlaying = true;
                RSpeed.hasStarted = true;
                Music.PlayDelayed(StartOffset / songSpeed);
                //playing ghost music as well
                ghostMusic.PlayDelayed(StartOffset / songSpeed);//Slows or speeds up the delay based on the speed given.

				UI.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Controls what a note hit does. 
    /// </summary>
    public void NoteHit()
    {
        //Debug.Log("Hit");
    }

    /// <summary>
    /// Controls what a note miss does. 
    /// </summary>
    public void NoteMiss()
    {
        //Debug.Log("Miss");
    }
}
