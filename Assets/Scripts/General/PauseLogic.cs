using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseLogic : MonoBehaviour
{
    public static bool isPaused = false;
    public static bool optionsOpen = false;
    public GameObject pauseMenu;
    public GameObject optionsMenu;

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
        if(this.GetComponent<AutoMovement>() != null)
        {
            this.GetComponent<AutoMovement>().enabled = true;
        }
        Time.timeScale = 1f;
        AudioListener.pause = false;
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
    }

    public void CloseOptionsMenu()
    {
        optionsMenu.gameObject.SetActive(false);
        optionsOpen = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}