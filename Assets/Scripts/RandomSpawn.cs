using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {
	
	public GameObject[] trucks = new GameObject[16];
	public GameObject[] cars = new GameObject[5];
	public GameObject[] towers = new GameObject[3];

	void Start(){
		InvokeRepeating ("SpawanSomething", 6f, 6f);
	}

	void SpawanSomething(){
		int x = Random.Range (0, 3);
		if (x == 0) {
			InstantiateTowerGod();
		}
		if (x == 1) {
			InstantiateCarGod();
		}
		if (x == 2) {
			InstantiateTruckGod();
		}
	}

	 void InstantiateTowerGod(){
		int x = Random.Range (0, 2);
		Instantiate(towers[x],transform.position,Quaternion.identity);
	}
	 void InstantiateTruckGod(){
		int x = Random.Range (0, 15);
		Instantiate(trucks[x],transform.position,Quaternion.identity);
	}
	 void InstantiateCarGod(){
		int x = Random.Range (0, 5);
		Instantiate(cars[x],transform.position,Quaternion.identity);
	}

}
