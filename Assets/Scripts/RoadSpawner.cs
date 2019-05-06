using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour {

	public GameObject road;

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Player") {
			Vector3 offset = new Vector3(15f,0f,0f);
			Vector3 pos = new Vector3(transform.position.x,-4.45f);
			Instantiate (road, pos + offset, Quaternion.identity);
		}
	}
}
