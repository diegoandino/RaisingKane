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
	public static bool normalHit;
	public static bool goodHit;
	public static bool perfectHit;
	private bool canBePressed; //If the button can be pressed or not. NOTE: Currently allows you not to miss early
	private bool pressed;

    private IEnumerator buttonSpriteChange;

    public bool wasHit;

    public Transform button1;
    public Transform button2;
    public Transform button3;

	public GameObject badBeat;

    

	// Start is called before the first frame update
	void Start()
    {
		normalHit    = false;
		goodHit      = false;
		perfectHit   = false;

		canBePressed = false;
		pressed      = true;
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
            Debug.Log(other.gameObject.name);
            
            if (gameObject.activeSelf)
            {
				canBePressed = false;
                ///BP2_MusicSettings.instance.NoteMiss();


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
                if (((transform.position.y > BP2_ButtonControls.ButtonPos + 0.25) || (transform.position.y < BP2_ButtonControls.ButtonPos - 0.25)))
                {
                    Debug.Log("Normal Hit");
					musicManager.Playsound("implode");

					normalHit = true;   perfectHit = false;     goodHit = false;    pressed = true;

                    ScoreCount.score += 2;


                    Destroy(this.gameObject);  
                }

                //Good Check
                else if (((transform.position.y > BP2_ButtonControls.ButtonPos + 0.15) || (transform.position.y < BP2_ButtonControls.ButtonPos - 0.15)))
                {
                    Debug.Log("Good Hit");
					musicManager.Playsound("implode");

                   // Destroy(this.gameObject);

                    normalHit = false; perfectHit = false; goodHit = true; pressed = true;

					ScoreCount.score += 4;

                    //buttonSprite.sprite = hitButton;


                    Destroy(this.gameObject);  
                }

                //Perfect Check
                else 
                {
                    Debug.Log("Perfect Hit");
                   // Destroy(this.gameObject);

                    musicManager.Playsound("implode");

					normalHit = false; perfectHit = true; goodHit = false; pressed = true;

					ScoreCount.score += 6;


                    Destroy(this.gameObject);
                }
            }
        }
	}
}