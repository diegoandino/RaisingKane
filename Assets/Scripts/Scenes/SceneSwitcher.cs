﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
	public void Overworld()
	{
		SceneManager.LoadScene("Overworld_Move");
	}

	public void Boss2()
	{
		SceneManager.LoadScene("Boss2");
	}
    /*
    public void startGame()
    {
        SceneManager.LoadScene("");
    }
    */
}
