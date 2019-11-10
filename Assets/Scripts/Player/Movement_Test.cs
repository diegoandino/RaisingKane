﻿using System.Collections;
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

    //public Animator animator;
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
            SceneManager.LoadScene("Overworld_Move");
        }
    }


    void Move()
    {
        //rb.transform.position(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);

        if (Input.GetAxis("Horizontal") > 0)    //&& checkEdge2(new Vector2(7.5f, -3.5f)))
        {
            movement.x = speed;
        }

        if (Input.GetAxis("Horizontal") < 0)    // && checkEdge(new Vector2(-7.5f, -1.5f)))
        {
            movement.x = -speed;
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

        // movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Mathf.Abs(movement.x) > 0 || Mathf.Abs(movement.y) > 0)
        {
            //animator.SetFloat("Kane_Speed", speed);
        }

        else
        {
            //animator.SetFloat("Kane_Speed", 0);
        }

        rb.velocity = movement;
    }

    void FixedUpdate()
    {
        //moveCharacter(movement);
        //detectMovement();
    }

    public float GetSpeed()
    {
        return Input.GetAxis("Horizontal") * speed;
    }

    void moveCharacter(Vector2 direction)
    {
        //rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    void detectMovement()
    {
        //rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
    }
}
