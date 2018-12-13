using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startCube : MonoBehaviour {

	public GameObject timer;

	public GameObject cube;

	public Text score;

	public AudioClip startSound;

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
			AudioSource.PlayClipAtPoint (startSound, transform.position);
			timer.GetComponent<Timer> ().gameStarted = true;
			score.GetComponent<HighScore> ().score = 0;
			isSliced = true;
		}
	}
}
