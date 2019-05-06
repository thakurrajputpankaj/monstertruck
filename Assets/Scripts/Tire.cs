using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tire : MonoBehaviour {


	public CarController car;

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Road") {
			car.isGrounded = true;
		} else {
			car.Rotate ();
		}
	}

	void OnCollisionExit2D(){
		car.isGrounded = false;
	}
}
