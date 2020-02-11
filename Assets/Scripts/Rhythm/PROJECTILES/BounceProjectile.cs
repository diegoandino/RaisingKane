using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceProjectile : ArchProjectile
{
    public bool bouncing;
    public bool firstPress;

    // Start is called before the first frame update
    void Start()
    {
        this.SetPoints();
        bouncing = false;
        firstPress = true;
    }

    // Update is called once per frame
    void Update()
    {
       if (!bouncing)
		{
            this.ArchMove();
		}else
		{
            BounceMove();
		}
        BeatCheck(true);
        this.MissCheck(true);
    }

    public void BounceMove()
	{
        print("Bounce");
	}

    public void BeatCheck(Boolean destroy)
    {
        if (firstPress)
        {
            if (Input.GetKeyDown(BP2_ButtonControls.staticKey))
            {
                if (canBePressed == true)
                {
                    //Okay Check
                    if (((transform.position.y > BP2_ButtonControls.ButtonPos + 0.25) || (transform.position.y < BP2_ButtonControls.ButtonPos - 0.25)))
                    {
                        Debug.Log("Normal Hit");
                        //musicManager.Playsound("implode");

                        normalHit = true; perfectHit = false; goodHit = false; pressed = true;

                        ScoreCount.score += 2;

                        bouncing = true;
                        firstPress = false;
                    }

                    //Good Check
                    else if (((transform.position.y > BP2_ButtonControls.ButtonPos + 0.15) || (transform.position.y < BP2_ButtonControls.ButtonPos - 0.15)))
                    {
                        Debug.Log("Good Hit");
                        //musicManager.Playsound("implode");

                        // Destroy(this.gameObject);

                        normalHit = false; perfectHit = false; goodHit = true; pressed = true;

                        ScoreCount.score += 4;

                        bouncing = true;
                        firstPress = false;
                    }

                    //Perfect Check
                    else
                    {
                        Debug.Log("Perfect Hit");
                        // Destroy(this.gameObject);

                        musicManager.Playsound("implode");

                        normalHit = false; perfectHit = true; goodHit = false; pressed = true;

                        ScoreCount.score += 6;

                        bouncing = true;
                        firstPress = false;
                    }
                }
            }
        } else
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

                        normalHit = true; perfectHit = false; goodHit = false; pressed = true;

                        ScoreCount.score += 2;


                        if (destroy == true)
                            Destroy(this.gameObject);
                        else
                            destroy = false;
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
                            Destroy(this.gameObject);
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
                            Destroy(this.gameObject);
                        else
                            destroy = false;
                    }
                }
            }
        }
    }
}
