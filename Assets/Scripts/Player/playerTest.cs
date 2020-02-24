using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class playerTest : MonoBehaviour
{
    private bool destroy;

	public int maxValue = 100;
	public int currValue = 0;


	public Meter meter;

	// Start is called before the first frame update
	void Start()
    {
		meter.setMaxValue(maxValue);
        meter.setValue(currValue);

        destroy = Projectile._destroy;
    }

    // Update is called once per frame
    void Update()
    {
       
    }


	public void damage(int damage)
	{
		currValue += damage;
		meter.setValue(currValue);
	}


    public void decrementMeter(int damage)
    {
        currValue -= damage;
        meter.setValue(currValue);
    }


    public void winState()
    {
        if (currValue == maxValue)
        {
           
        }
    }


    private IEnumerator increment()
    {
        damage(1);
        yield return new WaitForSeconds(1);
    }
}
