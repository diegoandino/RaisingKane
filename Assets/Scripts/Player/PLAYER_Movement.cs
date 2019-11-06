using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_Movement : MonoBehaviour
{
    public float MOVEMENT_SPEED = 0f;
    public Animator Animator;

    private bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        {
            float move = Input.GetAxis("Horizontal");
            Animator.SetFloat("Speed", move); 
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            isRight = true;

            transform.Translate(Vector3.right * 3f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            isRight = false; 

            transform.Translate(Vector3.right * 3f * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
