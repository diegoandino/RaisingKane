/* Author: Rachel Hoffman
 * 
 * This program changes the sprite for when the button is pressed.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Changes the button's sprite.
/// </summary>
public class BP2_ButtonControls : MonoBehaviour
{
    private SpriteRenderer spriteChanger;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public GameObject plushLocation;

    //--Vector 3 Instantiantion Variables for location --//
    Vector3 pos1 = new Vector3(-4.9f, -1.75f, -2f);
    Vector3 pos2 = new Vector3(-4.9f, -2.5f, -2f);
    Vector3 pos3 = new Vector3(-4.9f, -3.25f, -2f);
    Vector3 pos4 = new Vector3(-4.9f, -4f, -2f);
    //---------------------------------------------------//

    public KeyCode up;
    public KeyCode down;
    public KeyCode keyToPress;
    // Start is called before the first frame update
    void Start()
    {
        plushLocation.transform.position = pos2;
        spriteChanger = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(up))
        {
            if(plushLocation.transform.position == pos1)
            {
                //play nope sound or something.
            }
            else if(plushLocation.transform.position == pos2)
            {
                //2 -> 1
                plushLocation.transform.position = pos1;
            }
            else if (plushLocation.transform.position == pos3)
            {
                //3 -> 2
                plushLocation.transform.position = pos2;
            }
            else
            {
                //4 -> 3
                plushLocation.transform.position = pos3;
            }
        }

        if (Input.GetKeyDown(down))
        {
            if (plushLocation.transform.position == pos1)
            {
                //1 -> 2
                plushLocation.transform.position = pos2;
            }
            else if (plushLocation.transform.position == pos2)
            {
                //2 -> 3
                plushLocation.transform.position = pos3;
            }
            else if (plushLocation.transform.position == pos3)
            {
                //3 -> 4
                plushLocation.transform.position = pos4;
            }
            else
            {
                //play nope sound or something.
            }
        }

        //Button Pressed
        if (Input.GetKeyDown(keyToPress))
        {
            musicManager.Playsound("plushFire");
            spriteChanger.sprite = pressedImage;
        }

        //Button Release
        if (Input.GetKeyUp(keyToPress))
        {
            spriteChanger.sprite = defaultImage;
        }
    }
}
