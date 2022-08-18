using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
public class TouchButton : MonoBehaviour
{

	private static bool pressing;

	public static bool IsPressing()
	{
		if (Input.GetMouseButtonDown(0))
		{
			pressing = true;
		}

		else if (Input.GetMouseButtonUp(0))
		{
			pressing = false;
		}


		return pressing;
	}
	
}