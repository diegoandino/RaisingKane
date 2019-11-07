using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCollision : MonoBehaviour
{

    public string roomName;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Do something else here");
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Player")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
            SceneManager.LoadScene(roomName, LoadSceneMode.Additive);
        }
    }
}
