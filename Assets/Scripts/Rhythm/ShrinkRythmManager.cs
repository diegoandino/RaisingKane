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

	public int index = 0;
    public List<float> BeatList;
    //beats.x is the delay between beats
    //beats.y is the shrink speed modifier 

    private bool isPlaying = false;
	private bool played = false;

    private Transform[] circles;
    private List<string> Score;

	public float largestDis;
	public float bigDis;
	public float mediumDis;
	public float smallestDis;

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
		timer = delay + shrinkTime;
	}

	// Update is called once per frame
	void FixedUpdate()
    {
		if (!isPlaying && !played)
		{
				Music.PlayDelayed(delay);
				isPlaying = true;
		}

        if (isPlaying)
		{
			localTime += Time.fixedDeltaTime;
		}

		if (localTime >= timer && isPlaying)
        {

            GameObject circle = Instantiate(ShrinkingCircle,this.gameObject.transform);

            circle.GetComponent<ShrinkingRythm>().shrinkMod = 0.1f;

			timer = BeatList[index] + delay + shrinkTime;


            if (index >= BeatList.Count-1)
			{
				timer = 100000;
				played = true;
				isPlaying = false;
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
                DisCheck(circles[2].localScale.x);

                circles[2].GetComponent<ShrinkingRythm>().ButtonPressed();
            }
        }


		if (Input.GetKeyDown(KeyCode.W))
		{
			print(Music.time);
		}

        //WinState();
        //LoseState();
        if (played && Score.Count == BeatList.Count)
		{
			EndState();
		}

    }

    //-- Checks distance between circle objects --//
    public bool DisCheck(float dis)
    {

		if (dis > mediumDis && dis < bigDis)
		{
			Score.Add("Perfect");
			StartCoroutine(BlinkRoutine(Color.green));
			return true;
		} else if ( dis > smallestDis && dis < largestDis)
		{
			Score.Add("Good");
			StartCoroutine(BlinkRoutine(Color.yellow));
			return true;
		} else
		{
			Score.Add("Bad");
			StartCoroutine(BlinkRoutine(Color.red));
			return true;
		}
	}


    //-- Color change in between button triggers --//
    IEnumerator BlinkRoutine(Color FlashColor)
    {
        Image Renderer = GuideCircle.GetComponent<Image>();
        bool IsBlinking = false;

        float StartTime = Time.time;
        float BlinkTimer = 0.5f;

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


	public void EndState()
	{
		float PerfectCount = 0;
		float GoodCount = 0;
		float BadCount = 0;

		foreach (string str in Score)
		{
			if (str == "Bad")
			{
				BadCount++;
			}
			if (str == "Good")
			{
				GoodCount++;
			}
			if (str == "Perfect")
			{
				PerfectCount++;
			}
		}
        if (GoodCount+PerfectCount >= 8)
		{
			SceneManager.LoadScene("Boss2");
		} else
		{
			SceneManager.LoadScene("Overworld_Move"); 
		}
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

    /*
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
        if (BadCount() >= 400)
        {
			SceneManager.LoadScene("Overworld_Move");
        }

       /* print("Object was null. . .");

        GameObject rhythm = Instantiate(this.gameObject);

        rhythm.SetActive(true); 
    }*/

		IEnumerator Wait(float time)
    {
        Debug.Log("Waiting before restarting. . .");

        yield return new WaitForSeconds(time);

        Debug.Log("3 seconds waited. . .");
    }
}
