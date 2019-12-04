using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissCount : MonoBehaviour
{
	public static int miss = 0;
	Text missScore;

	// Start is called before the first frame update
	void Start()
	{
		missScore = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update()
	{
		missScore.text = "Miss: " + miss;
	}
}
