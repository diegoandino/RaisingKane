using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public Animator Animator;
    public bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        //Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        float move = Input.GetAxis("Horizontal");
        //Animator.SetFloat("Speed", move);
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + moveSpeed *
                                             Time.deltaTime, transform.position.y, transform.position.z);
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - moveSpeed *
                                             Time.deltaTime, transform.position.y, transform.position.z);
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.y < 2)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed *
                                                                       Time.deltaTime, transform.position.z);
                isMoving = true;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.y > 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed *
                                                                       Time.deltaTime, transform.position.z);
                isMoving = true;
            }
        }

        else
        {
            isMoving = false;
        }
    }
}
