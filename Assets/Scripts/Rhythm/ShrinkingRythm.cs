using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingRythm : MonoBehaviour
{
    public float Timer;
    public float scale = 15;
    public float shrinkMod = 1;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(scale, scale, scale);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scale = scale - (Time.deltaTime * shrinkMod);
        transform.localScale = new Vector3(scale, scale, scale);
        if (scale < 0.08)
        {
            gameObject.GetComponentInParent<ShrinkRythmManager>().DisCheck(-10f);
            Destroy(this.gameObject);
        }
    }

    public void ButtonPressed()
    {
        Destroy(this.gameObject);
    }

}
