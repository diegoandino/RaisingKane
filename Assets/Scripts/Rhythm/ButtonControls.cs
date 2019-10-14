using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControls : MonoBehaviour
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
        if (Input.GetKeyDown(keyToPress))
        {
            spriteChanger.sprite = pressedImage;
        }

        if (Input.GetKeyUp(keyToPress))
        {
            spriteChanger.sprite = defaultImage;
        }
    }
}
