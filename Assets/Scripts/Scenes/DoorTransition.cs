using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorTransition : MonoBehaviour
{
	public string NextRoom;
	public GameObject RhythmMechanic;

	GameObject rhythmInstance;
	bool AtDoor = false;

	// Start is called before the first frame update
	void Start()
    {
        rhythmInstance = (GameObject) Instantiate(RhythmMechanic);
		rhythmInstance.SetActive(false);
		rhythmInstance.transform.GetChild(0).position = Camera.main.WorldToScreenPoint(this.transform.position);
		rhythmInstance.transform.GetChild(0).GetComponent<ShrinkRythmManager>().NextScene = NextRoom;
	}

	// Update is called once per frame
	void Update()
    {
        
    }

    public void startRhythm()
	{
		rhythmInstance.SetActive(true);
	}
}
