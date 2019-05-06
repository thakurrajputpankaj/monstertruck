using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainmenu : MonoBehaviour {

	public GameObject[] buttonsMain = new GameObject[3];
	public GameObject[] buttonsPlay = new GameObject[3];
	public GameObject Options, MainMenuCanvas;

	void Start(){
		for (int i = 0; i < 3; i++) {
			buttonsMain [i].SetActive (true);
			buttonsPlay[i].SetActive (false);
		}
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape) && Options.active == false) {
			for (int i = 0; i < 3; i++) {
				buttonsMain [i].SetActive (true);
				buttonsPlay[i].SetActive (false);
			}
		}if (Input.GetKeyDown (KeyCode.Escape) && Options.active == true) {
			Options.SetActive (false);
			MainMenuCanvas.SetActive (true);
		}
	}

	public void onPlay(){
		for (int i = 0; i < 3; i++) {
			buttonsPlay[i].SetActive (true);
			buttonsMain [i].SetActive (false);
		}
	}
}
