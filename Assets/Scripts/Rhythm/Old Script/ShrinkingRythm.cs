using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingRythm : MonoBehaviour
{
    public float Timer;
    public float scale;
    public float shrinkMod;
    public float rotation;

    private float ShrinkTimer;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(scale, scale, scale);
		ShrinkTimer = 0;
	}

	// Update is called once per frame
	void FixedUpdate()
    {
        scale -= shrinkMod;
        transform.localScale = new Vector3(scale, scale, scale);
        // rotates on the z based on a serializable variable and time
        //transform.localRotation = new Quaternion(0, 0, Time.deltaTime * rotation, 0);'
        transform.Rotate(0, 0, rotation);
        if (scale < 0.08)
        {
            gameObject.GetComponentInParent<ShrinkRythmManager>().DisCheck(-10f);
            Destroy(this.gameObject);
        }
		ShrinkTimer += Time.fixedDeltaTime;
    }

    public void ButtonPressed()
    {
        Destroy(this.gameObject);
	}

}
