using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("entered trigger");
        if (collision.gameObject.tag == "Door")
        {
            Debug.Log("collision with door detected");
            if(Input.GetKey(KeyCode.E))
            {
                Debug.Log("player is interacting with this door, insert rhythm game here");
                Debug.Log("after winning, more player to next room");
            }
        }
    }
}
