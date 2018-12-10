using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	public bool gameStarted;
	public bool gameEnded;

	bool soundPlayed;

	public AudioClip endSound;

	public float time;
	float timePassed;

	// Use this for initialization
	void Start () {
		time = 60;
		gameStarted = false;
		gameEnded = false;
		soundPlayed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameStarted){
			if (time > 0) {
				time -= Time.deltaTime;
			} else {
				gameEnded = true;
			}
		}
		if (gameEnded) {
			if (!soundPlayed) {
				AudioSource.PlayClipAtPoint (endSound, new Vector3(0, 0, 0), .45f);
				soundPlayed = true;
			}
		}
	}
}
