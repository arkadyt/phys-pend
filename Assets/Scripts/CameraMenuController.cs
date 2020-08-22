using UnityEngine;
using System.Collections;

public class CameraMenuController : MonoBehaviour
{
	public Transform target;
	public float rotationSpeed;
	public float ellipseWidth;

	private float ellipseHeight;
	private float angle;
	private Vector3 camPos;

	void Start ()
	{
		angle = 0;
		camPos = transform.position;
		ellipseHeight = Mathf.Abs (transform.position.z);
	}
	
	void Update ()
	{
		angle += rotationSpeed * Time.deltaTime;

		camPos.x = (float)(ellipseWidth * -Mathf.Sin (angle));
		camPos.z = (float)(ellipseHeight * -Mathf.Cos (angle));
		transform.position = camPos;
		transform.LookAt (target.transform);
	}
}
