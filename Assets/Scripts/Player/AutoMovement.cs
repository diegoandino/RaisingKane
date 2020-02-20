//Created by: Rachel Hoffman
//A script that moves an object to set vectors
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovement : MonoBehaviour
{

    public float speed; //the length the object travels the line every frame
    public float place = 0.0f; // the place the object is on the line

    public List<Vector3> movPoints;

    //public int num_of_mov_points;
    public Vector3 start;
    public Vector3 end;
    private Vector3 objectPos;
    public bool clockwise;

    // Start is called before the first frame update
    void Start()
    {
        //num_of_mov_points = movPoints.Count;
        start = movPoints[0];
        end = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        objectPos = transform.position;
        Move();
    }

    public void Move()
    {
        //LEFT
        if (Input.GetKeyDown(KeyCode.A))
        {
            //--------------------------------------------------
            //---------Check if object is on a point------------
            //--------------------------------------------------

            /*for(int i = 0; i > movPoints.Count; i++)
            {
                if (objectPos == movPoints[i])
                {
                    start = movPoints[i];
                    end = movPoints[i+1];
                    clockwise = true;

                    //reset placing to start of line
                    place = 0.0f;
                }
            }*/

            //start from point 0 and move to point 1
            if (objectPos == movPoints[0])
            {
                start = movPoints[0];
                end = movPoints[1];
                clockwise = true;

                //reset placing to start of line
                place = 0.0f;
            }

            //start from point 1 and move to point 2
            else if (objectPos == movPoints[1])
            {
                start = movPoints[1];
                end = movPoints[2];
                clockwise = true;

                //reset placing to start of line
                place = 0.0f;
            }

            //start from point 2 and move to point 0
            else if (objectPos == movPoints[2])
            {
                start = movPoints[2];
                end = movPoints[0];
                clockwise = true;

                //reset placing to start of line
                place = 0.0f;
            }



            //--------------------------------------------------
            //-----------Move object along the line-------------
            //--------------------------------------------------

            if (clockwise)
            {
                place += speed;

                // This travels from start vector to end vector, and the place
                //      is the dist the object is on that line from start to end.
                transform.position = Vector3.Lerp(start, end, place);
            }
            else
            {
                place -= speed;

                // This travels from start vector to end vector, and the place
                //      is the dist the object is on that line from start to end.
                transform.position = Vector3.Lerp(start, end, place);
            }

        }//end of LEFT check


        //RIGHT
        if (Input.GetKeyDown(KeyCode.D))
        {
            //--------------------------------------------------
            //---------Check if object is on a point------------
            //--------------------------------------------------

            //start from point 0 and move to point 2
            if (objectPos == movPoints[0])
            {
                start = movPoints[0];
                end = movPoints[2];
                clockwise = false;

                //reset placing to start of line
                place = 0.0f;
            }

            //start from point 1 and move to point 0
            else if (objectPos == movPoints[1])
            {
                start = movPoints[1];
                end = movPoints[0];
                clockwise = false;

                //reset placing to start of line
                place = 0.0f;
            }

            //start from point 2 and move to point 1
            else if (objectPos == movPoints[2])
            {
                start = movPoints[2];
                end = movPoints[1];
                clockwise = false;

                //reset placing to start of line
                place = 0.0f;
            }



            //--------------------------------------------------
            //-----------Move object along the line-------------
            //--------------------------------------------------

            if (clockwise)
            {
                place -= speed;

                // This travels from start vector to end vector, and the place
                //      is the dist the object is on that line from start to end.
                transform.position = Vector3.Lerp(start, end, place);
            }
            else
            {
                place += speed;

                // This travels from start vector to end vector, and the place
                //      is the dist the object is on that line from start to end.
                transform.position = Vector3.Lerp(start, end, place);
            }


        }//end of RIGHT check
    }//end of Move
}
