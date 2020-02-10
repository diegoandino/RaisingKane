using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTest : MonoBehaviour
{
	public int maxValue = 100;
	public int currValue = 0;
	public Meter meter;

	// Start is called before the first frame update
	void Start()
    {
		meter.setValue(currValue);
		meter.setMaxValue(maxValue);
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space)) { damage(5); }
	}

	public void damage(int damage)
	{
		currValue += damage;
		meter.setValue(currValue);
	}
}
