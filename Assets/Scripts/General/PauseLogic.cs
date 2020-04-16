using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseLogic : MonoBehaviour
{
    public static bool isPaused = false;
    public static bool optionsOpen = false;
    public static bool flip = false;
    public static bool changeVol = false;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject firstPauseButton;
    public GameObject firstOptionsButton;
    public GameObject sliderButton;
    public EventSystem myEventSystem;
    public float timeSpan = 1.0f;
    public Slider volSlider;
    private float volFloat = 1.0f;
    private float time;
    private GameObject currentSelected;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!isPaused)
            {
                Pause();
            }

            else
            {
                Resume();
            }
        }

        currentSelected = EventSystem.current.currentSelectedGameObject;

        if (currentSelected.name == "Slider")
        {
            if (Input.GetButtonDown("MiddleButton"))
            {
                volFloat += 1.0f;
                if (volFloat % 2 == 0)
                {
                    changeVol = true;
                }
                else
                {
                    changeVol = false;
                }
            }
        }
        if (changeVol)
        {
            if (Input.GetButton("RightButton"))
            {
                volSlider.value += 0.005f;
            }
            if (Input.GetButton("LeftButton"))
            {
                volSlider.value -= 0.005f;
                StartCoroutine("highlightBtn");
            }
        }

        if ((Input.GetButton("LeftButton") && Input.GetButton("RightButton")) || (Input.GetButton("LeftButton") && Input.GetButton("RightButton") && Input.GetButton("MiddleButton")))
        {
            if (!flip)
            {
                time += Time.deltaTime;
            }
            if (time > timeSpan)
            {
                flip = true;
                time = 0f;
                if (!isPaused)
                {
                    Pause();
                }
                else
                {
                    Resume();
                }
            }
        }
        if (Input.GetButtonUp("LeftButton") || Input.GetButtonUp("RightButton"))
        {
            time = 0f;
            flip = false;
        }
    }

    public void Resume()
    {
        isPaused = false;
        pauseMenu.gameObject.SetActive(false);
        if (optionsOpen)
        {
            optionsMenu.gameObject.SetActive(false);
            optionsOpen = false;
        }
        if (this.GetComponent<AutoMovement>() != null)
        {
            this.GetComponent<AutoMovement>().enabled = true;
        }
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    IEnumerator highlightBtn()
    {
        myEventSystem.SetSelectedGameObject(null);
        if (!optionsOpen)
        {
            myEventSystem.SetSelectedGameObject(firstPauseButton);
        }
        if (optionsOpen && !changeVol)
        {
            myEventSystem.SetSelectedGameObject(firstOptionsButton);
        }
        if (optionsOpen && changeVol)
        {
            myEventSystem.SetSelectedGameObject(sliderButton);
        }
        yield return null;
    }

    void Pause()
    {
        isPaused = true;
        pauseMenu.gameObject.SetActive(true);
        if (this.GetComponent<AutoMovement>() != null)
        {
            this.GetComponent<AutoMovement>().enabled = false;
        }
        Time.timeScale = 0f;
        AudioListener.pause = true;
        StartCoroutine("highlightBtn");
    }

    public void DisplayControls()
    {
        Debug.Log("displaying controls");
    }

    public void ReturnToMainMenu()
    {
        Resume();
        SceneManager.LoadScene("Main Menu");
    }

    public void ReloadScene()
    {
        Resume();
        Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.buildIndex);
    }

    public void OpenOptionsMenu()
    {
        optionsMenu.gameObject.SetActive(true);
        optionsOpen = true;
        StartCoroutine("highlightBtn");
        pauseMenu.gameObject.SetActive(false);
    }

    public void CloseOptionsMenu()
    {
        optionsOpen = false;
        pauseMenu.gameObject.SetActive(true);
        StartCoroutine("highlightBtn");
        optionsMenu.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
