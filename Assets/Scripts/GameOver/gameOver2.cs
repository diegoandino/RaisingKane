using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver2 : MonoBehaviour
{
    public playerTest meter;
    private SceneSwitcher switcher;

    // Update is called once per frame
    void Update()
    {
        if (meter.currValue < 1) SceneManager.LoadScene("Game Over_2");
    }
}
