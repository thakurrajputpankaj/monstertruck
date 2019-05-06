using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prallaxing : MonoBehaviour {

	public Transform[] backgrounds;
	private float[] prallaxScalw;
	public float smoothing = 1f;
	private Transform cam;
	private Vector3 previousCamPosition;

	void Awake(){
		cam = Camera.main.transform;
	}


	void Start () {
		previousCamPosition = cam.position;
		prallaxScalw = new float[backgrounds.Length];

		for (int i = 0; i < backgrounds.Length; i++) {
			prallaxScalw [i] = backgrounds [i].position.z * -1;
		}
	}

	void FixedUpdate () {

		for (int i = 0; i< backgrounds.Length ;i++){
			float parallax = (previousCamPosition.x - cam.position.x) * prallaxScalw [i];
			float backgroundTargetPosX = backgrounds [i].position.x + parallax;

			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds [i].position.y, backgrounds [i].position.z);

			backgrounds [i].position = Vector3.Lerp (backgrounds[i].position,backgroundTargetPos,smoothing*Time.deltaTime);
	}
	
		previousCamPosition = cam.position;
} 

}