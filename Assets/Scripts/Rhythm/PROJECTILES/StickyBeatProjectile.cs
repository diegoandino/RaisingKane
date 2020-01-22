using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/**
 * Controls the projectiles and their collisions
 */
public class StickyBeatProjectile : Projectile
{
    private bool normalHit;
    private bool goodHit;
    private bool perfectHit;
    private bool canBePressed; //If the button can be pressed or not. NOTE: Currently allows you not to miss early
    private bool pressed;
    private bool isWaiting;
    private float _bpmReference;

    public float BPM = 86;           //Tells how fast the rhythm is going. (BPM - Beats per minute) 
    public bool hasStarted;     //If gameplay has started 
  

    // Start is called before the first frame update
    void Start()
    {
        normalHit = false;
        goodHit = false;
        perfectHit = false;
        canBePressed = false;
        isWaiting = false;
        pressed = true;

        BPM = BPM / 60f;        //I believe this is the tempo / by 60 seconds to make it a minute.
        _bpmReference = BPM;
    }


    // Update is called once per frame
    void Update()
    {
        stickyBeatCheck();

        if (hasStarted)
        {
            //Vector3(x,y,z)
            //The function to move NoteObjects from left to right
            transform.position -= new Vector3(0f, (BPM * Time.deltaTime) * BP2_MusicSettings.instance.songSpeed, 0f);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Button" && BP2_ButtonControls.pressed == true)
        {
            BPM = 0f;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        isWaiting = true;  //set the bool to stop moving

        print("Start to wait");
        yield return new WaitForSeconds(3); //Wait for 3 seconds
        print("Wait complete");

        BPM = _bpmReference; //Set BPM back to normal

        isWaiting = false; // set the bool to start moving
    }

    /**
     * Checks for Beat position and key presses
     * Doesn't destroy objects ! ! ! 
     */
    void stickyBeatCheck()
    {

        if (Input.GetKeyDown(BP2_ButtonControls.staticKey))
        {
            if (canBePressed == true)
            {
                //Okay Check
                if (((transform.position.x > BP2_ButtonControls.ButtonPos + 0.15) || (transform.position.x < BP2_ButtonControls.ButtonPos - 0.15)))
                {
                    Debug.Log("Normal Hit");
                    musicManager.Playsound("implode");

                    normalHit = true; perfectHit = false; goodHit = false; pressed = true;

                    ScoreCount.score += 2;
                }

                //Good Check
                else if (((transform.position.x > BP2_ButtonControls.ButtonPos + 0.15) || (transform.position.x < BP2_ButtonControls.ButtonPos - 0.15)))
                {
                    Debug.Log("Good Hit");
                    musicManager.Playsound("implode");

                    // Destroy(this.gameObject);

                    normalHit = false; perfectHit = false; goodHit = true; pressed = true;

                    ScoreCount.score += 4;
                }

                //Perfect Check
                else
                {
                    Debug.Log("Perfect Hit");
                    // Destroy(this.gameObject);

                    musicManager.Playsound("implode");

                    normalHit = false; perfectHit = true; goodHit = false; pressed = true;

                    ScoreCount.score += 6;
                }
            }
        }
    }
}