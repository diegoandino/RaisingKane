using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTransition : MonoBehaviour
{
    public string NextScene;

    Animator anim;
    GameObject Transition;

    // Start is called before the first frame update
    void Start()
    {
        Transition = GameObject.Find("TransitionPanel");
        anim = Transition.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(LoadSceneAFterTransition()); 
        }
	}

    private IEnumerator LoadSceneAFterTransition()
    {
        //show animate out animation
        Transition.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(this.transform.position);
        anim.SetBool("AnimateOut", true);
        yield return new WaitForSeconds(1f);
        //load the scene we want
        SceneManager.LoadScene(NextScene);
    }

}
