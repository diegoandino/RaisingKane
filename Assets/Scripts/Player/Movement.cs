using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if(transform.position.y < 2)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime, transform.position.z);
            }
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.position.y > 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime, transform.position.z);
            }
        }
    }
}
