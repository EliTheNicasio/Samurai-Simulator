using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeSpawner : MonoBehaviour {

	public GameObject cube;

	LinkedList<GameObject> cubes;

	float t;

	// Use this for initialization
	void Start () {
		t = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;

		if (t >= 5.0f) 
		{
			GameObject clone;
			clone = (GameObject) Instantiate (cube, new Vector3 (.5f, .1f, .5f), Quaternion.identity);
			clone.GetComponent<Rigidbody> ().velocity = new Vector3 (0f, 15f, 0f);
			cubes.AddLast (clone);
		//	cubes.Last.Value.GetComponent<Rigidbody> ().velocity = new Vector3 (0f, 15f, 0f);
		//	print (cubes.Last.Value.GetComponent<Rigidbody> ().velocity);
			print("test");
			t = 0f;
		}
		//print ("test2");
	}
}
