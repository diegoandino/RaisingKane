using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
	public void GoToGameScene()
	{
		SceneManager.LoadScene("Game");
	}

	public void GoToMenuScene()
	{
		SceneManager.LoadScene("Main Menu");
	}

    public void QuitGame()
	{
		Application.Quit();
		print("GAME IS QUITTING . . .");
	}
}
