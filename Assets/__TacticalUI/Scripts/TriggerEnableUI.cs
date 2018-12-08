using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnableUI : MonoBehaviour 
{
	public GameObject[] hiddenElements;
	void Awake()
	{
		for (int i = 0; i < hiddenElements.Length; i++)
		{
			hiddenElements[i].SetActive(false);
		}	
	}
	void OnTriggerEnter(Collider col)
	{
		for (int i = 0; i < hiddenElements.Length; i++)
		{
			hiddenElements[i].SetActive(true);
		}
	}

	void OnTriggerExit(Collider col)
	{
		for (int i = 0; i < hiddenElements.Length; i++)
		{
			hiddenElements[i].SetActive(false);
		}	
	}
	
}
