using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    GameObject instance;
    public GameObject player;
    public GameObject rhythmMechanic;
    private bool collided;
    Movement movementScript;
    private ShrinkRythmManager shrinkManager;

    // Start is called before the first frame update
    void Start()
    {
        instance = (GameObject) Instantiate(rhythmMechanic);
        instance.SetActive(false);

        movementScript = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collided == true)
        {
            instance.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        gameFlow(collision);
    }

    void gameFlow(Collider2D collision)
    {
        //Debug.Log("entered trigger");
        if (collision.gameObject.tag == "Door" && Application.isPlaying == true)
        {
            print("collision with door detected");

            collided = true;
            movementScript.moveSpeed = 0;
        }
    }
}
