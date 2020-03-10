using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverwoldMusicManager : MonoBehaviour
{

    public float defaultMusicValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
