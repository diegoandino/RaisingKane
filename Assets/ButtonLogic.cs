using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonLogic : MonoBehaviour
{
    public EventSystem myEventSystem;
    public GameObject StartButton;
    public GameObject ExitButton;
    public GameObject CreditsButton;
    private GameObject currentSelected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentSelected = EventSystem.current.currentSelectedGameObject;
        if (Input.GetButtonDown("RightButton") && currentSelected.name == "Start Button")
        {
            StartCoroutine("highlightExit");
        }
        else if (Input.GetButtonDown("RightButton") && currentSelected.name == "Quit Button")
        {
            StartCoroutine("highlightCredits");
        }
        else if (Input.GetButtonDown("LeftButton") && currentSelected.name == "Credits Button")
        {
            StartCoroutine("highlightExit");
        }
        if (Input.GetButtonDown("LeftButton") && currentSelected.name == "Quit Button")
        {
            StartCoroutine("highlightStart");
        }

        //StartCoroutine("highlightBtn");
    }

    IEnumerator highlightStart()
    {
        myEventSystem.SetSelectedGameObject(null);
        myEventSystem.SetSelectedGameObject(StartButton);
        yield return null;
    }

    IEnumerator highlightExit()
    {
        myEventSystem.SetSelectedGameObject(null);
        myEventSystem.SetSelectedGameObject(ExitButton);
        yield return null;
    }

    IEnumerator highlightCredits()
    {
        myEventSystem.SetSelectedGameObject(null);
        myEventSystem.SetSelectedGameObject(CreditsButton);
        yield return null;
    }
}
