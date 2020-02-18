using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiTapProjectile : ArchProjectile
{
    public int BeatTaps;
    private int TapCount;

    /*/ Start is called before the first frame update
    void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        BeatCheck(true);
        this.ArchMove();
        this.MissCheck(true);
        beatHealth();
    }

    new void BeatCheck(Boolean destroy)
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
                    TapCount += 1;
                }
            }
        }
    }

    void beatHealth()
    {
        if(TapCount == BeatTaps)
        {
            ScoreCount.score += 2;

            Destroy(this.gameObject);
        
        }
    }

}
