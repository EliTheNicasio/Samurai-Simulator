using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class detectSlice : MonoBehaviour {

	public GameObject sphere;

	Vector3 planeBegin;
	Vector3 planeMid;
	Vector3 planeEnd;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		planeBegin = collision.contacts [0].point;
		// Physics.IgnoreLayerCollision(0, 8);
		print (planeBegin);
	}

	private void OnCollisionStay(Collision collision)
	{
		if (collision.contacts.Length >= 3) {
			planeMid = collision.contacts [collision.contacts.Length - 2].point;
			planeEnd = collision.contacts [collision.contacts.Length - 1].point;
			//print (planeMid);
			cutThing();
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		//cutThing ();
	}

	private void cutThing()
	{
		Vector3 norm = Vector3.Cross (planeBegin - planeMid, planeEnd - planeMid);

		GameObject[] hulls = sphere.SliceInstantiate (planeEnd, norm);

		if (hulls != null) {
			for (int i = 0; i < 2; i++) {
				hulls [i].AddComponent<MeshCollider> ().convex = true;
				hulls [i].AddComponent<Rigidbody> ();
				//hulls [i].AddComponent <detectSlice>();
			//	hulls [i].GetComponent<detectSlice> ().sphere = hulls [i];
			}
			Destroy (sphere);
		}


	}
}
