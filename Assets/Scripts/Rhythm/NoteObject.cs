using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public GameObject ButtonLocation;
    public float ButtonPos;
    public bool canBePressed;
    public KeyCode keyToPress;
    // Start is called before the first frame update
    void Start()
    {
        //Get the x position of the button
        ButtonPos = ButtonLocation.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                //GameManger.instance.NoteHit();
                if ((transform.position.x > ButtonPos + 0.15) || (transform.position.x < ButtonPos - 0.15))
                {
                    Debug.Log("Normal Hit");
                    gameObject.SetActive(false);
                    GameManger.instance.NoteHit();
                }
                else if ((transform.position.x > ButtonPos + 0.05) || (transform.position.x < ButtonPos - 0.05))
                {
                    Debug.Log("Good Hit");
                    gameObject.SetActive(false);
                    GameManger.instance.NoteHit();
                }
                else
                {
                    Debug.Log("Perfect Hit");
                    gameObject.SetActive(false);
                    GameManger.instance.NoteHit();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        canBePressed = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.activeSelf)
        {
            canBePressed = false;
            GameManger.instance.NoteMiss();
        }
    }
}
