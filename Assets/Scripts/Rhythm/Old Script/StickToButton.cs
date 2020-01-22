using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the speed of the projectiles.
/// </summary>
public class StickToButton : MonoBehaviour
{
    public float BPM = 86;           //Tells how fast the rhythm is going. (BPM - Beats per minute) 
    private float _bpmReference;
    public bool hasStarted;     //If gameplay has started 
    public GameObject button;
    private bool isWaiting;

    // Start is called before the first frame update
    void Start()
    {
        BPM = BPM / 60f;        //I believe this is the tempo / by 60 seconds to make it a minute.
        _bpmReference = BPM;
        isWaiting = false; 
    }

    // Update is called once per frame
    void Update()
    {
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
}
