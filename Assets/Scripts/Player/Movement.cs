using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public Animator Animator;
    [System.NonSerialized]
    public bool isMoving;

    private ShrinkRythmManager shrinkManager;
    public GameObject Door;

    // Start is called before the first frame update
    void Start()
    {
        //Animator = GetComponent<Animator>();
        moveSpeed = 6;
        shrinkManager = GetComponent<ShrinkRythmManager>();
        Door = GameObject.FindWithTag("Door");
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        float move = Input.GetAxis("Horizontal");

        //Animator.SetFloat("Speed", move);

        if (Door == null)
        {
            moveSpeed = 6;

        }
    }

    //movement currently uses WASD
    void Move()
    {

        if (Input.GetButton("Horizontal"))
        {
            transform.localPosition = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * moveSpeed *
                                             Time.deltaTime, transform.position.y, transform.position.z);
            isMoving = true;
        }
        if (Input.GetButton("Vertical"))
        {
            transform.localPosition = new Vector3(transform.position.x, transform.position.y + Input.GetAxis("Vertical") * moveSpeed *
                                             Time.deltaTime, transform.position.z);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }
}
