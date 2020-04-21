using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//-- This Class generates beats in different positions using random Array positions --//
public class BeatGeneratorTest : MonoBehaviour
{
	[System.Serializable]
	public struct BeatItem
	{
		public float SpawnTimer;
		public int Row;
		public int BeatType; //1 for Basic, 2 for Sticky, 3 For Bouncy, 4 for Muliti

		public BeatItem(float ST, int R, int BT)
		{
			SpawnTimer = ST;
			Row = R;
			BeatType = BT;
		}

	};

	//-- Float Array of logged distances for the beats --//
	public BeatItem[] beatLog = new BeatItem[]
		{
			new BeatItem (1,1,1)
		};

	//travel time is how far the spawned beat is away from the target
	//public float travelTime;
	public float songTime;
	AudioSource boss2;

	//Next Room
	public string NextRoom;

	public GameObject BasicBeat;
	public GameObject StickBeat;
	public GameObject BouncBeat;
	public GameObject MultiTapBeat;

	Animator anim;


	public bool bossAttack;

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
		start = true;
	}


	// Update is called once per frame
	void Update()
	{
		songTime = boss2.time;

		if (Input.anyKeyDown && start)
		{
			start = false;
			for (int i = 0; i < beatLog.Length; i++)
			{
				StartCoroutine(SpawnBeat(beatLog[i]));
			}
		}
	}


	private IEnumerator EndSong()
	{
		GameObject[] activeBeats;
        activeBeats = GameObject.FindGameObjectsWithTag("Beat");
        
		while (activeBeats.Length > 0)
		{
			activeBeats = GameObject.FindGameObjectsWithTag("Beat");
			yield return null;
		}

        if (GameObject.FindGameObjectsWithTag("Music").Length > 0)
        {
			BossTracker tracker = GameObject.FindGameObjectWithTag("Music").GetComponent<BossTracker>();
			if (SceneManager.GetActiveScene().name == "Boss_1_Sticky") { tracker.Boss1Finished = true; }
			if (SceneManager.GetActiveScene().name == "Boss_2_Bounce") { tracker.Boss2Finished = true; }
			if (SceneManager.GetActiveScene().name == "Boss_3_Multi") { tracker.Boss3Finished = true; }
		}

        StartCoroutine(LoadSceneAFterTransition());
		
	}

	private IEnumerator LoadSceneAFterTransition()
	{
		//show animate out animation
		anim = GameObject.Find("TransitionPanel").GetComponent<Animator>();
		anim.SetBool("AnimateOut", true);
		yield return new WaitForSeconds(1f);
		//load the scene we want
		SceneManager.LoadScene(NextRoom);

	}

	private IEnumerator SpawnBeat(BeatItem beat)
	{

		yield return new WaitForSeconds(beat.SpawnTimer);

        //Basic Beat
		if (beat.BeatType == 1)
		{
			if (beat.Row == 1)
			{
				GameObject NewBeat = Instantiate(BasicBeat, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(180, Vector3.forward));
                NewBeat.GetComponent<ArchProjectile>().EndPoint = Button1Pos.position;
			}
			else if (beat.Row == 2)
			{
				GameObject NewBeat = Instantiate(BasicBeat, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(180, Vector3.forward));
				NewBeat.GetComponent<ArchProjectile>().EndPoint = Button2Pos.position;
			}
			else if (beat.Row == 3)
			{
				GameObject NewBeat = Instantiate(BasicBeat, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(180, Vector3.forward));
				NewBeat.GetComponent<ArchProjectile>().EndPoint = Button3Pos.position;
			}
		}
        //Sticky Beat
        else if (beat.BeatType == 2)
		{
			if (beat.Row == 1)
			{
				GameObject NewBeat = Instantiate(StickBeat, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(180, Vector3.forward));
				NewBeat.GetComponent<StickyProjectile>().EndPoint = Button1Pos.position;
				NewBeat.GetComponent<StickyProjectile>().DestinationButton = Button1Pos.gameObject;

			}
			else if (beat.Row == 2)
			{
				GameObject NewBeat = Instantiate(StickBeat, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(180, Vector3.forward));
				NewBeat.GetComponent<StickyProjectile>().EndPoint = Button2Pos.position;
				NewBeat.GetComponent<StickyProjectile>().DestinationButton = Button2Pos.gameObject;
			}
			else if (beat.Row == 3)
			{
				GameObject NewBeat = Instantiate(StickBeat, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(180, Vector3.forward));
				NewBeat.GetComponent<StickyProjectile>().EndPoint = Button3Pos.position;
				NewBeat.GetComponent<StickyProjectile>().DestinationButton = Button3Pos.gameObject;
			}
		}
        //Bounce Beat
        else if (beat.BeatType == 3)
		{
			if (beat.Row == 1)
			{
				GameObject NewBeat = Instantiate(BouncBeat, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(180, Vector3.forward));
				NewBeat.GetComponent<BounceProjectile>().EndPoint = Button1Pos.position;
			}
			else if (beat.Row == 2)
			{
				GameObject NewBeat = Instantiate(BouncBeat, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(180, Vector3.forward));
				NewBeat.GetComponent<BounceProjectile>().EndPoint = Button2Pos.position;
			}
			else if (beat.Row == 3)
			{
				GameObject NewBeat = Instantiate(BouncBeat, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(180, Vector3.forward));
				NewBeat.GetComponent<BounceProjectile>().EndPoint = Button3Pos.position;
			}
		}
        //Multi Beat
        else if (beat.BeatType == 4)
		{
			if (beat.Row == 1)
			{
				GameObject NewBeat = Instantiate(MultiTapBeat, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(180, Vector3.forward));
				NewBeat.GetComponent<MultiTapProjectile>().EndPoint = Button1Pos.position;
			}
			else if (beat.Row == 2)
			{
				GameObject NewBeat = Instantiate(MultiTapBeat, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(180, Vector3.forward));
				NewBeat.GetComponent<MultiTapProjectile>().EndPoint = Button2Pos.position;
			}
			else if (beat.Row == 3)
			{
				GameObject NewBeat = Instantiate(MultiTapBeat, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(180, Vector3.forward));
				NewBeat.GetComponent<MultiTapProjectile>().EndPoint = Button3Pos.position;
			}
		}
        //End Song
        else if (beat.BeatType == 5)
        {
			StartCoroutine(EndSong());
        }
	}
}