using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonLogicGO : MonoBehaviour
{
    public EventSystem myEventSystem;
    public GameObject RestartButton;
    public GameObject ExitButton;
    private GameObject currentSelected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentSelected = EventSystem.current.currentSelectedGameObject;
        if ((Input.GetButtonDown("RightButton") || Input.GetButtonDown("LeftButton")) && currentSelected.name == "Try Again")
        {
            StartCoroutine("highlightExit");
        }
        else if ((Input.GetButtonDown("RightButton") || Input.GetButtonDown("LeftButton")) && currentSelected.name == "Return")
        {
            StartCoroutine("highlightRestart");
        }
        /*else if (Input.GetButtonDown("LeftButton") && currentSelected.name == "Try Again")
        {
            StartCoroutine("highlightExit");
        }
        if (Input.GetButtonDown("LeftButton") && currentSelected.name == "Return")
        {
            StartCoroutine("highlightRestart");
        }*/

    }

    IEnumerator highlightRestart()
    {
        myEventSystem.SetSelectedGameObject(null);
        myEventSystem.SetSelectedGameObject(RestartButton);
        yield return null;
    }

    IEnumerator highlightExit()
    {
        myEventSystem.SetSelectedGameObject(null);
        myEventSystem.SetSelectedGameObject(ExitButton);
        yield return null;
    }
}
