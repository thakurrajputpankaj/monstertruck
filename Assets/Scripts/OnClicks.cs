using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClicks : MonoBehaviour {

	public GameObject spawnMenu;

	public void RestartScene(){
		SceneManager.LoadScene ("GodMode");
	}

	public void RestartSceneDesign(){
		SceneManager.LoadScene ("LevelDesign");
	}

	public void OpenPauseMenus(){

	}
	public void OpenSpawnMenu(){
		spawnMenu.SetActive (true);
	}
}
