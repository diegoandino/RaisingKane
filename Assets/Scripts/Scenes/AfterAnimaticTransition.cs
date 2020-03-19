using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class AfterAnimaticTransition : MonoBehaviour
{
    private VideoPlayer animatic;
    public string NextRoom;

    private float timer;

    void Awake()
    {
            GameObject OverworldMusic = GameObject.FindGameObjectWithTag("Music");
            if (OverworldMusic != null)
            {
                OverworldMusic.GetComponent<AudioSource>().volume = 0;
            }
        animatic = GetComponent<VideoPlayer>();
        animatic.loopPointReached += vidDone; // loopPointReached is the event for the end of the video
    }

    private void Update()
    {

        if (Input.anyKey)
        {
            timer += Time.deltaTime;
        } else
        {
            timer = 0;
        }

        if (timer > 3)
        {
            SceneManager.LoadScene(NextRoom);
        }
    }

    void vidDone(VideoPlayer player)
    {
        Debug.Log("Event for movie end called");
        //player.Stop();
        SceneManager.LoadScene(NextRoom);
    }
}
