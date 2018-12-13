using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class restartCube : MonoBehaviour {

	public GameObject cube;
	public GameObject timer;
	public Text score;

	bool isSliced;

	// Use this for initialization
	void Start () {
		isSliced = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!isSliced && cube.GetComponent<detectSlice> ().sliced) {
			timer.GetComponent<Timer> ().Restart ();
			isSliced = true;
		}
	}
}
