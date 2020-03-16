/* Author: Rachel Hoffman
 * 
 * This program changes the sprite for when the button is pressed.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Changes the button's sprite.
/// </summary>
///

[System.Serializable]
public class BP2_ButtonControls : MonoBehaviour
{
    private SpriteRenderer spriteChanger;

    [SerializeField]
    public string InputButton;
     

    public Transform plush;
    public Transform button;
    public Sprite defaultImage;
    public Sprite collisionImage;
    public Sprite correctImage;
    public Sprite incorrectImage;

    private bool isColliding;
    private IEnumerator imageChangeCoRoutine;

    public static bool pressed;
    public static bool Pressed1;
    public static bool Pressed2;
    public static bool Pressed3;

    public static float ButtonPos; //the x,y cordinates of the button
    public static string staticButton;
    public static Vector3 staticPlushPos;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    public GameObject rhythmText;
    private Animator textAnimator;
    private TextMeshPro textMesh;

	public static GameObject _button1;
	public static GameObject _button2;
	public static GameObject _button3;

    private List<string> perfectHit;
    private List<string> goodHit;
    private List<string> normalHit;

    private List<string> missHit;

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

        textAnimator = rhythmText.GetComponent<Animator>();
        textMesh = rhythmText.GetComponent<TextMeshPro>();
        textAnimator.SetBool("Nice", false);

        perfectHit = new List<string>() { "Great!!", "Marvelous", "Excellent", "Epic!!",  };
        goodHit = new List<string>() { "Good", "Cool", "Nice", "Not Bad", "Super", "Great" };
        normalHit = new List<string>() { "Better", "Not Bad", "Nice"};

        missHit = new List<string>() { "Poor", "Miss", "Low", "Lousy" };

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
        if (Input.GetButtonDown(InputButton))
        {           
            pressed = true;

            musicManager.Playsound("plushFire");

            staticButton = InputButton;
            staticPlushPos = plush.position;

            IsButtonRight();
        }

        //Button Release
        if (Input.GetButtonUp(InputButton))
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
        if (Input.GetButtonDown("LeftButton"))
        {
            Pressed1 = true;
            Pressed2 = false;
            Pressed3 = false;

            button1.GetComponent<Collider2D>().enabled = true;
            button2.GetComponent<Collider2D>().enabled = false;
            button3.GetComponent<Collider2D>().enabled = false;

			_button1 = button1;
        }


        else if (Input.GetButtonDown("MiddleButton"))
        {
            Pressed1 = false;
            Pressed2 = true;
            Pressed3 = false;

            button1.GetComponent<Collider2D>().enabled = false;
            button2.GetComponent<Collider2D>().enabled = true;
            button3.GetComponent<Collider2D>().enabled = false;

			_button2 = button2;
		}


        else if (Input.GetButtonDown("RightButton"))
        {
            Pressed1 = false;
            Pressed2 = false;
            Pressed3 = true;

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

            // text doesnt change when large
            if(textMesh.gameObject.transform.localScale.x < .01)
            {
                textMesh.text = perfectHit[Random.Range(0, perfectHit.Count)];
                textMesh.color = new Color(.3f, .3f, .7f);
                textAnimator.SetBool("Nice", true);
            }
        }
        else
        {
            spriteChanger.sprite = incorrectImage;

            if (textMesh.gameObject.transform.localScale.x < .01)
            {
                textMesh.text = missHit[Random.Range(0, missHit.Count)];
                textMesh.color = new Color(.7f, .3f, .3f);
                textAnimator.SetBool("Nice", true);
            }
        }

    }
    private IEnumerator WaitAndResetDefaultImage(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        spriteChanger.sprite = defaultImage;
        yield return new WaitForSeconds(waitTime * 2);
        textAnimator.SetBool("Nice", false);
    }
}
