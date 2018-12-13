using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public bool gameStarted;
	public bool gameEnded;

	public Text score;

	public GameObject restartCube;
	public GameObject startCube;

	bool soundPlayed, rCubeMade;

	public AudioClip endSound;

	public float time;
	float timePassed;

	// Use this for initialization
	void Start () {
		time = 60;

		gameStarted = false;
		gameEnded = false;
		soundPlayed = false;
		rCubeMade = false;

		startCube.SetActive (false);
		GameObject sCube = (GameObject)Instantiate (startCube, startCube.transform.position, Quaternion.identity);
		sCube.SetActive (true);

		restartCube.SetActive (false);
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
			if (!rCubeMade) {
				GameObject rCube = (GameObject)Instantiate (restartCube, restartCube.transform.position, 
					Quaternion.AngleAxis(150,Vector3.down));
				rCube.SetActive (true);
				rCubeMade = true;
			}
		}
	}

	public void Restart(){
		time = 60;

		gameStarted = false;
		gameEnded = false;
		soundPlayed = false;
		rCubeMade = false;

		score.GetComponent<HighScore> ().score = 0;
		GameObject sCube = (GameObject)Instantiate (startCube, startCube.transform.position, Quaternion.identity);
		sCube.SetActive (true);
	}
}
