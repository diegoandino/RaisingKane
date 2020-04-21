﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BossTracker : MonoBehaviour
{
    public bool Boss1Finished = false;
    public bool Boss2Finished = false;
    public bool Boss3Finished = false;
    public bool Boss4Started = false;

    // Start is called before the first frame update
    void Start()
    {
        ResetBosses();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void ResetBosses()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
                Boss1Finished = false;
                Boss2Finished = false;
                Boss3Finished = false;
        }
    }
}
