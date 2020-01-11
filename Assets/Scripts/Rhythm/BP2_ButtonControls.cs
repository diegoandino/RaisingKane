﻿/* Author: Rachel Hoffman
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
///

[System.Serializable]
public class BP2_ButtonControls : MonoBehaviour
{
    private SpriteRenderer spriteChanger;

	[SerializeField]
	private KeyCode KEY;

    public Transform plush;
    public Transform button; 
    public Sprite defaultImage;
    public Sprite pressedImage;

	public static bool pressed;
    public static bool aPressed;
    public static bool sPressed;
    public static bool dPressed;

    public static float ButtonPos; //the x,y cordinates of the button
	public static KeyCode staticKey;
    public static Vector3 staticPlushPos;

	public GameObject button1;
	public GameObject button2;
	public GameObject button3;

	//--Vector 3 Instantiantion Variables for location --//
	Vector3 pos1 = new Vector3(-4.9f, -1.75f, -2f);
    Vector3 pos2 = new Vector3(-4.9f, -2.5f, -2f);
    Vector3 pos3 = new Vector3(-4.9f, -3.25f, -2f);
    Vector3 pos4 = new Vector3(-4.9f, -4f, -2f);
    //---------------------------------------------------//


    // Start is called before the first frame update
    void Start()
    {
		spriteChanger = GetComponent<SpriteRenderer>();

		pressed = false;

		ButtonPos = -4.9f;
    }

    // Update is called once per frame
    void Update()
    {
		BeatControls(); 

        Pressed();
    }


	/**
     * Beat Button Controls 
     */
	void BeatControls()
    { 

        //Button Pressed
        if (Input.GetKeyDown(KEY))
		{
			spriteChanger.sprite = pressedImage;
			pressed = true;

			musicManager.Playsound("plushFire");

			staticKey = KEY;


		    plush.position = new Vector3 (button.position.x, button.position.y - 3f);

		    staticPlushPos = plush.position;
		}

		//Button Release
		if (Input.GetKeyUp(KEY))
		{
			spriteChanger.sprite = defaultImage;
			pressed = false;

			button1.GetComponent<Collider2D>().enabled = true;
			button2.GetComponent<Collider2D>().enabled = true;
			button3.GetComponent<Collider2D>().enabled = true;
		}
	}


    void Pressed()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            aPressed = true;
            sPressed = false;
            dPressed = false;

			button1.GetComponent<Collider2D>().enabled = true;
			button2.GetComponent<Collider2D>().enabled = false;
			button3.GetComponent<Collider2D>().enabled = false;

            Debug.Log("BUTTON 1: " + button1.transform.position.x);
        }


        else if (Input.GetKeyDown(KeyCode.S))
        {
            aPressed = false;
            sPressed = true;
            dPressed = false;

			button1.GetComponent<Collider2D>().enabled = false;
			button2.GetComponent<Collider2D>().enabled = true;
			button3.GetComponent<Collider2D>().enabled = false;

            Debug.Log("BUTTON 2: " + button2.transform.position.x);
        }


        else if (Input.GetKeyDown(KeyCode.D))
        {
            aPressed = false;
            sPressed = false;
            dPressed = true;

			button1.GetComponent<Collider2D>().enabled = false;
			button2.GetComponent<Collider2D>().enabled = false;
			button3.GetComponent<Collider2D>().enabled = true;

            Debug.Log("BUTTON 3: " + button3.transform.position.x);
        }
    }
}
