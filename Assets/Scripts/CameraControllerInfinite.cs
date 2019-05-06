using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerInfinite : MonoBehaviour {
	public Transform target;
	public Vector3 offset;
	public float smoothSpeed = 0.5f;
	public CarControllerInfinite carControl;
	public Swipe swipe;

	void Start(){

	}


	void FixedUpdate(){
			offset.x = 6;
			Vector3 newPos = target.position + offset;
			Vector3 smoothedPosition = Vector3.Lerp (transform.position, newPos, smoothSpeed);
			smoothedPosition.y = transform.position.y;
			smoothedPosition.z = transform.position.z;
		transform.position = smoothedPosition;
	}
}
