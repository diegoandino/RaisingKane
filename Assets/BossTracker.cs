using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BossTracker : MonoBehaviour
{
    public bool Boss1Finished = false;
    public bool Boss2Finished = false;
    public bool Boss3Finished = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Boss1Finished && Boss2Finished && Boss3Finished)
        {
            SceneManager.LoadScene("Boss_Final");
        }
    }
}
