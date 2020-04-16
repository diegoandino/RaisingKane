using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTransition : MonoBehaviour
{
    public string NextScene;
    bool PlayerHere;
    

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHere = false;
        anim = GameObject.Find("TransitionPanel").GetComponent<Animator>();
        MonsterCheck();
        BossLock();

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHere && Input.GetAxisRaw("Submit")>0)
        {
            StartCoroutine(LoadSceneAFterTransition()); 
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Player")
        {
            PlayerHere = true;
        }
	}

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHere = false;
        }
    }

    private IEnumerator LoadSceneAFterTransition()
    {
        //show animate out animation
        anim.SetBool("AnimateOut", true);
        yield return new WaitForSeconds(1f);
        //load the scene we want
        SceneManager.LoadScene(NextScene);
    }

    void MonsterCheck()
    {
        BossTracker tracker = GameObject.FindGameObjectWithTag("Music").GetComponent<BossTracker>();
        if (this.name == "Monster 1" && tracker.Boss1Finished)
        {
            this.gameObject.SetActive(false);
        }
        if (this.name == "Monster 2" && tracker.Boss2Finished)
        {
            this.gameObject.SetActive(false);
        }
        if (this.name == "Monster 3" && tracker.Boss3Finished)
        {
            this.gameObject.SetActive(false);
        }

    }

    void BossLock()
    {
        BossTracker tracker = GameObject.FindGameObjectWithTag("Music").GetComponent<BossTracker>();
        if(SceneManager.GetActiveScene().name == "DR2" && !tracker.Boss1Finished && this.name != "Monster 1")
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (SceneManager.GetActiveScene().name == "LR2" && !tracker.Boss2Finished && this.name != "Monster 2")
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
