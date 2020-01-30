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

    public Transform plush;
    public Transform button;
    public Sprite defaultImage;
    public Sprite collisionImage;
    public Sprite correctImage;
    public Sprite incorrectImage;

    public bool isColliding;
    private IEnumerator imageChangeCoRoutine;

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

	public static GameObject _button1;
	public static GameObject _button2;
	public static GameObject _button3;

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
        isColliding = false;

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
            pressed = true;

            musicManager.Playsound("plushFire");

            staticKey = KEY;
            staticPlushPos = plush.position;

            IsButtonRight();
        }

        //Button Release
        if (Input.GetKeyUp(KEY))
        {
            //spriteChanger.sprite = defaultImage;
            pressed = false;

            button1.GetComponent<Collider2D>().enabled = true;
            button2.GetComponent<Collider2D>().enabled = true;
            button3.GetComponent<Collider2D>().enabled = true;

            imageChangeCoRoutine = WaitAndResetDefaultImage(0.1f);
            StartCoroutine(imageChangeCoRoutine);
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

			_button1 = button1;
        }


        else if (Input.GetKeyDown(KeyCode.S))
        {
            aPressed = false;
            sPressed = true;
            dPressed = false;

            button1.GetComponent<Collider2D>().enabled = false;
            button2.GetComponent<Collider2D>().enabled = true;
            button3.GetComponent<Collider2D>().enabled = false;

			_button2 = button2;
		}


        else if (Input.GetKeyDown(KeyCode.D))
        {
            aPressed = false;
            sPressed = false;
            dPressed = true;

            button1.GetComponent<Collider2D>().enabled = false;
            button2.GetComponent<Collider2D>().enabled = false;
            button3.GetComponent<Collider2D>().enabled = true;

			_button3 = button3;
		}
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Beat")
        {
            // is no longer colliding
            isColliding = false;
            imageChangeCoRoutine = WaitAndResetDefaultImage(0.1f);
            StartCoroutine(imageChangeCoRoutine);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Beat")
        {
            // Changes to colliding button  sprite
            spriteChanger.sprite = collisionImage;
            isColliding = true;
        }
    }
    private void IsButtonRight()
    {
        // Changes image based on if the press is right or wrong
        if (isColliding)
        {

            spriteChanger.sprite = correctImage;
        }
        else
        {
            spriteChanger.sprite = incorrectImage;
        }

    }
    private IEnumerator WaitAndResetDefaultImage(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        spriteChanger.sprite = defaultImage;
    }
}
