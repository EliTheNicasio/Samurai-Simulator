using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour {

	public GameObject camRig;
	public Camera MnKCam;

	// Use this for initialization
	void Start () {
		MnKCam.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("l")) {
			camRig.GetComponent<OVRCameraRig> ().enabled = !camRig.GetComponent<OVRCameraRig> ().enabled;
			MnKCam.enabled = !MnKCam.enabled;
		}
	}
}
