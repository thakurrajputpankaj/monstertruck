using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infinite : MonoBehaviour {
	public GameObject[] trucks = new GameObject[18];
	public GameObject[] cars = new GameObject[6];
	public GameObject[] towers = new GameObject[3];


	void Start () {
		InvokeRepeating ("InstantiateSomething", 5f, 5f);
	}

	void InstantiateSomething(){
		int random2 = Random.Range (1,4);
		if (random2 == 1) {
			int random = Random.Range (0,18);
			Instantiate (trucks [random], transform.position, Quaternion.identity);
		}
		if (random2 == 2) {
			int random = Random.Range (0,6);
			Instantiate (cars [random], transform.position, Quaternion.identity);
		}
		if (random2 == 3) {
			int random = Random.Range (0,3);
			Instantiate (towers [random], transform.position, Quaternion.identity);
		}
	}
}
