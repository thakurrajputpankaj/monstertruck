using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Spawner : MonoBehaviour {

	public GameObject[] trucks = new GameObject[16];
	public GameObject[] cars = new GameObject[5];
	public GameObject[] towers = new GameObject[3];
	public GameObject pauseMenu;
	public GameObject flag;

	void Start () {
		
	}

	void Update () {
		
	}

	public void InstantiateTower(){
		string name = EventSystem.current.currentSelectedGameObject.name;
		int x = Int32.Parse(name);
		Instantiate(towers[x],transform.position,Quaternion.identity);
		pauseMenu.SetActive (false);
	}
	public void InstantiateTruck(){
		string name =  EventSystem.current.currentSelectedGameObject.name;
		int x = Int32.Parse(name);
		Instantiate(trucks[x],transform.position,Quaternion.identity);
		pauseMenu.SetActive (false);
	}
	public void InstantiateCar(){
		string name =  EventSystem.current.currentSelectedGameObject.name;
		int x = Int32.Parse(name);
		Instantiate(cars[x],transform.position,Quaternion.identity);
		pauseMenu.SetActive (false);
	}
	public void SpawnFlag(){
		Vector3 pos = new Vector3 (transform.position.x, -2.75f);
		Instantiate(flag,pos,Quaternion.identity);
	}
}
