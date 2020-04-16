/*using UnityEngine;

public class OverwoldMusicManager : MonoBehaviour
{
    
    private AudioSource audioSrc;
    public static float musicVolume = 1f;
    
    void Start()
    {
        
        audioSrc = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        audioSrc.volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverwoldMusicManager : MonoBehaviour
{

    private AudioSource audioSrc;
    private float musicVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = musicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Boss_1_Sticky" || SceneManager.GetActiveScene().name == "Boss_2_Bounce" || SceneManager.GetActiveScene().name == "Boss_3_Multi"
            || SceneManager.GetActiveScene().name == "Boss_Final")
        {
            //print("Boss Scene");
            //audioSrc.volume -= 0.01f;
            return;
        } else
        {
            audioSrc.volume = musicVolume;
        }


    }

    //
    void Awake()
    {
        this.gameObject.GetComponent<AudioSource>().volume = musicVolume;

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

      public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
