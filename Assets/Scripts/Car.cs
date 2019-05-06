using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

	public GameObject track;
	private Vector3 offset;
	public Transform car;

	public bool move = false;
	public Rigidbody2D rb;
	public float speed = 20f;
	public bool isGround = false;
	public float rotationSpeed = 20f;

	public WheelJoint2D backWheel;
	public WheelJoint2D frontWheel;

	private float roatation = 25f;
		// Controls Here;

	void Start(){
		offset = new Vector3(-100f, 0, 0);
	}

	void Update(){

	}

	void FixedUpdate(){
		if(move == true){
			if (isGround == true) {
				//rb.AddForce (transform.right * speed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
				backWheel.useMotor = true;
				frontWheel.useMotor = true;

				JointMotor2D motor = new JointMotor2D { motorSpeed  = speed, maxMotorTorque = 10000 };
				backWheel.motor = motor;
				frontWheel.motor = motor;

			} else {
			//rb.AddTorque (rotationSpeed * rotationSpeed * Time.fixedDeltaTime * 100f);
			}

		}
	}

	void OnCollisionEnter2D(Collision2D coll){

	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "TrackSpawner") {
			Vector3 newPos = car.position + offset;
			newPos.y = -13.35f;
			Instantiate (track , newPos,Quaternion.identity);
		}
	}

	void OnCollisionExit2D(){
	}

	public void Move(){
		move = true;
	}
	public void Stop(){
		move = false;
	}
}
