using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverwoldMusicManager : MonoBehaviour
{

    public float defaultMusicValue;
    private AudioSource audioSrc;
    private float musicVolume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = musicVolume;
    }

    //
    void Awake()
    {
        this.gameObject.GetComponent<AudioSource>().volume = defaultMusicValue;

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
