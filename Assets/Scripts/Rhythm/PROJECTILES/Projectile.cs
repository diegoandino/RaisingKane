/* Author: Rachel Hoffman
 * 
 * This program controls what effects the projectiles.
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Controls the projectiles and their collisions
 */
public class Projectile : MonoBehaviour
{
    public bool normalHit;
    public bool goodHit;
    public bool perfectHit;
    public bool canBePressed; //If the button can be pressed or not. NOTE: Currently allows you not to miss early
    public bool pressed;
    public static bool _destroy;

    public Transform button1;
    public Transform button2;
    public Transform button3;

	public playerTest meter;
    private Shake shake;

    // Start is called before the first frame update
    void Start()
    {
        normalHit = false;
        goodHit = false;
        perfectHit = false;

        canBePressed = false;
        pressed = true;

        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }


    // Update is called once per frame
    void Update()
    {
        BeatCheck(true);
        //MissCheck(true);
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
                //BP2_MusicSettings.instance.NoteMiss();

                //MissCount.miss++; //Increments the Miss count on GUI
            }
        }
    }


    public void MissCheck(Boolean destroy)
	{
        if(transform.position.y < (button2.position.y - 20))
		{
            MissCount.miss++; //Increments the Miss count on GUI
		    if (destroy == true)
		    {
		        //_destroy = destroy;
		        meter.decrementMeter(1);
		        Destroy(this.gameObject);
		    }

		    else
		    {
		        destroy = false;
		    }
        }
    }


	/**
     * Checks for Beat position and key presses 
     */
	public void BeatCheck(Boolean destroy)
	{

        if (Input.GetButtonDown(BP2_ButtonControls.staticButton))
        {
            if (canBePressed == true)
            {
                //Okay Check
                if (((transform.position.y > BP2_ButtonControls.ButtonPos + 0.25) || (transform.position.y < BP2_ButtonControls.ButtonPos - 0.25)))
                {
                    Debug.Log("Normal Hit");
                    musicManager.Playsound("implode");

                    normalHit = true; perfectHit = false; goodHit = false; pressed = true;
                    
                    ScoreCount.score += 2;

                    if (destroy == true)
                    {
						//_destroy = destroy;
						meter.damage(1);
                        StartCoroutine(DestroyBeat(0));
                        shake.shake();
                    }

                    else
                    {
                        destroy = false;
                    }
                }

                //Good Check
                else if (((transform.position.y > BP2_ButtonControls.ButtonPos + 0.15) || (transform.position.y < BP2_ButtonControls.ButtonPos - 0.15)))
                {
                    Debug.Log("Good Hit");
                    musicManager.Playsound("implode");

                    // Destroy(this.gameObject);

                    normalHit = false; perfectHit = false; goodHit = true; pressed = true;

                    ScoreCount.score += 4;

					if (destroy == true)
                    {
						meter.damage(2);
                        StartCoroutine(DestroyBeat(0));
                        shake.shake();
                    }

                    else
                        destroy = false;
                }

                //Perfect Check
                else
                {
                    Debug.Log("Perfect Hit");
                    // Destroy(this.gameObject);

                    musicManager.Playsound("implode");

                    normalHit = false; perfectHit = true; goodHit = false; pressed = true;

                    ScoreCount.score += 6;

					if (destroy == true)
                    {
						meter.damage(3);
                        StartCoroutine(DestroyBeat(0));
                        shake.shake();
                    }
         
                    else
                        destroy = false;
                }
            }
        }
    }

    public IEnumerator DestroyBeat(float delay)
    {
        this.GetComponent<CircleCollider2D>().enabled = false;
        Animator anim = this.GetComponent<Animator>();
        anim.SetBool("Hit",true);
        print("Waiting to destroy");
        yield return new WaitForSeconds(1);
        print("Destory");
        Destroy(this.gameObject);
    }
}