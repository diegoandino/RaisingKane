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
///

[System.Serializable]
public class BP2_ButtonControls : MonoBehaviour
{
    private SpriteRenderer spriteChanger;

	[SerializeField]
	private KeyCode KEY;

    public Sprite defaultImage;
    public Sprite pressedImage;
	public static bool pressed;
	public static float ButtonPos; //the x,y cordinates of the button
	public static KeyCode staticKey;

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
		}

		//Button Release
		if (Input.GetKeyUp(KEY))
		{
			spriteChanger.sprite = defaultImage;
			pressed = false;
		}
	}
}
