using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    public static AudioClip plushFire, implode;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        plushFire = Resources.Load<AudioClip>("SFX_fire");
        implode = Resources.Load<AudioClip>("SFX_implode");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Playsound(string clip)
    {
        switch (clip)
        {
            case "plushFire":
                audioSrc.PlayOneShot(plushFire);
                break;
            case "implode":
                audioSrc.PlayOneShot(implode);
                break;
        }
    }
}

