using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement_Test : MonoBehaviour
{
    public float speed;
    
    [System.NonSerialized]
    public Vector2 movement;
    public GameObject Door;

    private SceneSwitcher sceneSwitch;
    private Rigidbody2D rb;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;

        Door = GameObject.FindWithTag("Door");
        sceneSwitch = GetComponent<SceneSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Door == null)
        {
            speed = 6;
            SceneManager.LoadScene("Boss2");
        }
    }

    //-- Moves the character --//
    void Move()
    {     
        if (Input.GetAxis("Horizontal") > 0)    //&& checkEdge2(new Vector2(7.5f, -3.5f)))
        {
            movement.x = speed;

            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetAxis("Horizontal") < 0)    // && checkEdge(new Vector2(-7.5f, -1.5f)))
        {
            movement.x = -speed;

            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetAxis("Vertical") > 0)      // && checkEdge(new Vector2(-7.5f, -1.5f)))
        {
            movement.y = speed;
        }

        if (Input.GetAxis("Vertical") < 0)      // && checkEdge2(new Vector2(7.5f, -3.5f)))
        {
            movement.y = -speed;
        }

        if (Input.GetAxis("Vertical") == 0)     // && checkEdge2(new Vector2(7.5f, -3.5f)))
        {
            movement.y = 0;
        }

        if (Input.GetAxis("Horizontal") == 0)   // && checkEdge2(new Vector2(7.5f, -3.5f)))
        {
            movement.x = 0;
        }

        rb.velocity = movement;
    }


    //-- Gets Character Speed --//
    public float GetSpeed()
    {
        return Input.GetAxis("Horizontal") * speed;
    }
}
