using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class detectSlice : MonoBehaviour {

	public GameObject cube;

	int iterations;

	Vector3 planeBegin;
	Vector3 planeMid;
	Vector3 planeEnd;

	// Use this for initialization
	void Start () {
		iterations = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		planeBegin = collision.contacts [0].point;
		//print(collision.gameObject.name);
	}

	private void OnCollisionStay(Collision collision)
	{
		if (collision.contacts.Length >= 3) {
			planeMid = collision.contacts [collision.contacts.Length - 2].point;
			planeEnd = collision.contacts [collision.contacts.Length - 1].point;

			if (collision.gameObject.name == "Sword") {
				cutThing ();
			}
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		//cutThing ();
	}

	private void cutThing()
	{
		Vector3 norm = Vector3.Cross (planeBegin - planeMid, planeEnd - planeMid);

		GameObject[] hulls = cube.SliceInstantiate (planeEnd, norm);

		if (hulls != null) {
			for (int i = 0; i < 2; i++) {
				hulls [i].AddComponent<MeshCollider> ().convex = true;
				hulls [i].AddComponent<Rigidbody> ();

				// This lets object be slice multiple times. Not working as of right now, will fix (hopefully)
				/*if(iterations < 2)
				{
					hulls [i].AddComponent <detectSlice>();
					hulls [i].GetComponent<detectSlice> ().iterations = this.iterations + 1;
					hulls [i].GetComponent<detectSlice> ().cube = hulls [i];
				}*/
			}
			Destroy (cube);
		}


	}
}
