using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour {

	public GameObject camRig;
	public Camera MnKCam;

	public GameObject sword;

	bool firstPress;

	// Use this for initialization
	void Start () {
		MnKCam.enabled = false;
		firstPress = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("l")) {
			camRig.GetComponent<OVRCameraRig> ().enabled = !camRig.GetComponent<OVRCameraRig> ().enabled;
			MnKCam.enabled = !MnKCam.enabled;
		}
		if (OVRInput.Get (OVRInput.Button.Three)) {
			
		/*	if(firstPress){
				sword.GetComponent<Rigidbody> ().useGravity = true;
				sword.GetComponent<Rigidbody> ().isKinematic = false;
				firstPress = false;
			}*/

			Vector3 pos = sword.transform.position;
			sword.GetComponent<Rigidbody> ().velocity = new Vector3(-1.5f * pos.x, 5 - 1.5f * pos.y, -1.5f * pos.z);
		}
	}
}
