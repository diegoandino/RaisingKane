using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyProjectile : ArchProjectile
{



    // Update is called once per frame
    void Update()
    {
        this.ArchMove();
        beatCheck(true);
    }

    public void beatCheck(Boolean destroy)
	{
         if (Input.GetKeyDown(BP2_ButtonControls.staticKey))
            {
                if (canBePressed == true)
                {
                    //Okay Check
                    if (((transform.position.y > BP2_ButtonControls.ButtonPos + 0.25) || (transform.position.y < BP2_ButtonControls.ButtonPos - 0.25)))
                    {
                        Debug.Log("Bad Hit");
                        musicManager.Playsound("implode");

                        normalHit = true; perfectHit = false; goodHit = false; pressed = true;

                        if (destroy == true)
                            Destroy(this.gameObject);
                        else
                            destroy = false;
                    }

                    //Good Check
                    else if (((transform.position.y > BP2_ButtonControls.ButtonPos + 0.15) || (transform.position.y < BP2_ButtonControls.ButtonPos - 0.15)))
                    {
                        Debug.Log("Bad Hit");
                        musicManager.Playsound("implode");

                        // Destroy(this.gameObject);

                        normalHit = false; perfectHit = false; goodHit = true; pressed = true;

                        if (destroy == true)
                            Destroy(this.gameObject);
                        else
                            destroy = false;
                    }

                    //Perfect Check
                    else
                    {
                        Debug.Log("Bad Hit");
                        // Destroy(this.gameObject);

                        musicManager.Playsound("implode");

                        normalHit = false; perfectHit = true; goodHit = false; pressed = true;

                        if (destroy == true)
                            Destroy(this.gameObject);
                        else
                            destroy = false;
                    }
                }
            }   
    }

}
