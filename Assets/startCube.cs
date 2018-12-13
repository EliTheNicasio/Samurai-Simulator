using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startCube : MonoBehaviour {

	public GameObject timer;

	public Text score;

	public AudioClip startSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		AudioSource.PlayClipAtPoint (startSound, transform.position);
		timer.GetComponent<Timer> ().gameStarted = true;
		score.GetComponent<HighScore> ().score = 0;
	}
}
