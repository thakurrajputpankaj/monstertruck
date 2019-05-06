using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMenu : MonoBehaviour {
	public GameObject carList,TruckList,TowerList,Spawnmenu;

	void Start(){
		TowerList.SetActive (true);
		carList.SetActive (false);
		TruckList.SetActive (false);
	}

	public void showCars(){
		TowerList.SetActive (false);
		carList.SetActive (true);
		TruckList.SetActive (false);
	}
	public void showTrucks(){
		TowerList.SetActive (false);
		carList.SetActive (false);
		TruckList.SetActive (true);
	}
	public void showTowers(){
		TowerList.SetActive (true);
		carList.SetActive (false);
		TruckList.SetActive (false);
	}
	public void CloseSpawnMenu(){
		Spawnmenu.SetActive (false);
	}
}
