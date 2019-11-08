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

    public KeyCode keyToPress;
    // Start is called before the first frame update
    void Start()
    {
        spriteChanger = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
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
