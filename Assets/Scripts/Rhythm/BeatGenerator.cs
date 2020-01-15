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

	//-- Transform Positions and Position Array --//
	float pos1 = -3.115001f;
	float pos2 = -0.7399999f;
	float pos3 = 1.618872f;
	float pos4 = -4.31f;

	private float[] posArr;
	//-----------------------------------------//


	// Start is called before the first frame update
	void Start()
	{
		boss2 = GetComponent<AudioSource>();

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

		if (randVal < .45f) 
		{
			GameObject beat = Instantiate(beatPrefab, new Vector3(posArr[(int)randPos], beatPositionY, 0f), Quaternion.AngleAxis(90, Vector3.forward));
		}

		else if (randVal < .9f) 
		{
			GameObject beat = Instantiate(beatPrefab, new Vector3(posArr[(int)randPos], beatPositionY, 0f), Quaternion.AngleAxis(90, Vector3.forward));
		}

		else 
		{
			GameObject beat = Instantiate(badBeat, new Vector3(posArr[(int)randPos], beatPositionY, 0f), Quaternion.AngleAxis(90, Vector3.forward));
		}
	}
}