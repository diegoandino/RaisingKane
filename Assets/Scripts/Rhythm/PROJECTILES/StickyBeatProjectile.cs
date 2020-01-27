using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/**
 * Controls the projectiles and their collisions
 */
public class StickyBeatProjectile : Projectile
{

    private bool isWaiting;

    public float BPM = 86;           //Tells how fast the rhythm is going. (BPM - Beats per minute)
    public float dropSpeed;     //added Lanespeed for the different arcs of the lanes
    public float ProjectileSpeed;
    public float ArchMod; //Higher the Value, higher the arch;
    private float count = 0.0f;
    private List<Vector3> points;

    public bool hasStarted;     //If gameplay has started 
    public Vector3 StartPoint;
    public Vector3 EndPoint;

    // Start is called before the first frame update
    void Start()
    {
        SetPoints();
    }


    // Update is called once per frame
    void Update()
    {
        BeatCheck(false);
        ArchMove();
    }

    //Checks for specific buttons and their tags and starts coroutine
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Button1" && Input.GetKeyDown(KeyCode.A))
        {
            ProjectileSpeed = 0f;
            button1.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(Wait_A());
        }

        else if (other.tag == "Button2" && Input.GetKeyDown(KeyCode.S))
        {
            ProjectileSpeed = 0f;
            button2.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(Wait_S());
        }

        else if (other.tag == "Button3" && Input.GetKeyDown(KeyCode.D))
        {
            ProjectileSpeed = 0f;
            button3.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(Wait_D());
        }
    }

    //Coroutine for wait time after stick
    IEnumerator Wait_A()
    {
        isWaiting = true;  //set the bool to stop moving
        yield return new WaitForSeconds(4); //Wait for 4 seconds

        button1.GetComponent<Collider2D>().enabled = true;
        hasStarted = true;  // set the bool to start moving
        isWaiting = false;
    }


    //Coroutine for wait time after stick
    IEnumerator Wait_S()
    {
        isWaiting = true;  //set the bool to stop moving
        yield return new WaitForSeconds(4); //Wait for 4 seconds

        button2.GetComponent<Collider2D>().enabled = true;
        hasStarted = true;  // set the bool to start moving
        isWaiting = false;
    }


    //Coroutine for wait time after stick
    IEnumerator Wait_D()
    {
        isWaiting = true;  //set the bool to stop moving
        yield return new WaitForSeconds(4); //Wait for 4 seconds

        button3.GetComponent<Collider2D>().enabled = true;
        hasStarted = true;   // set the bool to start moving
        isWaiting = false;
    }


    /*
     * Had to re-import this function as well as set because it wasn't calling it correctly through inheritance.
     * Am looking into it and will refactor.
     */
    public void ArchMove()
    {
        if (hasStarted)
        {
            if (count < 1f)
            {
                count += ProjectileSpeed * Time.deltaTime;

                Vector3 m1 = Vector3.Lerp(points[0], points[2], count);
                Vector3 m2 = Vector3.Lerp(points[2], points[1], count);
                transform.position = Vector3.Lerp(m1, m2, count);

                // Determine which direction to rotate towards
                Vector3 targetDirection = m2 - transform.position;
                Quaternion rot = Quaternion.LookRotation(targetDirection, Vector3.up);
                Quaternion NewRot = Quaternion.identity;
                NewRot.eulerAngles = new Vector3(0, 0, (rot.eulerAngles.x - 90));
                transform.rotation = NewRot;

            }

            if (count > 1f)
            {
                transform.position -= new Vector3(0f, (BPM * Time.deltaTime) * BP2_MusicSettings.instance.songSpeed * dropSpeed, 0f);
                Quaternion downRot = Quaternion.identity;
                downRot.eulerAngles = new Vector3(0, 0, 0);
                transform.rotation = downRot;
            }
        }
    }


    public void SetPoints()
    {
        BPM = BPM / 60f;        //I believe this is the tempo / by 60 seconds to make it a minute.
        StartPoint = this.transform.position;
        points = new List<Vector3>();

        points.Add(new Vector3(StartPoint.x, StartPoint.y, 1));
        points.Add(new Vector3(EndPoint.x, EndPoint.y, 1));
        points.Add(points[0] + (points[1] - points[0]) / 2 + Vector3.up * ArchMod);
    }
}