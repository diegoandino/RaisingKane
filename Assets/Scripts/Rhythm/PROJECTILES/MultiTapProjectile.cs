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
        beatHealth();
    }

    new void BeatCheck(Boolean destroy)
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
                    TapCount += 1;
                    StartCoroutine(Hang());
                }
            }
        }
    }

    void beatHealth()
    {
        if(TapCount == BeatTaps)
        {
            ScoreCount.score += 2;
            StartCoroutine(DestroyBeat(0));
        }
    }

    IEnumerator Hang()
    {
        float previousSpeed = this.ProjectileSpeed;
        float prevDropSpeed = this.dropSpeed;
        this.ProjectileSpeed = 0f;
        Animator anim = this.GetComponent<Animator>();
        anim.SetBool("Hang", true);
        this.dropSpeed = 0f;
        yield return new WaitForSeconds(1); //Hold in place
        this.ProjectileSpeed = previousSpeed;
        this.dropSpeed = prevDropSpeed;
    }
}
