using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Optionsmenu : MonoBehaviour {

	public GameObject optionsMenu;
	public GameObject mainCanvas;

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) && optionsMenu.active == true) {
			optionsMenu.SetActive (false);
			mainCanvas.SetActive (true);
		}
	}
}
