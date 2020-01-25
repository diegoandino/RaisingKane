using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class AfterAnimaticTransition : MonoBehaviour
{
    private VideoPlayer animatic;

    void Awake()
    {
        animatic = GetComponent<VideoPlayer>();
        animatic.loopPointReached += vidDone; // loopPointReached is the event for the end of the video
    }

    void vidDone(VideoPlayer player)
    {
        Debug.Log("Event for movie end called");
        //player.Stop();
        SceneManager.LoadScene("DR1");
    }
}
