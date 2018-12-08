using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayTimer : MonoBehaviour {

	public Text gameText;

	public GameObject timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameText.text = "" + Mathf.Round(timer.GetComponent<Timer>().time * 10f) / 10f;
	}
}
