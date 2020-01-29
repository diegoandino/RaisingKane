using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	public float travelTime = 5.295986f;
	public float songTime;
	AudioSource boss2;

	public GameObject BasicBeat;
	public GameObject StickBeat;
	public GameObject BouncBeat;
	public GameObject MultiTapBeat;

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
		//print(start);
		songTime = boss2.time;
		if (Input.GetKeyDown(KeyCode.Space) && start)
		{
			print("Test");
			start = false;
			for (int i = 0; i < beatLog.Length; i++)
			{
				StartCoroutine(SpawnBeat(beatLog[i]));
			}
		}
	}

	private IEnumerator SpawnBeat(BeatItem beat)
	{

		yield return new WaitForSeconds(beat.SpawnTimer);
		print(beat);

		if (beat.BeatType == 1)
		{
			if (beat.Row == 1)
			{
				GameObject NewBeat = Instantiate(BasicBeat, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(90, Vector3.forward));
				NewBeat.GetComponent<ArchProjectile>().EndPoint = Button1Pos.position;
			}
			else if (beat.Row == 2)
			{
				GameObject NewBeat = Instantiate(BasicBeat, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(90, Vector3.forward));
				NewBeat.GetComponent<ArchProjectile>().EndPoint = Button2Pos.position;
			}
			else if (beat.Row == 3)
			{
				GameObject NewBeat = Instantiate(BasicBeat, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(90, Vector3.forward));
				NewBeat.GetComponent<ArchProjectile>().EndPoint = Button3Pos.position;
			}
		}
		else if (beat.BeatType == 2)
		{
			if (beat.Row == 1)
			{
				GameObject NewBeat = Instantiate(StickBeat, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(90, Vector3.forward));
				NewBeat.GetComponent<ArchProjectile>().EndPoint = Button1Pos.position;
			}
			else if (beat.Row == 2)
			{
				GameObject NewBeat = Instantiate(StickBeat, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(90, Vector3.forward));
				NewBeat.GetComponent<ArchProjectile>().EndPoint = Button2Pos.position;
			}
			else if (beat.Row == 3)
			{
				GameObject NewBeat = Instantiate(StickBeat, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(90, Vector3.forward));
				NewBeat.GetComponent<ArchProjectile>().EndPoint = Button3Pos.position;
			}
		}
		else if (beat.BeatType == 3)
		{
			if (beat.Row == 1)
			{
				GameObject NewBeat = Instantiate(BouncBeat, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(90, Vector3.forward));
				NewBeat.GetComponent<ArchProjectile>().EndPoint = Button1Pos.position;
			}
			else if (beat.Row == 2)
			{
				GameObject NewBeat = Instantiate(BouncBeat, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(90, Vector3.forward));
				NewBeat.GetComponent<ArchProjectile>().EndPoint = Button2Pos.position;
			}
			else if (beat.Row == 3)
			{
				GameObject NewBeat = Instantiate(BouncBeat, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(90, Vector3.forward));
				NewBeat.GetComponent<ArchProjectile>().EndPoint = Button3Pos.position;
			}
		}
		else if (beat.BeatType == 4)
		{
			if (beat.Row == 1)
			{
				GameObject NewBeat = Instantiate(MultiTapBeat, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(90, Vector3.forward));
				NewBeat.GetComponent<ArchProjectile>().EndPoint = Button1Pos.position;
			}
			else if (beat.Row == 2)
			{
				GameObject NewBeat = Instantiate(MultiTapBeat, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(90, Vector3.forward));
				NewBeat.GetComponent<ArchProjectile>().EndPoint = Button2Pos.position;
			}
			else if (beat.Row == 3)
			{
				GameObject NewBeat = Instantiate(MultiTapBeat, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f), Quaternion.AngleAxis(90, Vector3.forward));
				NewBeat.GetComponent<ArchProjectile>().EndPoint = Button3Pos.position;
			}
		}

	}
}