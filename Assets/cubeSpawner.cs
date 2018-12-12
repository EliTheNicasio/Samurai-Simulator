using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeSpawner : MonoBehaviour {

	const int NUM_OF_SEQ = 5;
	const float CUBE_SPAWN_HEIGHT = 5.5f;

	public GameObject cube;

	public AudioClip spawnSound;

	public GameObject timer;

	//Queue<GameObject> cubeClones;
	LinkedList<GameObject> cubeClones;

	float t, tCube, actionT;

	int seqNum, ind;

	Vector2 pos2D;

	// Use this for initialization
	void Start () {
		t = 0f;
		actionT = 0f;
		cubeClones = new LinkedList<GameObject> ();
		seqNum = Random.Range (0, NUM_OF_SEQ);
		//seqNum = 5;
		ind = 0;
	}

	// Update is called once per frame
	void Update () {
		if (!timer.GetComponent<Timer> ().gameEnded && timer.GetComponent<Timer> ().gameStarted) {
			t += Time.deltaTime;

			seqNum = doSeq ();
			//print (seqNum);

			// Adds dummy to cubeClones to ensure it isn't empty, as if it is empty clone cannot be added

			if (cubeClones.Count != 0) {
				if (cubeClones.First.Value == null) {
					cubeClones.RemoveFirst ();
				} else {
					if (cubeClones.First.Value.GetComponent<detectSlice> ().t >= 2.5f) {
						GameObject toDestroy = cubeClones.First.Value;

						cubeClones.RemoveFirst ();

						Destroy (toDestroy);
					}
				}
			}
		}
	}

	private int doSeq(){

		// Part of fun
		//float actionT = 0f;

		actionT += Time.deltaTime; 

		if (cubeClones.Count == 0) {
			cubeClones = new LinkedList<GameObject> ();
			GameObject temp = null;
			cubeClones.AddLast (temp);
		}

		switch (seqNum) {
		// Spawns 5 cubes in random sequence
		case 0:
			// Do this for fun
			//actionT += t;

			if (t < .15f) {
				pos2D = Random.insideUnitCircle.normalized;
				ind = -5;	
			}

			// Spawn Pattern
			if (actionT > 1.0f) {
				float angle = Random.Range (-90f, 90f);
				pos2D = Random.insideUnitCircle.normalized;
				Vector3 pos = Quaternion.AngleAxis (angle, Vector3.up) * new Vector3 (pos2D.x * 2, 0, pos2D.y * 2);

				GameObject clone;

				clone = (GameObject)Instantiate (cube, pos, Quaternion.identity);
				clone.GetComponent<Rigidbody> ().velocity = new Vector3 (0f, CUBE_SPAWN_HEIGHT, 0f) - pos;
				clone.GetComponent<detectSlice> ().seqNum = 0;

				cubeClones.AddLast (clone);

				AudioSource.PlayClipAtPoint (spawnSound, pos);

				actionT = 0f;

			} 

			// End sequence condition
			if (t > 5.0f) {
				t = 0f;
				return 4;
			}else {
				return 0;
			}
			break;

		// Spawns cubes horizontally in a row
		case 1:
			if (t < .15f) {
				pos2D = Random.insideUnitCircle.normalized;
				ind = -5;	
			}
			if (actionT > .15f) {
				
				Vector3 pos;

				float angle = (ind / 3f) * (180 / 4f);

				ind++;

				pos = Quaternion.AngleAxis (angle, Vector3.up) * new Vector3 (pos2D.x * 4, 0, pos2D.y * 4);

				GameObject clone;

				clone = (GameObject)Instantiate (cube, pos, Quaternion.identity);
				clone.GetComponent<Rigidbody> ().velocity = new Vector3 (0f, CUBE_SPAWN_HEIGHT, 0f) - pos;
				clone.GetComponent<detectSlice> ().seqNum = 1;

				cubeClones.AddLast (clone);

				AudioSource.PlayClipAtPoint (spawnSound, pos);

				actionT = 0;
			}

			if (t > 1.5f) {
				t = 0f;
				return 4;
			} else {
				return 1;
			}
			break;

		// Spawns 7 cubes at once in a semicircle
		case 2:
			if (actionT > 1.0f) {

				pos2D = Random.insideUnitCircle.normalized;
				Vector3 pos;

				for (int i = -3; i < 4; i++) {
					float angle = (i / 3f) * (180 / 4f);

					pos = Quaternion.AngleAxis (angle, Vector3.up) * new Vector3 (pos2D.x * 4, 0, pos2D.y * 4);

					GameObject clone;

					clone = (GameObject)Instantiate (cube, pos, Quaternion.identity);
					clone.GetComponent<Rigidbody> ().velocity = new Vector3 (0f, CUBE_SPAWN_HEIGHT + .5f, 0f) - pos;
					clone.GetComponent<detectSlice> ().seqNum = 2;

					cubeClones.AddLast (clone);

					AudioSource.PlayClipAtPoint (spawnSound, pos);
				}

				actionT = 0;
			}

			if (t > 1.9f) {
				t = 0f;
				return 4;
			} else {
				return 2;
			}
			break;

		// vertical line of cubes
		case 3:
			if (t < .15f) {
				pos2D = Random.insideUnitCircle.normalized;

				ind = 0;	
			}
			if (actionT > .15f) {

				Vector3 pos;

				pos = new Vector3 (pos2D.x * 4 + 3, 2 + (ind * .1f), pos2D.y * 4);

				GameObject clone;

				clone = (GameObject)Instantiate (cube, pos, Quaternion.identity);
				clone.GetComponent<Rigidbody> ().velocity = new Vector3 (0f, CUBE_SPAWN_HEIGHT, 0f) - pos;
				clone.GetComponent<detectSlice> ().seqNum = 3;

				cubeClones.AddLast (clone);

				AudioSource.PlayClipAtPoint (spawnSound, pos);

				ind++;

				actionT = 0;
			}

			if (t > 1.5f) {
				t = 0f;
				return 4;
			} else {
				return 3;
			}
			break;
		
		case 4:
			if (t > 2.0f) {
				t = 0f;
				actionT = 0f;
				int toReturn = Random.Range (0, NUM_OF_SEQ);
				if (toReturn == 4)
					return 0;
				else
					return toReturn;
			} else {
				return 4;
			}
			break;

		case 5:
			if (t < .15f) {
				pos2D = Random.insideUnitCircle.normalized;

				ind = -5;	
			}
			if (actionT > .15f) {

				Vector3 pos;

				pos = new Vector3 (pos2D.x * 4 * (ind / 5), 2, pos2D.y * 4 * (ind / 5));

				GameObject clone;

				clone = (GameObject)Instantiate (cube, pos, Quaternion.identity);
				clone.GetComponent<Rigidbody> ().velocity = new Vector3 (0f, CUBE_SPAWN_HEIGHT, 0f) - pos;
				clone.GetComponent<detectSlice> ().seqNum = 5;

				cubeClones.AddLast (clone);

				AudioSource.PlayClipAtPoint (spawnSound, pos);

				ind++;

				actionT = 0;
			}

			if (t > 1.5f) {
				t = 0f;
				return 4;
			} else {
				return 5;
			}
			break;
		}

		return seqNum;
	}
}
