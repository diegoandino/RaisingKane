﻿/* Author: Rachel Hoffman
 * 
 * This program controls what effects the projectiles.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


/**
 * Controls the projectiles and their collisions
 */
public class BP2_Projectiles : MonoBehaviour
{
	private bool normalHit;
	private bool goodHit;
	private bool perfectHit;
	private bool canBePressed; //If the button can be pressed or not. NOTE: Currently allows you not to miss early

	// Start is called before the first frame update
	void Start()
    {
		normalHit    = false;
		goodHit      = false;
		perfectHit   = false;

		canBePressed = false;
	}


    // Update is called once per frame
    void Update()
    {
        BeatCheck();
	}


	/**
     * Beat can be pressed when entering the collider
     * @param 2D Collider
     */
	private void OnTriggerEnter2D(Collider2D other)
    {
        //Make sure it is the button collider
        if (other.tag == "Button")
        {
			canBePressed = true;
		}
    }


    /**
     * Miss when beat exits the collider
     * @param 2D Collider
     */ 
    private void OnTriggerExit2D(Collider2D other)
    {
        //Make sure it is the button collider
        if (other.tag == "Button")
        {
            if (gameObject.activeSelf)
            {
				canBePressed = false;
                BP2_MusicSettings.instance.NoteMiss();

				MissCount.miss++; //Increments the Miss count on GUI
            }
        }
    }


	/**
     * Checks for Beat position and key presses 
     */
	void BeatCheck()
    {

        if (Input.GetKeyDown(BP2_ButtonControls.staticKey))
        {
            if (canBePressed == true)
            {
                //Okay Check
                if ((transform.position.x > BP2_ButtonControls.ButtonPos + 0.15) ||
                   (transform.position.x < BP2_ButtonControls.ButtonPos - 0.15))
                {
                    Debug.Log("Normal Hit");
					musicManager.Playsound("implode");

					gameObject.SetActive(false);

					normalHit = true;   perfectHit = false;     goodHit = false;

					ScoreCount.score += 2;
				}

                //Good Check
                else if ((transform.position.x > BP2_ButtonControls.ButtonPos + 0.10) ||
                        (transform.position.x < BP2_ButtonControls.ButtonPos - 0.10))
                {
                    Debug.Log("Good Hit");
					musicManager.Playsound("implode");

					gameObject.SetActive(false);

					normalHit = false; perfectHit = false; goodHit = true;

					ScoreCount.score += 4;
				}

                //Perfect Check
                else
                {
                    Debug.Log("Perfect Hit");
                    gameObject.SetActive(false);

					musicManager.Playsound("implode");

					normalHit = false; perfectHit = true; goodHit = false;

					ScoreCount.score += 6;
				}
            }
        }
	}
}