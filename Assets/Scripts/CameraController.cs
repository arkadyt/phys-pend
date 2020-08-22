using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform realcart;

	void Update() {
		if(Input.GetButton("Fire2"))
			transform.RotateAround(realcart.position, Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * 200);
	}

	void Start() {
		if(GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
	}
	
}
