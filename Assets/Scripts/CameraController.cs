using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Permissions;

public class CameraController : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	public float smoothSpeed = 0.5f;
	public CarController carControl;
	public Swipe swipe;

	void Start(){

	}


	void FixedUpdate(){
		if (carControl.start == true) {
			offset.x = 6;
			Vector3 newPos = target.position + offset;
			Vector3 smoothedPosition = Vector3.Lerp (transform.position, newPos, smoothSpeed);
			smoothedPosition.y = transform.position.y;
			smoothedPosition.z = transform.position.z;
			transform.position = smoothedPosition;
		} else {
			if (swipe.SwipeLeft) {
				offset.x = 0.5f;
				Vector3 pos = new Vector3 (transform.position.x + offset.x, 0f, 0f);
				pos.y = transform.position.y;
				pos.z = transform.position.z;
				transform.position = pos;
			}
			if (swipe.SwipeRight) {
				offset.x = -0.5f;
				Vector3 pos = new Vector3 (transform.position.x + offset.x, 0f, 0f);
				pos.y = transform.position.y;
				pos.z = transform.position.z;
				transform.position = pos;
			}

		}
	}
	}

