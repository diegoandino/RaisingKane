using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Boss1Click : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Boss1");
    }
}
