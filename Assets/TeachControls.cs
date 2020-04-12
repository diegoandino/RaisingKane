using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeachControls : MonoBehaviour
{
    public GameObject controlsGraphic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            controlsGraphic.gameObject.SetActive(false);
        }
    }
}
