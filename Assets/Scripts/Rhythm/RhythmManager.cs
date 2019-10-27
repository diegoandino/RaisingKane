using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq; 

[RequireComponent (typeof(AudioSource))]
public class RhythmManager : MonoBehaviour
{
    // Actual music source //
    public AudioSource audioSource;
    public static float[] SAMPLES = new float[512];
    public static float[] FREQ_BANDS = new float[8]; 





    // -- Start of Game Load -- //
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }


    // -- Updates every frame -- //
    void Update()
    {
        GetSprectrumAudioSource();
        MakeFrequencyBands(); 
    }





    // -- Loads audio into the game --  // 
    public void setMusic(AudioSource src)
    {
        this.audioSource = src;
    }

    private void syncBeats(AudioSource src)
    {
        setMusic(src);

        // -- Figure out how to sync beats of a song to in-game prompts -- //
    }

    // -- Gets Spectrum Source from audio using FFT -- // 
    void GetSprectrumAudioSource()
    {
        audioSource.GetSpectrumData(SAMPLES, 0, FFTWindow.Blackman); 
    }


    // -- Makes frequency bands for audio visualizing -- // (TEST . . .)
    void MakeFrequencyBands()
    {
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float AVERAGE = 0;
            int SAMPLE_COUNT = (int)Mathf.Pow(2 , i) * 2;

            if (i == 7)
               SAMPLE_COUNT += 2;

            for (int j = 0; j < SAMPLE_COUNT; j++)
            {
                AVERAGE = SAMPLES[count] * (count + 1);
                count++;
            }

            AVERAGE /= count;

            FREQ_BANDS[i] = AVERAGE * 10; 
        }
    }
}
