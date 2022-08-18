using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helix : MonoBehaviour
{
	private bool movable = true;
	private float angle;
	private float lastDeltaAngle, lastTouchX;

	float friction;
	int speed;
	float lerpSpeed;

	private float xDeg;

	private float yDeg ;

	private Quaternion fromRotation ;

	private Quaternion toRotation ;
	void Update()
	{
        if (Time.deltaTime != 0)
        {
            
            if (movable && Input.GetMouseButton(0))
            {

                float mouseX = this.GetMouseX();
                lastDeltaAngle = lastTouchX - mouseX;
                angle += lastDeltaAngle * 360 * 1.8f; //1.7 is like a speed
                lastTouchX = mouseX;
                transform.eulerAngles = new Vector3(0, 0, angle);
                
            }
            else if (lastDeltaAngle != 0)
            {
                lastDeltaAngle -= lastDeltaAngle * 5 * Time.deltaTime;
                angle += lastDeltaAngle * 360 * 1.8f;
                transform.eulerAngles = new Vector3(0, 0, angle);
            }
        }

       

	}
	private float GetMouseX()
	{
        
		return Input.mousePosition.x / ((float)Screen.width);
	}
}
