using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class ShrinkRythmManager: MonoBehaviour
{
    public GameObject ShrinkingCircle;
    public GameObject GuideCircle;
	public AudioSource Music;

    Movement movement;


    public float timer;
	public float localTime;
	public float delay;
	private float shrinkTime = -2.73998f;

    float DisToShrink;
	public int index = 0;
    public List<float> BeatList;
    //beats.x is the delay between beats
    //beats.y is the shrink speed modifier 

    private bool isPlaying = false;

    private Transform[] circles;
    private List<string> Score;

	public float PerfectDis;
	public float GoodDis;
	public float NormalDis;
	public float BadDis;

    [System.NonSerialized]
    public bool destroyed;
    public bool win;

    // Start is called before the first frame update
    void Start()
    {
        //Main Variable Starts
		index = 0;
        circles = new Transform[0];
        Score = new List<string>();
        destroyed = false;
        win = false;
        movement = GetComponent<Movement>();

        //Make object smaller Object
        this.gameObject.transform.localScale = new Vector3(0.6f,0.6f,0.6f);

        circles = GetComponentsInChildren<Transform>();
		DisToShrink = ShrinkingCircle.transform.localScale.x - circles[1].localScale.x;
		timer = delay + shrinkTime;
	}

	// Update is called once per frame
	void FixedUpdate()
    {
		if (!isPlaying)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Music.PlayDelayed(delay);
				isPlaying = true;
			}
		}

        if (isPlaying)
		{
			localTime += Time.fixedDeltaTime;
		}

		if (localTime >= timer)
        {

            GameObject circle = Instantiate(ShrinkingCircle,this.gameObject.transform);

            circle.GetComponent<ShrinkingRythm>().shrinkMod = 0.1f;

			timer = BeatList[index] + delay + shrinkTime;


            if (index >= BeatList.Count-1)
			{
				index = 0;
				timer = 1000003;
			}

            else
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

				print(circles[2].localScale.x - circles[1].localScale.x);
            }
        }


		if (Input.GetKeyDown(KeyCode.W))
		{
			print(Music.time);
		}

        WinState();
        LoseState();
    }

    //-- Checks distance between circle objects --//
    public void DisCheck(float dis)
    {
        if (dis < BadDis)
        {
            Score.Add("Bad");
            StartCoroutine(BlinkRoutine(Color.red));
        }

        else if (dis < PerfectDis)
        {
            Score.Add("Perfect!");
            StartCoroutine(BlinkRoutine(Color.green));
        }

        else if (dis < GoodDis)
        {
            StartCoroutine(BlinkRoutine(Color.blue));
            Score.Add("Good");
        }

		else if (dis < NormalDis)
		{
			StartCoroutine(BlinkRoutine(Color.yellow));
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
                //print("Your current score is: " + ScoreInt);
            }

            if(str == "Good")
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
        if (FindScore() >= 6)
        {
            //-- Changed it so it destroys once won --//
            this.gameObject.SetActive(false);

            win = true;
            destroyed = true;
            
            print("Win");

			SceneManager.LoadScene("Boss2");
        }
    }


    //-- Player Lose State --//
   public void LoseState()
    {
        if (BadCount() >= 4)
        {
			SceneManager.LoadScene("Overworld_Move");
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
