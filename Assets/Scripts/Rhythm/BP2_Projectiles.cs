﻿/* Author: Rachel Hoffman
 * 
 * This program controls what effects the projectiles.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  Controls what effects the projectiles.
/// </summary>
public class BP2_Projectiles : MonoBehaviour
{

    //public GameObject ButtonCenter;
    public float ButtonPos; //the x,y cordinates of the button
    public bool canBePressed; //If the button can be pressed or not. NOTE: Currently allows you not to miss early
    public KeyCode keyToPress; //What ever the button we assign it to
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Get the x position of the button
        ButtonPos = -4.9f;
        //print("button pos for new beat is = " + ButtonLocation.transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        BeatCheck();
    }

    /// <summary>
    /// If projectil enters into button area, then the button can be pressed.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Make sure it is the button collider
        if (other.tag == "Button")
        {
            canBePressed = true;
        }
    }

    /// <summary>
    /// When projectile leaves button area then it counts as a miss.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit2D(Collider2D other)
    {
        //Make sure it is the button collider
        if (other.tag == "Button")
        {
            if (gameObject.activeSelf)
            {
                canBePressed = false;
                BP2_MusicSettings.instance.NoteMiss();
            }
        }
    }


    void BeatCheck()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                //Okay Check
                if ((transform.position.x > ButtonPos + 0.15) || (transform.position.x < ButtonPos - 0.15))
                {
                    Debug.Log("Normal Hit");
                    musicManager.Playsound("implode");
                    gameObject.SetActive(false);
                    //BP2_MusicSettings.instance.NoteHit();
                }

                //Good Check
                else if ((transform.position.x > ButtonPos + 0.10) || (transform.position.x < ButtonPos - 0.10))
                {
                    Debug.Log("Good Hit");
                    musicManager.Playsound("implode");
                    gameObject.SetActive(false);
                    //BP2_MusicSettings.instance.NoteHit();
                }

                //Perfect Check
                else
                {
                    Debug.Log("Perfect Hit");
                    musicManager.Playsound("implode");
                    gameObject.SetActive(false);
                    //BP2_MusicSettings.instance.NoteHit();
                }
            }
        }
    }
}
