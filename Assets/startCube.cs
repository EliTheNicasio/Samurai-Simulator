using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startCube : MonoBehaviour {

	public GameObject timer;

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
	}
}
