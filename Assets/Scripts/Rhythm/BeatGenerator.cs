using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-- This Class generates beats in different positions using random Array positions --//
public class BeatGenerator : MonoBehaviour
{
    //-- Float Array of logged distances for the beats --// 
	public float[] beatLog = new float[]
	{
		0.04798186f,
		0.8693424f,
		1.573333f,
		2.277347f,
		3.002676f,
		3.664014f,
		4.389342f,
		5.114671f,
		5.456009f,
		5.776009f,
		6.458685f,
		7.141338f,
        7.845352f,
		8.570681f,
        9.232018f,
        9.936009f,
        10.61868f,
        10.96f,
        11.30134f,
        11.47202f,
        12.02667f,
        12.70934f,
        13.41333f,
        14.13869f,
        14.84268f,
        15.54667f,
        16.25068f,
        16.57068f,
        16.91202f,
        17.63735f,
        18.32f,
        19.00268f,
        19.68535f,
        20.38934f,
        21.11467f,
        21.73333f,
        22.11735f,
        22.50134f,
        23.16268f,
        23.84535f,
        24.57068f,
        25.29601f,
        25.46667f,
        26f,
        26.55467f,
        27.38667f,
        27.74934f,
        28.11202f,
        28.79467f,
        29.47735f,
        30.20267f,
        30.88535f,
        31.58934f,
        32.25068f,
        32.95467f,
        33.33868f,
        33.68f,
        34.40535f,
        35.08801f,
        35.77068f
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
		posArr = new float[4];

        //Sets positions for Array indexes
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