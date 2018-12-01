using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeSpawner : MonoBehaviour {

	public GameObject cube;

	public AudioClip spawnSound;

	Queue<GameObject> cubeClones;

	float t, tCube;

	// Use this for initialization
	void Start () {
		t = 0f;
		cubeClones = new Queue<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;

		if (t >= 2.0f) 
		{
			Vector2 pos2D = Random.insideUnitCircle;
			Vector3 pos = new Vector3( pos2D.x * 2, 0, pos2D.y * 2);

			GameObject clone;

			clone = (GameObject) Instantiate (cube, pos, Quaternion.identity);
			clone.GetComponent<Rigidbody> ().velocity = new Vector3 (0f, 6f, 0f) - pos;

			cubeClones.Enqueue (clone);

			AudioSource.PlayClipAtPoint (spawnSound, pos);

			t = 0f;
		}
		if (cubeClones.Count != 0) {
			if (cubeClones.Peek ().GetComponent<detectSlice> ().t >= 2.5f) {
				Destroy (cubeClones.Dequeue ());
			}
		}
	}
}
