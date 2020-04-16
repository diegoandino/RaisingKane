using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

	public void Overworld()
	{
		SceneManager.LoadScene("Overworld_Move");
	}

	public void Credits()
	{
		SceneManager.LoadScene("Credits");
	}

    public void startGame()
    {
        SceneManager.LoadScene("OpeningAnimatic");
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void levelSelect()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void loadBoss1()
    {
        SceneManager.LoadScene("Boss_1_Sticky");
    }

    public void loadBoss2()
    {
        SceneManager.LoadScene("Boss_2_Bounce");
    }

    public void loadBoss3()
    {
        SceneManager.LoadScene("Boss_3_Multi");
    }

    public void loadBoss4()
    {
        SceneManager.LoadScene("Boss_Final");
    }
}
