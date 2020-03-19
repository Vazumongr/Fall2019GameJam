﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	//Loads a scene by the scenes Index in the build settings.
	public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

	//Simply closes the game in editor and executable.
	public void QuitGame()
	{
		//UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit ();
	}
}
