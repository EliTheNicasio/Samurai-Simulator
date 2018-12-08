using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomIn : MonoBehaviour 
{
	public GameObject element;
	public float offsetValue;
	public float smoothTime;
	Ray ray;
	Vector3 initPos;
	Collider elementCol;

	void Start()
	{
		initPos = element.transform.localPosition;
		elementCol = GetComponent<Collider>();
	}
	void Update()
	{
		RaycastHit hit;
		element.transform.localPosition = initPos;
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(elementCol.Raycast(ray, out hit, 100.0f))
		{
			element.transform.localPosition = Vector3.Lerp(element.transform.localPosition, new Vector3(element.transform.localPosition.x, element.transform.localPosition.y, offsetValue), smoothTime);
		}
	}
}
