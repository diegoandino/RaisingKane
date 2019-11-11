using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    GameObject rhythmInstance;
    Movement_Test movementScript;

    //able to dictate where prefab spawns
    public float xLocation;
    public float yLocation;

    public GameObject rhythmMechanic;
    public Sprite Meditate;
    public Sprite OlderKane;
    public GameObject Player;
    private bool collided; //bool for if we have collided with a door

    // Start is called before the first frame update
    void Start()
    {
        rhythmInstance = (GameObject) Instantiate(rhythmMechanic);
        rhythmInstance.SetActive(false);
		rhythmInstance.GetComponent<RectTransform>().transform.position = new Vector3(xLocation, yLocation, 0);
		movementScript = GetComponent<Movement_Test>();
    }

    // Update is called once per frame
    void Update()
    {
        //if we have collided with a door
        if (collided == true)
        {
            //start rhythm game
            rhythmInstance.SetActive(true);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Meditate;
        }

        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = OlderKane;
        }
    }


    //-- On Trigger Update -- //
    void OnTriggerStay2D(Collider2D collision)
    {
        gameFlow(collision);
    }


    //-- Transitions between movement and Rhythm Mechanic --//
    void gameFlow(Collider2D collision)
    {
        //Debug.Log("entered trigger");
        if (collision.gameObject.tag == "Door")
        {
            print("collision with door detected");

            collided = true;
            movementScript.speed = 0;
        }
    }
}
