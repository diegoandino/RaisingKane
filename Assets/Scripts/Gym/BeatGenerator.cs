using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BeatGenerator : MonoBehaviour
{
    public float[] beatLog = new float[]
    {0.8479819f, 1.535986f, 2.223991f, 2.943991f, 3.663991f, 4.351995f, 5.039978f, 5.727982f, 6.431995f, 7.135986f, 7.823991f, 8.511995f, 9.231996f, 9.951996f, 10.62399f, 11.29599f, 11.632f, 11.99998f, 12.87998f, 13.05599f, 13.40798f,
    14.12798f, 14.46399f, 14.81599f, 15.66399f, 15.85599f, 16.20798f, 16.89599f, 17.24798f, 17.59998f, 18.44798f, 18.63998f, 18.95998f, 19.67998f, 20.04798f, 20.38399f, 21.24798f, 21.42399f, 21.792f, 22.46399f, 22.78399f, 22.89599f, 23.00798f, 23.15199f,
    23.53599f, 24.06399f, 24.20798f, 24.57599f, 25.26399f, 25.632f, 25.74399f, 25.85599f, 25.98399f, 26.31998f, 26.832f, 27.00798f, 27.37599f, 27.712f, 28.04798f, 28.39998f, 28.512f, 28.60798f, 28.752f, 29.08798f, 29.632f, 29.82399f, 30.17599f, 30.47998f,
    30.832f, 31.18399f, 31.29599f, 31.42399f, 31.56798f, 31.872f, 32.41599f, 32.57598f, 32.95998f, 33.29599f, 33.632f, 34.30399f, 34.97599f, 35.69599f};

    //trvael time is how far the spawned beat is away from the target
    public float travelTime = 5.295986f;
    public float songTime;
    AudioSource boss2;
    //public float testBeat;
    public GameObject beatPrefab;

    //checked for each beat needing to be spawned
    public bool start;
    



    // Start is called before the first frame update
    void Start()
    {
        boss2 = GetComponent<AudioSource>();
        start = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        songTime = boss2.time;

        if (Input.GetKeyDown(KeyCode.Space) && start)
        {
            start = false;
            Invoke("beatCreation", 0.04798186f);
            Invoke("beatCreation", 0.7999773f);
            Invoke("beatCreation", 1.503991f);
            Invoke("beatCreation", 2.271996f);
            Invoke("beatCreation", 2.943991f);
            Invoke("beatCreation", 3.631995f);
            Invoke("beatCreation", 4.367982f);
            Invoke("beatCreation", 5.055986f);
            Invoke("beatCreation", 5.407982f);
            Invoke("beatCreation", 5.727982f);
            Invoke("beatCreation", 6.431995f);
            Invoke("beatCreation", 7.119977f);
            Invoke("beatCreation", 7.839977f);
            Invoke("beatCreation", 8.511995f);
            Invoke("beatCreation", 9.263991f);
            Invoke("beatCreation", 9.951996f);
            Invoke("beatCreation", 10.63998f);
            Invoke("beatCreation", 10.95998f);
            Invoke("beatCreation", 11.312f);
            Invoke("beatCreation", 11.632f);
            Invoke("beatCreation", 11.80798f);
            Invoke("beatCreation", 12.01599f);
            Invoke("beatCreation", 12.352f);
            Invoke("beatCreation", 12.87998f);
            Invoke("beatCreation", 13.05599f);
            Invoke("beatCreation", 13.40798f);
            

            // Instantiate(beatPrefab, new Vector3(2.53f, -2.46f, 0f), Quaternion.identity);
            // beat1 = false;

            //print("Object beat 1 Spawned");
            //print("boss2 time is" + boss2.time);
            //print("travel time is" + travelTime);
            //print("Test beat is " + testBeat);
        }
        
    }

    void beatCreation()
    {
        Instantiate(beatPrefab, new Vector3(2.53f, -2.46f, 0f), Quaternion.identity);
        //print("Object beat Spawned");
    }
    
}
