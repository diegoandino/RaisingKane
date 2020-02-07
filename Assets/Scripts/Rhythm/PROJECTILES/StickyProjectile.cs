using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyProjectile : ArchProjectile
{
    bool frozen = false;
    public float freezeTime = 4;
    public GameObject DestinationButton;

    void Start()
    {
        this.SetPoints();
       
    }

    // Update is called once per frame
    void Update()
    {
		if (!frozen)
		{
            this.ArchMove();
        }
        beatCheck(true);
        MissCheck(true);
    }

    public IEnumerator FreezeButton()
	{
        frozen = true;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        DestinationButton.GetComponent<Collider2D>().enabled = false;
        DestinationButton.GetComponent<SpriteRenderer>().color = Color.black;
        yield return new WaitForSeconds(freezeTime);
        DestinationButton.GetComponent<Collider2D>().enabled = true;
        DestinationButton.GetComponent<SpriteRenderer>().color = Color.white;
        Destroy(this.gameObject);
        frozen = false;
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
                        Debug.Log("Sticky Hit");
                        musicManager.Playsound("implode");
                        StartCoroutine(FreezeButton());
                    }
                }
            }   
    }

    public void MissCheck(Boolean destroy)
    {

        if (transform.position.y < (button2.position.y - 3))
        {
            //MissCount.miss++; //Increments the Miss count on GUI
            print("Miss");
            if (destroy == true)
                Destroy(this.gameObject);
            else
                destroy = false;
        }
    }

}
