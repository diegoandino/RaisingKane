using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver4 : MonoBehaviour
{
    public playerTest meter;

    // Update is called once per frame
    void Update()
    {
        if (meter.currValue < 1) SceneManager.LoadScene("Game Over_4");
    }
}
