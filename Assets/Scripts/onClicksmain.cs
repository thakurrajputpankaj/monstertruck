using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onClicksmain : MonoBehaviour {

	public GameObject optionsMenu;
	public GameObject mainCanvas;

	public void Exit(){
		Application.Quit ();
	}

	public void openOptions(){
		mainCanvas.SetActive (false);
		optionsMenu.SetActive (true);
	}

	public void OpenGodMode(){
		PlayerPrefs.SetInt ("level", 1);
		SceneManager.LoadScene ("UfoComing");
	}
	public void OpenInfiniteRun(){
		PlayerPrefs.SetInt ("level", 2);
		SceneManager.LoadScene ("SelectEnvironment");
	}
	public void OpenBuildLevel(){
		PlayerPrefs.SetInt ("level", 3);
		SceneManager.LoadScene ("UfoComing");
	}
}
