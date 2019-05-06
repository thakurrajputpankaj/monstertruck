using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ScrollDirection { LeftToRight, RightToLeft, DownToUp, UpToDown };

public class SpaceManager : MonoBehaviour {
    //Set the direction that the screen or the camera is moving
    public ScrollDirection scrollDirection = ScrollDirection.LeftToRight;
    ScrollDirection direction;

    public static SpaceManager instance = null;

    void Start () {
        direction = scrollDirection;
        instance = this;
		Invoke ("LoadGame", 4f);

    }
	
	void Update () {
        //Prevent that the variable could be changed in execution mode (removing this could cause bugs)
        if(direction != scrollDirection)
        {
            scrollDirection = direction;
        }
	}

	void LoadGame(){
		if (PlayerPrefs.GetInt ("level") == 1) {
			SceneManager.LoadScene ("GodMode");
		}
		if (PlayerPrefs.GetInt ("level") == 2) {
			SceneManager.LoadScene ("InfiniteRun");
		}
		if (PlayerPrefs.GetInt ("level") == 3) {
			SceneManager.LoadScene ("LevelDesign");
		}
	}
}
