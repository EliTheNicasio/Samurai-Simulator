using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	public bool gameStarted;

	public float time;
	float timePassed;

	// Use this for initialization
	void Start () {
		time = 60;
		gameStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameStarted){
			if (time > 0) {
				time -= Time.deltaTime;
			}
		}
	}
}
