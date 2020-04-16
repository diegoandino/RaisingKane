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
		if (Input.GetKeyDown(KeyCode.H))
		{
			SceneManager.LoadScene("Gymnasium Hub");
		}

		else if (Input.GetKeyDown(KeyCode.R))
		{
			restartCurrentScene(); 
		}
    }


	public void restartCurrentScene()
	{
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}
}
