using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShrinkRythmManager: MonoBehaviour
{
    public GameObject ShrinkingCircle;
    public GameObject GuideCircle;
    public float delay = 15;
    public float timer;
    public float speedModifier = 1;
    private Transform[] circles;
    private List<string> Score;
    [System.NonSerialized]
    public bool destroyed;

    // Start is called before the first frame update
    void Start()
    {
        timer = delay;
        circles = new Transform[0];
        Score = new List<string>();
        destroyed = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            GameObject circle = Instantiate(ShrinkingCircle,this.gameObject.transform);
            circle.GetComponent<ShrinkingRythm>().shrinkMod = speedModifier;
            timer = delay;
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
        //Win Condition
        if (FindScore() > 10)
        {
            Time.timeScale = 0;
            print("Win");

        }

        //Loss Condition
        if (BadCount() > 5)
        {
            loseState();
        }

    }

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
        } else
        {
            StartCoroutine(BlinkRoutine(Color.red));
            Score.Add("Bad");
        }
    }

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

    void loseState()
    {
        Destroy(this.gameObject);
        destroyed = true;
    }
}
