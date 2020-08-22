using UnityEngine;
using System.Collections;

public class LiftScript : MonoBehaviour {
	public bool goDown = false;
	public float liftSpeed = 2f;
	public bool activated = false;

	void FixedUpdate() {
		if(activated) {
			GameObject.Find("Real Cart").transform.parent = GetComponent<Transform>();
			GameObject.Find("Sphere").transform.parent = null;
			GetComponent<Transform>().Translate(Vector3.up * (goDown ? -liftSpeed : liftSpeed) * Time.deltaTime);
		}
	}

	void OnTriggerEnter(Collider other) {
			liftSpeed *= -1;
	}
}
