using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EzySlice;

public class detectSlice : MonoBehaviour {

	public GameObject cube;

	public AudioClip swordSlash;

	int iterations;

	public float t;

	public Text score;

	GameObject slicePlane;

	// Use this for initialization
	void Start () {
		iterations = 0;
		t = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
	}

	private void OnCollisionEnter(Collision collision)
	{
		//print (collision.gameObject.name);
		if (collision.gameObject.name == "Sword") {

			GameObject sword = collision.gameObject;
			slicePlane = sword.transform.GetChild (0).gameObject;

			cutThing ();
		}
	}

	private void OnCollisionStay(Collision collision)
	{
		/*if (collision.contacts.Length >= 3) {
			planeMid = collision.contacts [collision.contacts.Length - 2].point;
			planeEnd = collision.contacts [collision.contacts.Length - 1].point;

			if (collision.gameObject.name == "Sword") {
				cutThing ();
			}
		}*/
	}

	private void OnCollisionExit(Collision collision)
	{
		//cutThing ();
	}

	private void cutThing()
	{
		//GameObject[] hulls = cube.SliceInstantiate (planeEnd, norm);
		GameObject[] hulls = cube.SliceInstantiate 	(slicePlane.transform.position, slicePlane.transform.up);

		if (hulls != null) {
			for (int i = 0; i < 2; i++) {
				hulls [i].AddComponent<MeshCollider> ().convex = true;
				hulls [i].AddComponent<Rigidbody> ();

				hulls [i].AddComponent<hullTimer> ();
				hulls [i].AddComponent<hullTimer> ().hull = hulls [i];

				AudioSource.PlayClipAtPoint (swordSlash, cube.transform.position);

				// This lets object be slice multiple times. Not working as of right now, will fix (hopefully)
				/*if(iterations < 2)
				{
					hulls [i].AddComponent <detectSlice>();
					hulls [i].GetComponent<detectSlice> ().iterations = this.iterations + 1;
					hulls [i].GetComponent<detectSlice> ().cube = hulls [i];
				}*/
			}
			//GetComponent<Renderer> ().enabled = false;

			Destroy(cube);

			score.GetComponent<HighScore> ().score += 1;
		}


	}
}
