using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHintY : MonoBehaviour 
{
	public GameObject arrow;
	public float offset;
	float runningTime;
	float deltaHeight;
	Vector3 newLocation;
	void Update () 
	{
		newLocation = arrow.transform.localPosition;
		deltaHeight = (Mathf.Sin(runningTime + Time.deltaTime) - Mathf.Sin(runningTime));
		newLocation.y += deltaHeight * offset;
		runningTime += Time.deltaTime;
		arrow.transform.localPosition = newLocation;
	}
}