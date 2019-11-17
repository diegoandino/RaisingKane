using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShrinkRythmManager: MonoBehaviour
{
    public GameObject ShrinkingCircle;
    public GameObject Door;
    public GameObject GuideCircle;

    Movement movement;


    public float timer;
	public int index = 0;
    public List<Vector2> BeatList;
    //beats.x is the delay between beats
    //beats.y is the shrink speed modifier 

    private Transform[] circles;
    private List<string> Score;
    private Collision coll;

    [System.NonSerialized]
    public bool destroyed;
    public bool win;

    // Start is called before the first frame update
    void Start()
    {
        //Main Variable Starts
        timer = BeatList[0].x;
		index = 0;
        circles = new Transform[0];
        Score = new List<string>();
        destroyed = false;
        win = false;
        movement = GetComponent<Movement>();

        //Find Door Object
        Door = GameObject.FindGameObjectWithTag("Door");

        //Make object smaller Object
        this.gameObject.transform.localScale = new Vector3(0.6f,0.6f,0.6f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        this.gameObject.transform.position = new Vector3(coll.xLocation, coll.yLocation, 0);

        if (timer <= 0)
        {

            GameObject circle = Instantiate(ShrinkingCircle,this.gameObject.transform);

            circle.GetComponent<ShrinkingRythm>().shrinkMod = BeatList[index].y;
			timer = BeatList[index].x;

            if (index >= BeatList.Count-1)
			{
				index = 0;
			} else
			{
				index += 1;
			}
        }


        circles = GetComponentsInChildren<Transform>();


        if (Input.GetKeyDown("space"))
        {
            if (circles.Length > 2)
            {
                DisCheck(circles[2].localScale.x - circles[1].localScale.x); 
                circles[2].GetComponent<ShrinkingRythm>().ButtonPressed();
            }
        }


        WinState();
        LoseState();
    }

    //-- Checks distance between circle objects --//
    public void DisCheck(float dis)
    {
        if (dis < -2)
        {
            Score.Add("Bad");
            StartCoroutine(BlinkRoutine(Color.red));
        }

        else if (dis < 1.5)
        {
            Score.Add("Perfect!");
            StartCoroutine(BlinkRoutine(Color.green));
        }

        else if (dis < 3)
        {
            StartCoroutine(BlinkRoutine(Color.blue));
            Score.Add("Good");
        }

        else
        {
            StartCoroutine(BlinkRoutine(Color.red));
            Score.Add("Bad");
        }
    }


    //-- Color change in between button triggers --//
    IEnumerator BlinkRoutine(Color FlashColor)
    {
        Image Renderer = GuideCircle.GetComponent<Image>();
        bool IsBlinking = false;

        float StartTime = Time.time;
        float BlinkTimer = 1;

        while (StartTime + BlinkTimer > Time.time)
        {
            IsBlinking = !IsBlinking;

            if (IsBlinking)
            {
                Renderer.color = Color.white;
            }

            else
            {
                Renderer.color = FlashColor;
            }
            yield return new WaitForSeconds(0.05f);
        }

        Renderer.color = Color.white;
    }


    //-- Finds and updates your current score --//
    public float FindScore()
    {
        float ScoreInt = 0;
        
        foreach (string str in Score)
        {
            if (str == "Bad" && ScoreInt > 0)
            {
                ScoreInt--;
                print("Your current score is: " + ScoreInt);
            }

            if(str == "Perfect!")
            {
                ScoreInt++;
                print("Your current score is: " + ScoreInt);
            }
        }

        return ScoreInt; 
    }


    //-- Counts how many bad triggers player had --//
    public float BadCount()
    {
        float Counter = 0;

        foreach (string str in Score)
        {
            if (str == "Bad")
            {
                Counter++;
            }
        }

        return Counter;
    }


    //-- Win Condition --//
   public void WinState()
    {
        if (FindScore() >= 3)
        {
            //-- Changed it so it destroys once won --//
            this.gameObject.SetActive(false);

            Destroy(Door);

            win = true;
            destroyed = true;
            
            print("Win");
        }
    }


    //-- Player Lose State --//
   public void LoseState()
    {
        if (BadCount() > 5)
        {
            this.gameObject.SetActive(false);

            StartCoroutine(Wait(3));
        }

       /* print("Object was null. . .");

        GameObject rhythm = Instantiate(this.gameObject);

        rhythm.SetActive(true); */
    }

    IEnumerator Wait(float time)
    {
        Debug.Log("Waiting before restarting. . .");

        yield return new WaitForSeconds(time);

        Debug.Log("3 seconds waited. . .");
    }
}
