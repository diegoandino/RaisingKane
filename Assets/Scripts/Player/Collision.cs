using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    GameObject rhythmInstance;
    Movement movementScript;
    GameObject player;

    //able to dictate where prefab spawns
    public float xLocation;
    public float yLocation;

    public GameObject rhythmMechanic;
    private bool collided; //bool for if we have collided with a door
    private ShrinkRythmManager shrinkManager;
    public string nextRoom;

    // Start is called before the first frame update
    void Start()
    {
        rhythmInstance = (GameObject) Instantiate(rhythmMechanic);
        rhythmInstance.SetActive(false);

        movementScript = GetComponent<Movement>();
        shrinkManager = GetComponent<ShrinkRythmManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if we have collided with a door
        if (collided == true)
        {
            //start rhythm game
            rhythmInstance.SetActive(true);
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
            movementScript.moveSpeed = 0;
        }

        else if (shrinkManager.win == true)
        {
            movementScript.moveSpeed = 6;
            Destroy(this);
        }
    }
}
