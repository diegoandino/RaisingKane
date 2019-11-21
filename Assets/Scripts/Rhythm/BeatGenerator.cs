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
  2.159456f,
  3.506213f,
  4.94585f,
  5.34059f,
  5.712109f,
  6.455147f,
  7.732245f,
  9.102222f,
  10.49542f,
  10.86694f,
  11.23846f,
  12.60844f,
  13.37469f,
  16.11465f,
  16.78803f,
  17.48463f,
  17.87937f,
  18.25089f,
  18.92426f,
  20.27102f,
  21.66422f,
  22.03574f,
  22.43048f,
  23.75401f,
  24.40417f,
  27.23701f,
  27.58531f,
  27.93361f,
  28.65342f,
  29.37324f,
  30.00018f,
  31.43982f,
  32.85624f,
  33.18132f,
  33.55283f,
  34.29587f,
  34.99247f,
  35.64263f
 };

	//travel time is how far the spawned beat is away from the target
	public float travelTime = 5.295986f;
	public float songTime;
	AudioSource boss2;

	//public float testBeat;

	public GameObject beatPrefab;
	public bool bossAttack;

	//checked for each beat needing to be spawned
	public bool start;

	//-- Transform Positions and Position Array --//
	float pos1 = -1.52f;
	float pos2 = -2.45f;
	float pos3 = -3.38f;
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

		Instantiate(beatPrefab, new Vector3(2.53f, posArr[(int)randPos], 0f), Quaternion.identity);
	}
}