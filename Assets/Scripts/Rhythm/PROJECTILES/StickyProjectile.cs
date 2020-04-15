using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyProjectile : ArchProjectile
{
    bool frozen = false;
    public float freezeTime = 4;
    public GameObject DestinationButton;
    private Shake shake; 

    void Start()
    {
        this.SetPoints();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
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
        MissCheck(true);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        DestinationButton.GetComponent<Collider2D>().enabled = false;
        DestinationButton.GetComponent<SpriteRenderer>().color = Color.black;
        yield return new WaitForSeconds(freezeTime);
        MissCheck(false);
        DestinationButton.GetComponent<Collider2D>().enabled = true;
        DestinationButton.GetComponent<SpriteRenderer>().color = Color.white;
        Destroy(this.gameObject);
        frozen = false;
    }



    public void beatCheck(Boolean destroy)
	{
         if (Input.GetButtonDown(BP2_ButtonControls.staticButton))
            {
                if (canBePressed == true)
                {
                    //Okay Check
                    if (((transform.position.y > BP2_ButtonControls.ButtonPos + 0.25) || (transform.position.y < BP2_ButtonControls.ButtonPos - 0.25)))
                    {
                        //Debug.Log("Sticky Hit");
                        musicManager.Playsound("implode");

                        shake.shake();
                        StartCoroutine(FreezeButton());
                    }
                }
            }   
    }

    public new void MissCheck(Boolean destroy)
    {

        if (transform.position.y < (DestinationButton.transform.position.y -10))
        {
            //print("Miss");
            if (destroy == true)
            {
                meter.damage(1);
                Destroy(this.gameObject);
            }

            else destroy = false;
        }
    }

}
