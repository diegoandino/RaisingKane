using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-- This Class generates beats in different positions using random Array positions --//
public class BeatGenerator : MonoBehaviour
{
    //-- Float Array of logged distances for the beats --// 
	public float[] beatLog = new float[]
	{
  0.9055783f,
  15.34059f
 };

	//travel time is how far the spawned beat is away from the target
	public float travelTime = 5.295986f;
	public float songTime;
	AudioSource boss2;

	public GameObject beatPrefab;
	public GameObject badBeat;
	public bool bossAttack;
    public float beatPositionY;

	//checked for each beat needing to be spawned
	public bool start;

    //Transform 
	public Transform Button1Pos;
	public Transform Button2Pos;
	public Transform Button3Pos;

	// Start is called before the first frame update
	void Start()
	{
		boss2 = GetComponent<AudioSource>();
	}


	// Update is called once per frame
	void Update()
	{
		songTime = boss2.time;

		if (Input.GetKeyDown(KeyCode.Space) && start)
		{
			start = false;

	
			for (int i = 0; i < beatLog.Length; i++)
			{
                Invoke("beatCreation", beatLog[i]);
            }
		}
	}


    //-- This function generates beats in the different locations individually and randomly --//
	void beatCreation()
	{
		float randPos = Random.Range(0f, 3f);
		float randVal = Random.value; 

		if (randVal < .25f) 
		{
			GameObject beat = Instantiate(beatPrefab, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(90, Vector3.forward));
            //Change the lane speed for left lane
            //beat.GetComponent<BP2_RhythmSpeed>().laneSpeed = 1f;
			beat.GetComponent<BP2_RhythmSpeed>().EndPoint = Button1Pos.position;

		}

		else if (randVal < .65f) 
		{
			GameObject beat = Instantiate(beatPrefab, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(90, Vector3.forward));
            //Change the lane speed for center lane
            //beat.GetComponent<BP2_RhythmSpeed>().laneSpeed = 1f;
			beat.GetComponent<BP2_RhythmSpeed>().EndPoint = Button2Pos.position;

		}

		else  if (randVal <.9f)
		{
			GameObject beat = Instantiate(beatPrefab, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(90, Vector3.forward));
            //Change the lane speed for right lane
            //beat.GetComponent<BP2_RhythmSpeed>().laneSpeed = 1f;
			beat.GetComponent<BP2_RhythmSpeed>().EndPoint = Button3Pos.position;
		}

        else
		{
			//GameObject beat = Instantiate(badbeat, new Vector3(posArr[(int)randPos], beatPositionY, 0f), Quaternion.AngleAxis(90, Vector3.forward));
		}
	}
}