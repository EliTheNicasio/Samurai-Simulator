using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MnKPlayerController : MonoBehaviour {

	public Camera cam;

	public GameObject sword;

	bool swordFollows;

	public float mouseSensitivity = 1000.0f;
	public float clampAngle = 80.0f;

	private float rotY = 0.0f; // rotation around the up/y axis
	private float rotX = 0.0f; // rotation around the right/x axis

	// Use this for initialization
	void Start () {
		swordFollows = false;

		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (cam.enabled) {
			float xAxisValue = Input.GetAxis ("Horizontal");
			float zAxisValue = Input.GetAxis ("Vertical");
			this.transform.Translate (new Vector3 (.1f * xAxisValue, 0.0f, .1f * zAxisValue));

			float mouseX = Input.GetAxis("Mouse X");
			float mouseY = -Input.GetAxis("Mouse Y");

			rotY += mouseX * mouseSensitivity * Time.deltaTime;
			rotX += mouseY * mouseSensitivity * Time.deltaTime;

			rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

			Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
			transform.rotation = localRotation;

			if (Input.GetMouseButtonDown (1)) {
				swordFollows = !swordFollows;
			}

			if (swordFollows) {
				//Vector3 temp = new Vector3(this.transform.position.x + .1f, this.transform.position.y, this.transform.position.z + .03f);
				sword.transform.position = cam.transform.position + cam.transform.forward * .5f + cam.transform.right * .25f;
				sword.transform.rotation = Quaternion.LookRotation (cam.transform.forward * -1, Vector3.up);

			}
		}
	}
}
