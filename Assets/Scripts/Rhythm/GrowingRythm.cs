using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingRythm : MonoBehaviour
{
    public float Timer;
    public float scale;
    public float growMod;
    public float rotation;

    private float GrowTimer;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0, 0, 0);
		GrowTimer = 0;
        scale = transform.localScale.x;
	}

	// Update is called once per frame
	void FixedUpdate()
    {
        scale += growMod;
        transform.localScale = new Vector3(scale, scale, scale);
        // rotates on the z based on a serializable variable and time
        //transform.localRotation = new Quaternion(0, 0, Time.deltaTime * rotation, 0);'
        transform.Rotate(0, 0, rotation);
        if (scale > 5.6)
        {
            gameObject.GetComponentInParent<GrowRythmManager>().DisCheck(10f);
            Destroy(this.gameObject);
        }
		GrowTimer += Time.fixedDeltaTime;

    }

    public void ButtonPressed()
    {
        Destroy(this.gameObject);
	}

}
