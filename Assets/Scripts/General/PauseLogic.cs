using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseLogic : MonoBehaviour
{
    public static bool isPaused = false;
    public static bool optionsOpen = false;
    public static bool flip = false;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public EventSystem myEventSystem;
    public float timeSpan = 1.0f;
    private float time;

    //[SerializeField]
    //private AudioSource Music;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        //pauseMenu = GetComponent<GameObject>();
        //canvas = canvas.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        if (Input.GetButton("LeftButton") && Input.GetButton("RightButton"))
        {
            Debug.Log("both buttons pressed");
            if (!flip)
            {
                time += Time.deltaTime;
            }
            if (time > timeSpan)
            {
                flip = true;
                time = 0f;
                Debug.Log("pause");
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
        Debug.Log("sdfg");
        myEventSystem.SetSelectedGameObject(null);
        yield return null;
        myEventSystem.SetSelectedGameObject(myEventSystem.firstSelectedGameObject);
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
        //Music.Pause();
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
        pauseMenu.gameObject.SetActive(false);
    }

    public void CloseOptionsMenu()
    {
        optionsMenu.gameObject.SetActive(false);
        optionsOpen = false;
        Pause();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}