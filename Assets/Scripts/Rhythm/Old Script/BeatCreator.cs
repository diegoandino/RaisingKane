using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatCreator : MonoBehaviour
{
    //-- Main Variables --//
    public AudioSource boss2;
    public List<float> beatTime = new List<float>();
    public GameObject beatPrefab;

    public float songTime;
    public float log;

    public bool replay;
	//--------------------//


	//--Vector 3 Instantiantion Variables for location --//
	float pos1 = -1.52f;
	float pos2 = -2.45f;
	float pos3 = -3.38f;
	float pos4 = -4.31f;

	private float[] posArr;
	//---------------------------------------------------//

	// Start is called before the first frame update
	void Start()
    {
        boss2 = this.GetComponent<AudioSource>();
        replay = true;

		//Sets positions for Array indexes
		posArr = new float[4];

		posArr[0] = pos1;
		posArr[1] = pos2;
		posArr[2] = pos3;
		posArr[3] = pos4;
	}

    // Update is called once per frame
    void Update()
    {
        logger();

        if (Input.GetKeyDown(KeyCode.L) && replay)
        {
            boss2.Stop();
            replay = false;


            Invoke("playSong", 5.295986f);


            foreach (float logged in beatTime)
            {
                Invoke("beatCreation", logged);
            }

            //Logs beats as an Array then to strings so it's easier to capture as a whole array of floats//
			string loggedBeats = string.Join("f, ", beatTime.ToArray());
			Debug.Log(loggedBeats);
		}
    }


    public void playSong()
    {
        boss2.Play();
    }


    public void beatCreation()
    {
		float randPos = Random.Range(0f, 3f);

		Instantiate(beatPrefab, new Vector3(2.53f, posArr[(int)randPos], 0f), Quaternion.identity);
	}


    public void logger()
    {

        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log(boss2.time);
            songTime = boss2.time;
            boss2.Stop();
        }

        //resumes music at left off time
        if (Input.GetKeyDown(KeyCode.M))
        {
            boss2.time = songTime;
            boss2.Play();
        }

        //resets song and time log
        if (Input.GetKeyDown(KeyCode.B))
        {
            boss2.Stop();
            songTime = 0;
            boss2.time = songTime;
            boss2.Play();
        }

        // logs time without pausing
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log(boss2.time);
            songTime = boss2.time;
            log = songTime;
            beatTime.Add(log);
        }
    }
}
