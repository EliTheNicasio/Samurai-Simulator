using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	public Text gameText;

	public int score;
	public int multiplier;

	// Use this for initialization
	void Start () {
		score = 0;
		multiplier = 1;
	}
	
	// Update is called once per frame
	void Update () {
		gameText.text = "Samurai Simulator \n \n Score: \n" + score;
		gameText.fontSize = 500;
	}
}
