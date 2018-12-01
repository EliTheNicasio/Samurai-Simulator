using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hullTimer : MonoBehaviour {

	public GameObject hull;

	float t;

	// Use this for initialization
	void Start () {
		t = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;

		if (t >= 5f) {
			Destroy (hull);
			t = 0f;
		}
	}
}
