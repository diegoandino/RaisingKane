using UnityEngine;

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
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class OverwoldMusicManager : MonoBehaviour
//{

//    public float defaultMusicValue;
//    private AudioSource audioSrc;
//    private float musicVolume = 0.5f;

//    // Start is called before the first frame update
//    void Start()
//    {
//        audioSrc = GetComponent<AudioSource>();
//        audioSrc.volume = musicVolume;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//    }

//    //
//    void Awake()
//    {
//        this.gameObject.GetComponent<AudioSource>().volume = defaultMusicValue;

//        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

//        if (objs.Length > 1)
//        {
//            Destroy(this.gameObject);
//        }

//        DontDestroyOnLoad(this.gameObject);
//    }

//    public void SetVolume(float vol)
//    {
//        musicVolume = vol;
//    }
//}
