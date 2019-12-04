/* Author: Rachel Hoffman
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
    public float ButtonPos; //the x,y cordinates of the button
    public bool canBePressed; //If the button can be pressed or not. NOTE: Currently allows you not to miss early
    public KeyCode aKey; //" A " key press 
	public KeyCode sKey; //" S " key press 
	public KeyCode dKey; //" D " key press 
    
	private bool normalHit;
	private bool goodHit;
	private bool perfectHit; 

	// Start is called before the first frame update
	void Start()
    {
        
        ButtonPos = -4.9f;  //Get the x position of the button

        //print("button pos for new beat is = " + ButtonLocation.transform.position.x);

		canBePressed = false;
		
		normalHit = false;
		goodHit = false;
		perfectHit = false;
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

				MissCount.miss++;
            }
        }
    }


	/**
     * Checks for Beat position and key presses 
     */
	void BeatCheck()
    {

        //" A " key press check
        if (Input.GetKeyDown(aKey))
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

					normalHit = true;   perfectHit = false;     goodHit = false;

					ScoreCount.score += 2;
				}

                //Good Check
                else if ((transform.position.x > ButtonPos + 0.10) || (transform.position.x < ButtonPos - 0.10))
                {
                    Debug.Log("Good Hit");
                    musicManager.Playsound("implode");
                    gameObject.SetActive(false);
					//BP2_MusicSettings.instance.NoteHit();

					normalHit = false; perfectHit = false; goodHit = true;

					ScoreCount.score += 4;
				}

                //Perfect Check
                else
                {
                    Debug.Log("Perfect Hit");
                    musicManager.Playsound("implode");
                    gameObject.SetActive(false);
					//BP2_MusicSettings.instance.NoteHit();

					normalHit = false; perfectHit = true; goodHit = false;

					ScoreCount.score += 6;
				}
            }
        }


        //" S " key press check
		if (Input.GetKeyDown(sKey))
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

					normalHit = true; perfectHit = false; goodHit = false;

					ScoreCount.score += 2;
				}

				//Good Check
				else if ((transform.position.x > ButtonPos + 0.10) || (transform.position.x < ButtonPos - 0.10))
				{
					Debug.Log("Good Hit");
					musicManager.Playsound("implode");
					gameObject.SetActive(false);
					//BP2_MusicSettings.instance.NoteHit();

					normalHit = false; perfectHit = false; goodHit = true;

					ScoreCount.score += 4;
				}

				//Perfect Check
				else
				{
					Debug.Log("Perfect Hit");
					musicManager.Playsound("implode");
					gameObject.SetActive(false);
					//BP2_MusicSettings.instance.NoteHit();

					normalHit = false; perfectHit = true; goodHit = false;

					ScoreCount.score += 6;
				}
			}
		}

        //" D " key press check
		if (Input.GetKeyDown(dKey))
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

					normalHit = true; perfectHit = false; goodHit = false;

					ScoreCount.score += 2;
				}

				//Good Check
				else if ((transform.position.x > ButtonPos + 0.10) || (transform.position.x < ButtonPos - 0.10))
				{
					Debug.Log("Good Hit");
					musicManager.Playsound("implode");
					gameObject.SetActive(false);
					//BP2_MusicSettings.instance.NoteHit();

					normalHit = false; perfectHit = false; goodHit = true;

					ScoreCount.score += 4;
				}

				//Perfect Check
				else
				{
					Debug.Log("Perfect Hit");
					musicManager.Playsound("implode");
					gameObject.SetActive(false);
					//BP2_MusicSettings.instance.NoteHit();

					normalHit = false; perfectHit = true; goodHit = false;

					ScoreCount.score += 6;
				}
			}
		}
	}
}
