using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SceneManager.LoadScene("Overworld_Move");
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("Boss1");
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("Boss2");
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            SceneManager.LoadScene("Gymnasium Hub");
        }
    }
}
