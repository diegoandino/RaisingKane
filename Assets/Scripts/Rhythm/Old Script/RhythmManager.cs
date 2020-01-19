using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SynchronizerData;


//[RequireComponent (typeof(AudioSource))]
public class RhythmManager : MonoBehaviour
{
    public float bpm = 120f;        // Tempo in beats per minute of the audio clip.
    public float startDelay = 1f;   // Number of seconds to delay the start of audio playback.
    public delegate void AudioStartAction(double syncTime);
    public static event AudioStartAction OnAudioStart;


    void Start()
    {
        double initTime = AudioSettings.dspTime;


        GetComponent<AudioSource>().PlayScheduled(initTime + startDelay);
        if (OnAudioStart != null)
        {
            OnAudioStart(initTime + startDelay);
        }
    }


    void SyncAudio()
    {
        // -- Still studying methods to sync up beats with the BeatSychronizer classes (implementing at home on separate files . . .) -- //
    }
}