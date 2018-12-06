using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeSpawner : MonoBehaviour {

	public GameObject cube;

	public AudioClip spawnSound;

	//Queue<GameObject> cubeClones;
	LinkedList<GameObject> cubeClones;

	float t, tCube;

	// Use this for initialization
	void Start () {
		t = 0f;
		cubeClones = new LinkedList<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;

		// Adds dummy to cubeClones to ensure it isn't empty, as if it is empty clone cannot be added
		if (cubeClones.Count == 0) {
			cubeClones = new LinkedList<GameObject> ();
			GameObject t = null;
			cubeClones.AddLast (t);
		}

		if (t >= 2.0f) 
		{
			Vector2 pos2D = Random.insideUnitCircle;
			Vector3 pos = new Vector3( pos2D.x * 2, 0, pos2D.y * 2);

			GameObject clone;

			clone = (GameObject) Instantiate (cube, pos, Quaternion.identity);
			clone.GetComponent<Rigidbody> ().velocity = new Vector3 (0f, 6f, 0f) - pos;

			cubeClones.AddLast (clone);

			AudioSource.PlayClipAtPoint (spawnSound, pos);

			t = 0f;
		}
		if (cubeClones.Count != 0) {
			if (cubeClones.First.Value == null) {
				cubeClones.RemoveFirst();
			} else {
				if (cubeClones.First.Value.GetComponent<detectSlice> ().t >= 2.5f) {
					GameObject toDestroy = cubeClones.First.Value;

					cubeClones.RemoveFirst();

					Destroy (toDestroy);
				}
			}
		}
	}
}
