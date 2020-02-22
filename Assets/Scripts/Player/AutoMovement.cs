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
    private bool clockwise;
    private bool leftPress;
    private bool rightPress;

    // Start is called before the first frame update
    void Start()
    {
        //num_of_mov_points = movPoints.Count;
        start = movPoints[0];
        end = new Vector3(0, 0, 0);
        leftPress = false;
        rightPress = false;

    }

    // Update is called once per frame
    void Update()
    {
        objectPos = transform.position;
        Move();
    }

    public void Move()
    {
        //Left press
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            leftPress = true;
            rightPress = false;
        }

        //Right Press
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            leftPress = false;
            rightPress = true;
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            leftPress = false;
            rightPress = false;
        }
 
        if (leftPress != rightPress)
        {

            //LEFT
            if (leftPress)
            {
                //--------------------------------------------------
                //---------Check if object is on a point------------
                //--------------------------------------------------

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

                //start from point 2 and move to point 3
                else if (objectPos == movPoints[2])
                {
                    start = movPoints[2];
                    end = movPoints[3];
                    clockwise = true;

                    //reset placing to start of line
                    place = 0.0f;
                }

                //start from point 3 and move to point 4
                else if (objectPos == movPoints[3])
                {
                    start = movPoints[3];
                    end = movPoints[4];
                    clockwise = true;

                    //reset placing to start of line
                    place = 0.0f;
                }

                //start from point 4 and move to point 5
                else if (objectPos == movPoints[4])
                {
                    start = movPoints[4];
                    end = movPoints[5];
                    clockwise = true;

                    //reset placing to start of line
                    place = 0.0f;
                }

                //start from point 5 and move to point 6
                else if (objectPos == movPoints[5])
                {
                    start = movPoints[5];
                    end = movPoints[6];
                    clockwise = true;

                    //reset placing to start of line
                    place = 0.0f;
                }

                //start from point 6 and move to point 7
                else if (objectPos == movPoints[6])
                {
                    start = movPoints[6];
                    end = movPoints[7];
                    clockwise = true;

                    //reset placing to start of line
                    place = 0.0f;
                }

                //start from point 7 and move to point 0
                else if (objectPos == movPoints[7])
                {
                    start = movPoints[7];
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
                    place += (speed/Vector3.Distance(start,end));

                    // This travels from start vector to end vector, and the place
                    //      is the dist the object is on that line from start to end.
                    transform.position = Vector3.Lerp(start, end, place);
                }
                else
                {
                    place -= (speed / Vector3.Distance(start, end));

                    // This travels from start vector to end vector, and the place
                    //      is the dist the object is on that line from start to end.
                    transform.position = Vector3.Lerp(start, end, place);
                }

            }//end of LEFT check


            //RIGHT
            if (rightPress)
            {
                //--------------------------------------------------
                //---------Check if object is on a point------------
                //--------------------------------------------------

                //start from point 0 and move to point 7
                if (objectPos == movPoints[0])
                {
                    start = movPoints[0];
                    end = movPoints[7];
                    clockwise = false;

                    //reset placing to start of line
                    place = 0.0f;
                }

                //start from point 7 and move to point 6
                if (objectPos == movPoints[7])
                {
                    start = movPoints[7];
                    end = movPoints[6];
                    clockwise = false;

                    //reset placing to start of line
                    place = 0.0f;
                }

                //start from point 6 and move to point 5
                if (objectPos == movPoints[6])
                {
                    start = movPoints[6];
                    end = movPoints[5];
                    clockwise = false;

                    //reset placing to start of line
                    place = 0.0f;
                }

                //start from point 5 and move to point 4
                else if (objectPos == movPoints[5])
                {
                    start = movPoints[5];
                    end = movPoints[4];
                    clockwise = false;

                    //reset placing to start of line
                    place = 0.0f;
                }

                //start from point 4 and move to point 3
                else if (objectPos == movPoints[4])
                {
                    start = movPoints[4];
                    end = movPoints[3];
                    clockwise = false;

                    //reset placing to start of line
                    place = 0.0f;
                }

                //start from point 3 and move to point 2
                else if (objectPos == movPoints[3])
                {
                    start = movPoints[3];
                    end = movPoints[2];
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

                //start from point 1 and move to point 0
                else if (objectPos == movPoints[1])
                {
                    start = movPoints[1];
                    end = movPoints[0];
                    clockwise = false;

                    //reset placing to start of line
                    place = 0.0f;
                }



                //--------------------------------------------------
                //-----------Move object along the line-------------
                //--------------------------------------------------

                if (clockwise)
                {
                    place -= (speed / Vector3.Distance(start, end));

                    // This travels from start vector to end vector, and the place
                    //      is the dist the object is on that line from start to end.
                    transform.position = Vector3.Lerp(start, end, place);
                }
                else
                {
                    place += (speed / Vector3.Distance(start, end));

                    // This travels from start vector to end vector, and the place
                    //      is the dist the object is on that line from start to end.
                    transform.position = Vector3.Lerp(start, end, place);
                }

            }//end of RIGHT check

        }//end of Both buttons not pressed check
    }//end of Move

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        int index = 0;
        foreach (Vector3 point in movPoints)
        {
            index++;
            if (index >= movPoints.Count)
            {
                index = 0;
            }
            Gizmos.DrawLine(point, movPoints[index]);
        }




    }
}
